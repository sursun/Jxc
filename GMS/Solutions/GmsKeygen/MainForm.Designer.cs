namespace GmsKeygen
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtLifeStart = new System.Windows.Forms.DateTimePicker();
            this.dtImportStart = new System.Windows.Forms.DateTimePicker();
            this.dtImportEnd = new System.Windows.Forms.DateTimePicker();
            this.dtLifeEnd = new System.Windows.Forms.DateTimePicker();
            this.textBoxSn = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxCompanyName = new System.Windows.Forms.TextBox();
            this.textBoxCompanyCode = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "目标机序列号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "产品有效期";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "至";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(364, 247);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 7;
            this.btnGenerate.Text = "生成注册码";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "注册码使用时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "至";
            // 
            // dtLifeStart
            // 
            this.dtLifeStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtLifeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtLifeStart.Location = new System.Drawing.Point(106, 124);
            this.dtLifeStart.Name = "dtLifeStart";
            this.dtLifeStart.Size = new System.Drawing.Size(152, 21);
            this.dtLifeStart.TabIndex = 3;
            this.dtLifeStart.ValueChanged += new System.EventHandler(this.dtLifeStart_ValueChanged);
            // 
            // dtImportStart
            // 
            this.dtImportStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtImportStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtImportStart.Location = new System.Drawing.Point(106, 206);
            this.dtImportStart.Name = "dtImportStart";
            this.dtImportStart.Size = new System.Drawing.Size(152, 21);
            this.dtImportStart.TabIndex = 5;
            // 
            // dtImportEnd
            // 
            this.dtImportEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtImportEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtImportEnd.Location = new System.Drawing.Point(287, 206);
            this.dtImportEnd.Name = "dtImportEnd";
            this.dtImportEnd.Size = new System.Drawing.Size(152, 21);
            this.dtImportEnd.TabIndex = 6;
            this.dtImportEnd.ValueChanged += new System.EventHandler(this.dtImportEnd_ValueChanged);
            // 
            // dtLifeEnd
            // 
            this.dtLifeEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtLifeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtLifeEnd.Location = new System.Drawing.Point(287, 124);
            this.dtLifeEnd.Name = "dtLifeEnd";
            this.dtLifeEnd.Size = new System.Drawing.Size(152, 21);
            this.dtLifeEnd.TabIndex = 4;
            this.dtLifeEnd.ValueChanged += new System.EventHandler(this.dtLifeEnd_ValueChanged);
            // 
            // textBoxSn
            // 
            this.textBoxSn.Location = new System.Drawing.Point(108, 81);
            this.textBoxSn.Name = "textBoxSn";
            this.textBoxSn.Size = new System.Drawing.Size(192, 21);
            this.textBoxSn.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "公司名称";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "单位编号";
            // 
            // textBoxCompanyName
            // 
            this.textBoxCompanyName.Location = new System.Drawing.Point(108, 45);
            this.textBoxCompanyName.Name = "textBoxCompanyName";
            this.textBoxCompanyName.Size = new System.Drawing.Size(192, 21);
            this.textBoxCompanyName.TabIndex = 1;
            // 
            // textBoxCompanyCode
            // 
            this.textBoxCompanyCode.Location = new System.Drawing.Point(108, 12);
            this.textBoxCompanyCode.Name = "textBoxCompanyCode";
            this.textBoxCompanyCode.Size = new System.Drawing.Size(100, 21);
            this.textBoxCompanyCode.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pictureBox1.Location = new System.Drawing.Point(12, 171);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(427, 2);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 288);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBoxCompanyCode);
            this.Controls.Add(this.textBoxCompanyName);
            this.Controls.Add(this.textBoxSn);
            this.Controls.Add(this.dtLifeEnd);
            this.Controls.Add(this.dtImportEnd);
            this.Controls.Add(this.dtImportStart);
            this.Controls.Add(this.dtLifeStart);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注册码生成器";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtLifeStart;
        private System.Windows.Forms.DateTimePicker dtImportStart;
        private System.Windows.Forms.DateTimePicker dtImportEnd;
        private System.Windows.Forms.DateTimePicker dtLifeEnd;
        private System.Windows.Forms.TextBox textBoxSn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxCompanyName;
        private System.Windows.Forms.TextBox textBoxCompanyCode;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}

