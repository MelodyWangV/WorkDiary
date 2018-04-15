namespace LuckyDraw
{
    partial class AwardsInfoAdd
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bt_save = new System.Windows.Forms.Button();
            this.column_Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_AwardsNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_selectNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.CausesValidation = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_Index,
            this.Column_Name,
            this.Column_AwardsNum,
            this.Column_selectNum});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(17, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(379, 161);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            // 
            // bt_save
            // 
            this.bt_save.Location = new System.Drawing.Point(134, 194);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(113, 23);
            this.bt_save.TabIndex = 1;
            this.bt_save.Text = "保存奖项设置";
            this.bt_save.UseVisualStyleBackColor = true;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // column_Index
            // 
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.column_Index.DefaultCellStyle = dataGridViewCellStyle1;
            this.column_Index.HeaderText = "抽奖顺序";
            this.column_Index.Name = "column_Index";
            this.column_Index.ReadOnly = true;
            // 
            // Column_Name
            // 
            this.Column_Name.HeaderText = "奖项名称";
            this.Column_Name.Name = "Column_Name";
            // 
            // Column_AwardsNum
            // 
            dataGridViewCellStyle2.Format = "N0";
            this.Column_AwardsNum.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column_AwardsNum.HeaderText = "获奖人数";
            this.Column_AwardsNum.Name = "Column_AwardsNum";
            // 
            // Column_selectNum
            // 
            dataGridViewCellStyle3.Format = "N2";
            this.Column_selectNum.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column_selectNum.HeaderText = "每次抽奖人数";
            this.Column_selectNum.Name = "Column_selectNum";
            // 
            // AwardsInfoAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(449, 229);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AwardsInfoAdd";
            this.Text = "奖项设置";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_AwardsNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_selectNum;
    }
}