using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LuckyDraw
{
    public partial class AwardsInfoAdd : Form
    {
        string currentPath = System.AppDomain.CurrentDomain.BaseDirectory+ "AwardInfos.cofig";

        List<AwardsInfo> listInfos = new List<AwardsInfo>();
        public AwardsInfoAdd()
        {
            InitializeComponent();
            //读取已经设置好的奖项信息
            
            this.dataGridView1.Rows[0].Cells[0].Value = "1";
            this.dataGridView1.Rows[0].Cells[0].ReadOnly = true;
            

        }

        private void bt_save_Click(object sender, EventArgs e)
        {
            if (File.Exists(currentPath))
            {
                File.Delete(currentPath);
            }

            XElement xe = new XElement(
                    new XElement("InfoList", ""));
            xe.Save(currentPath);
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    
                    AwardsInfo info = new AwardsInfo();
                    info.Index = Convert.ToInt32(dataGridView1.Rows[i].Cells["column_Index"].EditedFormattedValue);
                    info.AwardsName = dataGridView1.Rows[i].Cells["Column_Name"].EditedFormattedValue.ToString();
                    info.AwardsNum = Convert.ToInt32(dataGridView1.Rows[i].Cells["Column_AwardsNum"].EditedFormattedValue.ToString());
                    info.SingleNum = Convert.ToInt32(dataGridView1.Rows[i].Cells["Column_selectNum"].EditedFormattedValue.ToString());
                    listInfos.Add(info);
                }

                if (dataGridView1.Rows.Count == 1)
                {
                    MessageBox.Show("请设置完整奖项信息");
                }
                else
                {
                    SaveInfo(listInfos);
                    MessageBox.Show("奖项已设置");
                    this.Close();
                }
            }
            catch (Exception )
            {
                MessageBox.Show("请检查数据");
            }

        }

        public void SaveInfo(List<AwardsInfo> infos)
        {
   
            XDocument myXDoc = XDocument.Load(currentPath);
    
            IEnumerable<XElement> elements;
            elements = from e in myXDoc.Elements("InfoList")
                       select e;
            foreach (var item in infos)
            {
                if (elements.Count() > 0)
                {
                    foreach (var ele in elements)
                    {
                        ele.Add(
                            new XElement("AwardsInfo",
                            new XAttribute("Index", item.Index),
                            new XElement("AwardsName",item.AwardsName),
                            new XElement("AwardsNum", item.AwardsNum),
                            new XElement("SingleNum",item.SingleNum)
                                         )
                                   );
                    }
                }
                myXDoc.Save(currentPath);
            }
        }

       
       

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            if (e.ColumnIndex == 0 || e.ColumnIndex == 3|| e.ColumnIndex == 2)
            {
                try
                {
                     int  val = int.Parse(e.FormattedValue.ToString());
                
                }
                catch (Exception )
                {
                    int index = Convert.ToInt32(e.ColumnIndex) + 1;
                    MessageBox.Show("第"+index+ "列只能输入整数 ");
                    /*将焦点留在此单元格内，保证数据类型正确性
                    但造成问题时，关闭窗口的时候也会弹出校验
                    解决办法是，将此窗体和控件的属性
                    CausesValidation=false
                     */
                    e.Cancel = true;
                    
                }
            }
        }

       

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.dataGridView1.Rows[e.RowIndex].Cells[0].Value = Convert.ToInt32(e.RowIndex)+1;
            }
        }
    }
}
