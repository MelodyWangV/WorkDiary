using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LuckyDraw
{
    public partial class FormMain : Form
    {
        //ReadExcel excel = new ReadExcel();
        AwardsInfo info = new AwardsInfo();
        List<AwardsInfo> awardInfos = new List<AwardsInfo>();
        string currentPath = System.AppDomain.CurrentDomain.BaseDirectory + "AwardInfos.cofig";
        
        //应抽奖的奖项顺序
        int bt_count = 1;
        //每个奖项的人数
        int awardsNum = 1;
        //单次抽奖个数
        int awardSingleNum = 1;
        //已抽出奖项个数
        int showNum = 0;

        StringBuilder name = new StringBuilder();

        public FormMain()
        {
            InitializeComponent();
            if (AwardsInfo.InfoData == null)
            {
                Thread thread = new Thread(InitializeAwardsInfo);
                thread.IsBackground = true;
                thread.Start();
                this.lb_title.Visible = true;
                this.bt_start.Enabled = false;
                this.lb_title.Text = "正在加载抽奖数据!";
            }
            this.bt_show.Enabled = false;
            //
        }

        private void InitializeAwardsInfo()
        {
           
            AwardsInfo.InfoData = ReadExcel.GetSheetNames(System.AppDomain.CurrentDomain.BaseDirectory + "temp.xlsx");
        
            FormShow();
        }

        delegate void FormDelegat();
        private void FormShow()
        {
            
            if (this.bt_start.InvokeRequired)
            {
                Invoke(new FormDelegat(FormShow));
            }
            else
            {
                this.lb_title.Text = "";
                this.bt_start.Enabled = true;
                
            }
        }

        private void bt_start_Click(object sender, EventArgs e)
        {
           
            getAwardsInfo();

            try
            {
                
                this.lb_title.Text = awardInfos.Find(a => a.Index == bt_count).AwardsName;
                this.lb_title.Visible = true;
                awardsNum = awardInfos.Find(a => a.Index == bt_count).AwardsNum;
                awardSingleNum = awardInfos.Find(a => a.Index == bt_count).SingleNum;
                //初始化 默认每行显示三个
                listView1.View = View.Details;
                for (int i = 0; i < 3; i++)
                {
                    this.listView1.Columns.Add("", this.listView1.Width/3, HorizontalAlignment.Center);
                }
                timer1.Start();
                //for (int i = 0; i < awardsNum/3.0; i++)
                //{
                //    timer1.Start();
                //}  
                this.bt_start.Enabled = false;
                this.bt_show.Enabled = true;
            }
            catch
            {
               MessageBox.Show("所有奖项已全部抽完！");
            }
 
            
        }

        public void getAwardsInfo()
        {
            XDocument myXDoc = XDocument.Load(currentPath);
            IEnumerable<XElement> elements = from e in myXDoc.Elements("InfoList").Elements("AwardsInfo")
                                             //where e.Elements("Index").Value==index.ToString()
                                             select e;
            if (elements.Count() > 0)
            {
                foreach (var item in elements)
                {
                    AwardsInfo info = new AwardsInfo();
                    info.Index =Convert.ToInt32(item.Attribute("Index").Value);
                    info.AwardsName = item.Element("AwardsName").Value.ToString();
                    info.AwardsNum =Convert.ToInt32(item.Element("AwardsNum").Value);
                    info.SingleNum = Convert.ToInt32(item.Element("SingleNum").Value);
                    awardInfos.Add(info);
                }
            }
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
            Random rd = new Random(Guid.NewGuid().GetHashCode());
           
            //确定能填满3列的行数；
            for (int i = 0; i < awardSingleNum/3; i++)
            {
                ListViewItem liv = new ListViewItem();
                liv.Text = AwardsInfo.InfoData.Rows[rd.Next(AwardsInfo.InfoData.Rows.Count)][0].ToString();
                liv.SubItems.Add(AwardsInfo.InfoData.Rows[rd.Next(AwardsInfo.InfoData.Rows.Count)][0].ToString());
                liv.SubItems.Add(AwardsInfo.InfoData.Rows[rd.Next(AwardsInfo.InfoData.Rows.Count)][0].ToString());
                this.listView1.Items.Add(liv);
            }
            ListViewItem liv1 = new ListViewItem();
            //判断除以3后的余数
            if (awardSingleNum % 3 > 0)
            {
                if (awardSingleNum % 3 == 2)
                {

                    liv1.SubItems.Add(AwardsInfo.InfoData.Rows[rd.Next(AwardsInfo.InfoData.Rows.Count)][0].ToString());

                }
                liv1.Text = AwardsInfo.InfoData.Rows[rd.Next(AwardsInfo.InfoData.Rows.Count)][0].ToString();
                this.listView1.Items.Add(liv1);
            }
        }

        private void bt_show_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
           
            name.Append(this.lb_title.Text + ":");
            foreach (ListViewItem item in listView1.Items)
            {
                for (int i = 0; i < item.SubItems.Count; i++)
                {
                    name.Append(item.SubItems[i].Text +" ");
                }
               
            }
            //每个奖项里面已经抽出的奖项个数
            showNum += awardSingleNum;
            //如果已经抽出的奖项个数超过该奖项的总数
            //bt_count+1，awardsinfo信息更新到下一个奖项
            //同时将已抽出的奖项个数置为0；
            if (showNum >= awardsNum)
            {
                bt_count += 1;
                showNum = 0;
            }
            this.label1.Text=name.ToString();
            this.label1.Visible = true;
            timer2.Start();
            this.bt_start.Enabled = true;
            this.bt_show.Enabled = false;
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            this.label1.Left -= 2;
            if (label1.Right < 0)
            {
                label1.Left = this.Width;
            }
        }
    }
}
