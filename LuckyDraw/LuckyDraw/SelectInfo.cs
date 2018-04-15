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

namespace LuckyDraw
{
    public partial class SelectInfo : Form
    {
        DataTable dt = new DataTable();
        ReadExcel rexcel = new ReadExcel();
        string excelPath = "";
        public SelectInfo()
        {
            InitializeComponent();
           
        }

        private void excel导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Excel文件|*.xls;*.xlsx";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                 excelPath =fileDialog.FileName.ToString();
                //禁止自动生成列
                this.dataGridView1.AutoGenerateColumns = false;
                //this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dt= ReadExcel.GetSheetNames(excelPath);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].DataPropertyName = dt.Columns[0].ToString();
                dataGridView1.Columns[1].DataPropertyName = dt.Columns[1].ToString();
                dataGridView1.Columns[2].DataPropertyName = dt.Columns[2].ToString();

            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AwardsInfo.InfoData = dt;
            FileInfo file = new FileInfo(excelPath);
            file.CopyTo(System.AppDomain.CurrentDomain.BaseDirectory+"temp.xlsx", true);

            MessageBox.Show("人员信息保存成功");
            this.Close();
        }
    }
}
