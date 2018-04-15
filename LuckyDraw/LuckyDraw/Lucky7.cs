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
    public partial class Lucky7 : Form
    {
       
        public Lucky7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rd = new Random(Guid.NewGuid().GetHashCode());
            listView1.View = View.Details;
            this.listView1.Columns.Add("Red", this.listView1.Width/3*2, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Blue", this.listView1.Width / 3 , HorizontalAlignment.Left);

            ListViewItem list = new  ListViewItem();
            StringBuilder str = new StringBuilder();
            List<int> l = Sort();
            foreach (var item in l)
            {
                str.Append(item + "   ");
            }
            list.Text = str.ToString();
            list.SubItems.Add(rd.Next(1, 16).ToString());
            this.listView1.Items.Add(list);
            
        }

        public List<int> Sort()
        {
            List<int> list = new List<int>();
            Random rd = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < 6; i++)
            {
                list.Add(rd.Next(1, 34));
            }
            list.Sort();
            return list;
        }
    }
}
