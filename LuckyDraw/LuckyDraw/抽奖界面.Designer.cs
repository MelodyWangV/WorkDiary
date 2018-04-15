namespace LuckyDraw
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bt_start = new System.Windows.Forms.Button();
            this.bt_show = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lb_title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // bt_start
            // 
            this.bt_start.Location = new System.Drawing.Point(51, 218);
            this.bt_start.Name = "bt_start";
            this.bt_start.Size = new System.Drawing.Size(75, 23);
            this.bt_start.TabIndex = 1;
            this.bt_start.Text = "开始抽奖";
            this.bt_start.UseVisualStyleBackColor = true;
            this.bt_start.Click += new System.EventHandler(this.bt_start_Click);
            // 
            // bt_show
            // 
            this.bt_show.Location = new System.Drawing.Point(301, 218);
            this.bt_show.Name = "bt_show";
            this.bt_show.Size = new System.Drawing.Size(75, 23);
            this.bt_show.TabIndex = 2;
            this.bt_show.Text = "开奖";
            this.bt_show.UseVisualStyleBackColor = true;
            this.bt_show.Click += new System.EventHandler(this.bt_show_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.Location = new System.Drawing.Point(29, 39);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(373, 150);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lb_title
            // 
            this.lb_title.AutoSize = true;
            this.lb_title.Location = new System.Drawing.Point(177, 13);
            this.lb_title.Name = "lb_title";
            this.lb_title.Size = new System.Drawing.Size(41, 12);
            this.lb_title.TabIndex = 4;
            this.lb_title.Text = "label1";
            this.lb_title.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 253);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_title);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.bt_show);
            this.Controls.Add(this.bt_start);
            this.Name = "FormMain";
            this.Text = "抽奖界面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bt_start;
        private System.Windows.Forms.Button bt_show;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lb_title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer2;
    }
}