using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuckyDraw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bt_start_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain();
            formMain.Show();
        }

        private void 导入抽奖名单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AwardsInfoAdd awardsInfoForm = new AwardsInfoAdd();
            awardsInfoForm.Show();
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectInfo selectInfo = new SelectInfo();
            selectInfo.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lucky7 l = new Lucky7();
            l.Show(this);
        }
    }
}
