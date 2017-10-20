# -*- coding:utf-8 -*-
import re
import requests

from requests.packages.urllib3.exceptions import InsecureRequestWarning
# 禁用安全请求警告
requests.packages.urllib3.disable_warnings(InsecureRequestWarning)



import json
import sys,locale
import time
import datetime
from prettytable import PrettyTable as pt

#根据用户输入的站点中文名 返回一个英文编码，带到访问的URL地址里
def get_Station(station_name):
	dict={}
	#存储站点信息的URL地址
	url="https://kyfw.12306.cn/otn/resources/js/framework/station_name.js?station_version=1.9026"
	response=requests.get(url,verify=False)
	for x in response.content.replace('var station_names =\'','').split('@'):
		if(x!=''):
			#print x
			x=x.split('|')
			dict[x[1]]=x[2]
	#返回对应的英文编码
	return dict[station_name]
	
def get_LeftTicket(date,from_station,to_station):
	headers={
		'Host':'kyfw.12306.cn',
		'User-Agent':'Mozilla/5.0 (Windows NT 6.1; WOW64; rv:55.0) Gecko/20100101 Firefox/55.0',
		'Accept':'*/*',
		'Accept-Language':'zh-CN,zh;q=0.8,en-US;q=0.5,en;q=0.3',
		'Accept-Encoding':'gzip, deflate, br',
		'If-Modified-Since':'0',
		'Cache-Control':'no-cache',
		'X-Requested-With':'XMLHttpRequest',
		'Referer':'https://kyfw.12306.cn/otn/leftTicket/init',
		'Connection':'keep-alive'
	}
	#余票查询url
	url=("https://kyfw.12306.cn/otn/leftTicket/queryX?leftTicketDTO.train_date=%s&leftTicketDTO.from_station=%s&leftTicketDTO.to_station=%s&purpose_codes=ADULT"%(date,from_station,to_station))
	print url
	#response=requests.get(url,headers=headers,verify=False)
	response=requests.get(url,headers=headers,verify=False)#verfy=False,解决证书问题
	print response.content.decode('utf-8').encode('gbk')
	r=response.content
	value=json.loads(r)
	result=value['data']['result']
	#title=PrettyTable.Prettytable()
	#title=PrettyTable(["车次","出发时间","到达时间","是否有余票","软卧"])
	#title.field_names=["车次","出发时间","到达时间","是否有余票","软卧"]
	for x in result:
	 	#print x
		print x.split('|')[3]+'--'+x.split('|')[8]+'--'+x.split('|')[9]+'--'\
		+x.split('|')[11]+'--'+x.split('|')[23]
		#title.add_row([x.split('|')[3],x.split('|')[8],x.split('|')[9],x.split('|')[11],x.split('|')[23]])
	#print title
	#print result[0]

# #解决cmd显示中文乱码问题
# StartDate=raw_input(unicode('请输入出发日期:','utf-8').encode('gbk'))
# datetime=StartDate.decode('gbk').encode('utf-8')
# Fromstation_name=raw_input(unicode('请输入始发站：','utf-8').encode('gbk'))
# #把输入的内容编码转换，否则匹配不出来对应的中文
# from_station=get_Station(Fromstation_name.decode('gbk').encode('utf-8'))
# Tostation_name=raw_input(unicode('请输入目的地车站：','utf-8').encode('gbk'))
# to_station=get_Station(Tostation_name.decode('gbk').encode('utf-8'))
# get_LeftTicket(datetime,from_station,to_station)

StartDate=raw_input('请输入出发日期：')
datetime=StartDate.decode('gbk').encode('utf-8')
FromStation_name=raw_input('请输入始发站：')
from_station=get_Station(FromStation_name)
ToStation_name=raw_input('请输入目的地站：')
to_station=get_Station(ToStation_name)
get_LeftTicket(datetime,from_station,to_station)