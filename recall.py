# -*- coding:utf-8 -*-

import itchat
import os
import time 
from itchat.content import *
import re
import shutil



msg_dict={}

def ClearTimeOutMsg():
    if msg_dict.__len__() > 0:
        for msgid in list(msg_dict): #由于字典在遍历过程中不能删除元素，故使用此方法
            if time.time() - msg_dict.get(msgid, None)["msg_time"] > 130.0: #超时两分钟
                item = msg_dict.pop(msgid)
                #print("超时的消息：", item['msg_content'])
                #可下载类消息，并删除相关文件
                if item['msg_type'] == "Picture" \
                        or item['msg_type'] == "Recording" \
                        or item['msg_type'] == "Video" \
                        or item['msg_type'] == "Attachment":
                    print("要删除的文件：", item['msg_content'])
                    os.remove(item['msg_content'])


@itchat.msg_register([TEXT, PICTURE, MAP, CARD, SHARING, RECORDING, ATTACHMENT, VIDEO, FRIENDS])
def Revocation(msg):
    mytime = time.localtime()  # 这儿获取的是本地时间
    #获取用于展示给用户看的时间 2017/03/03 13:23:53
    msg_time_touser = mytime.tm_year.__str__() \
                      + "/" + mytime.tm_mon.__str__() \
                      + "/" + mytime.tm_mday.__str__() \
                      + " " + mytime.tm_hour.__str__() \
                      + ":" + mytime.tm_min.__str__() \
                      + ":" + mytime.tm_sec.__str__()

    msg_id = msg['MsgId'] #消息ID
    msg_time = msg['CreateTime'] #消息时间
    msg_from = itchat.search_friends(userName=msg['FromUserName'])['NickName'] #消息发送人昵称
    msg_type = msg['Type'] #消息类型
    msg_content = None #根据消息类型不同，消息内容不同
    msg_url = None #分享类消息有url
    #图片 语音 附件 视频，可下载消息将内容下载暂存到当前目录
    if msg['Type'] == 'Text':
        msg_content = msg['Text']
    elif msg['Type'] == 'Picture':
        msg_content = msg['FileName']
        msg['Text'](msg['FileName'])
    elif msg['Type'] == 'Card':
        msg_content = msg['RecommendInfo']['NickName'] + r" 的名片"
    elif msg['Type'] == 'Map':
        x, y, location = re.search("<location x=\"(.*?)\" y=\"(.*?)\".*label=\"(.*?)\".*", msg['OriContent']).group(1,
                                                                                                                    2,
                                                                                                                    3)
        if location is None:
            msg_content = r"纬度->" + x.__str__() + " 经度->" + y.__str__()
        else:
            msg_content = r"" + location
    elif msg['Type'] == 'Sharing':
        msg_content = msg['Text']
        msg_url = msg['Url']
    elif msg['Type'] == 'Recording':
        msg_content = msg['FileName']
        msg['Text'](msg['FileName'])
    elif msg['Type'] == 'Attachment':
        msg_content = r"" + msg['FileName']
        msg['Text'](msg['FileName'])
    elif msg['Type'] == 'Video':
        msg_content = msg['FileName']
        msg['Text'](msg['FileName'])
    elif msg['Type'] == 'Friends':
        msg_content = msg['Text']

    #更新字典
    # {msg_id:(msg_from,msg_time,msg_time_touser,msg_type,msg_content,msg_url)}
    msg_dict.update(
        {msg_id: {"msg_from": msg_from, "msg_time": msg_time, "msg_time_touser": msg_time_touser, "msg_type": msg_type,
                  "msg_content": msg_content, "msg_url": msg_url}})
    #清理字典
    ClearTimeOutMsg()
    #print msg_dict

# @itchat.msg_register(itchat.content.TEXT)
# def SaveMsg(msg):
# 	print(msg)
# 	if not os.path.exists("C:\\Revocation\\"):
# 		os.mkdir(".\\Revocation\\")
# 	print msg['Content']

@itchat.msg_register(NOTE)
def Recall(msg):
    if not os.path.exists("C:\\WeChat\\"):
        os.mkdir("C:\\WeChat\\")
    if re.search(r"\<replacemsg\>\<\!\[CDATA\[.*[\u4e00-\u9fa5]*\]\]\>\<\/replacemsg\>", msg['Content']) != None:
        old_msg_id = re.search("\<msgid\>(.*?)\<\/msgid\>", msg['Content']).group(1)
		#print old_msg_id
        old_msg=msg_dict.get(old_msg_id,{})
        msg_send=(u"您的好友：[%s]在[%s]撤回了一条[%s]类型消息：[%s]"%(old_msg.get('msg_from',''),old_msg.get('msg_time_touser'),old_msg['msg_type'],old_msg.get('msg_content')))
        #msg_send=old_msg.get('msg_from','')+old_msg.get('msg_time_touser')+old_msg.get('msg_content','')  
        if old_msg['msg_type'] == "Sharing":
            msg_send += r", 链接: " \
                        + old_msg.get('msg_url', '')
        elif old_msg['msg_type'] == 'Picture' \
                or old_msg['msg_type'] == 'Recording' \
                or old_msg['msg_type'] == 'Video' \
                or old_msg['msg_type'] == 'Attachment':
            msg_send += u", 存储在C:\WeChat文件夹中"
            shutil.move(old_msg['msg_content'],r"C:\\WeChat")
            #shutil.move是修改文件名了。。。
            #shutil.move(old_msg['msg_content'], r":\\Revocation\\")         
        itchat.send(msg_send,'filehelper')
        msg_dict.pop(old_msg_id)
        ClearTimeOutMsg()

if  __name__=='__main__':
	itchat.auto_login(hotReload=True)
	itchat.run()
