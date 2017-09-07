namespace WindowsFormsApplication1
{
    partial class Form1
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
                        this.components = new System.ComponentModel.Container();
                        this.button1 = new System.Windows.Forms.Button();
                        this.button2 = new System.Windows.Forms.Button();
                        this.button3 = new System.Windows.Forms.Button();
                        this.button4 = new System.Windows.Forms.Button();
                        this.pictureBox1 = new System.Windows.Forms.PictureBox();
                        this.timer1 = new System.Windows.Forms.Timer(this.components);
                        this.textBox1 = new System.Windows.Forms.TextBox();
                        this.textBox2 = new System.Windows.Forms.TextBox();
                        this.textBox3 = new System.Windows.Forms.TextBox();
                        this.textBox4 = new System.Windows.Forms.TextBox();
                        this.checkBox1 = new System.Windows.Forms.CheckBox();
                        this.label1 = new System.Windows.Forms.Label();
                        this.label2 = new System.Windows.Forms.Label();
                        this.label3 = new System.Windows.Forms.Label();
                        this.statusStrip1 = new System.Windows.Forms.StatusStrip();
                        this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
                        this.listView1 = new System.Windows.Forms.ListView();
                        this.button6 = new System.Windows.Forms.Button();
                        this.button5 = new System.Windows.Forms.Button();
                        this.button8 = new System.Windows.Forms.Button();
                        this.button7 = new System.Windows.Forms.Button();
                        this.textBox5 = new System.Windows.Forms.TextBox();
                        this.button9 = new System.Windows.Forms.Button();
                        this.button10 = new System.Windows.Forms.Button();
                        this.button11 = new System.Windows.Forms.Button();
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
                        this.statusStrip1.SuspendLayout();
                        this.SuspendLayout();
                        // 
                        // button1
                        // 
                        this.button1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        this.button1.Location = new System.Drawing.Point(34, 286);
                        this.button1.Name = "button1";
                        this.button1.Size = new System.Drawing.Size(104, 69);
                        this.button1.TabIndex = 0;
                        this.button1.Text = "准备";
                        this.button1.UseVisualStyleBackColor = true;
                        this.button1.Visible = false;
                        this.button1.Click += new System.EventHandler(this.button1_Click);
                        // 
                        // button2
                        // 
                        this.button2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        this.button2.Location = new System.Drawing.Point(34, 374);
                        this.button2.Name = "button2";
                        this.button2.Size = new System.Drawing.Size(104, 69);
                        this.button2.TabIndex = 1;
                        this.button2.Text = "开始";
                        this.button2.UseVisualStyleBackColor = true;
                        this.button2.Click += new System.EventHandler(this.button2_Click);
                        // 
                        // button3
                        // 
                        this.button3.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        this.button3.Location = new System.Drawing.Point(34, 468);
                        this.button3.Name = "button3";
                        this.button3.Size = new System.Drawing.Size(107, 69);
                        this.button3.TabIndex = 2;
                        this.button3.Text = "停止";
                        this.button3.UseVisualStyleBackColor = true;
                        this.button3.Click += new System.EventHandler(this.button3_Click);
                        // 
                        // button4
                        // 
                        this.button4.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        this.button4.Location = new System.Drawing.Point(416, 198);
                        this.button4.Name = "button4";
                        this.button4.Size = new System.Drawing.Size(92, 51);
                        this.button4.TabIndex = 3;
                        this.button4.Text = "查找";
                        this.button4.UseVisualStyleBackColor = true;
                        this.button4.Click += new System.EventHandler(this.button4_Click);
                        // 
                        // pictureBox1
                        // 
                        this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        this.pictureBox1.Location = new System.Drawing.Point(530, 39);
                        this.pictureBox1.Name = "pictureBox1";
                        this.pictureBox1.Size = new System.Drawing.Size(382, 472);
                        this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                        this.pictureBox1.TabIndex = 5;
                        this.pictureBox1.TabStop = false;
                        this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
                        // 
                        // timer1
                        // 
                        this.timer1.Interval = 1;
                        this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
                        // 
                        // textBox1
                        // 
                        this.textBox1.Enabled = false;
                        this.textBox1.Location = new System.Drawing.Point(974, 275);
                        this.textBox1.Multiline = true;
                        this.textBox1.Name = "textBox1";
                        this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
                        this.textBox1.Size = new System.Drawing.Size(210, 236);
                        this.textBox1.TabIndex = 11;
                        this.textBox1.Visible = false;
                        // 
                        // textBox2
                        // 
                        this.textBox2.Font = new System.Drawing.Font("微软雅黑", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        this.textBox2.Location = new System.Drawing.Point(172, 61);
                        this.textBox2.Name = "textBox2";
                        this.textBox2.Size = new System.Drawing.Size(213, 51);
                        this.textBox2.TabIndex = 12;
                        this.textBox2.Click += new System.EventHandler(this.textBox2_Click);
                        // 
                        // textBox3
                        // 
                        this.textBox3.Font = new System.Drawing.Font("微软雅黑", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        this.textBox3.Location = new System.Drawing.Point(172, 130);
                        this.textBox3.Name = "textBox3";
                        this.textBox3.Size = new System.Drawing.Size(213, 51);
                        this.textBox3.TabIndex = 13;
                        this.textBox3.Click += new System.EventHandler(this.textBox3_Click);
                        // 
                        // textBox4
                        // 
                        this.textBox4.Font = new System.Drawing.Font("微软雅黑", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        this.textBox4.Location = new System.Drawing.Point(172, 198);
                        this.textBox4.Name = "textBox4";
                        this.textBox4.Size = new System.Drawing.Size(213, 51);
                        this.textBox4.TabIndex = 15;
                        this.textBox4.Click += new System.EventHandler(this.textBox4_Click);
                        // 
                        // checkBox1
                        // 
                        this.checkBox1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        this.checkBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                        this.checkBox1.Location = new System.Drawing.Point(205, 286);
                        this.checkBox1.Name = "checkBox1";
                        this.checkBox1.Size = new System.Drawing.Size(132, 27);
                        this.checkBox1.TabIndex = 16;
                        this.checkBox1.Text = "checkBox1";
                        this.checkBox1.UseVisualStyleBackColor = true;
                        this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
                        // 
                        // label1
                        // 
                        this.label1.AutoSize = true;
                        this.label1.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        this.label1.Location = new System.Drawing.Point(56, 71);
                        this.label1.Name = "label1";
                        this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        this.label1.Size = new System.Drawing.Size(69, 35);
                        this.label1.TabIndex = 17;
                        this.label1.Text = "姓名";
                        // 
                        // label2
                        // 
                        this.label2.AutoSize = true;
                        this.label2.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        this.label2.Location = new System.Drawing.Point(56, 140);
                        this.label2.Name = "label2";
                        this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        this.label2.Size = new System.Drawing.Size(69, 35);
                        this.label2.TabIndex = 18;
                        this.label2.Text = "学号";
                        // 
                        // label3
                        // 
                        this.label3.AutoSize = true;
                        this.label3.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        this.label3.Location = new System.Drawing.Point(56, 208);
                        this.label3.Name = "label3";
                        this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
                        this.label3.Size = new System.Drawing.Size(69, 35);
                        this.label3.TabIndex = 19;
                        this.label3.Text = "班级";
                        // 
                        // statusStrip1
                        // 
                        this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
                        this.statusStrip1.Location = new System.Drawing.Point(0, 641);
                        this.statusStrip1.Name = "statusStrip1";
                        this.statusStrip1.Size = new System.Drawing.Size(947, 22);
                        this.statusStrip1.TabIndex = 20;
                        this.statusStrip1.Text = "123123123";
                        this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
                        // 
                        // toolStripStatusLabel1
                        // 
                        this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
                        this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
                        // 
                        // listView1
                        // 
                        this.listView1.Location = new System.Drawing.Point(18, 255);
                        this.listView1.Name = "listView1";
                        this.listView1.Size = new System.Drawing.Size(490, 359);
                        this.listView1.TabIndex = 23;
                        this.listView1.UseCompatibleStateImageBehavior = false;
                        this.listView1.View = System.Windows.Forms.View.Details;
                        this.listView1.Visible = false;
                        this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged_1);
                        // 
                        // button6
                        // 
                        this.button6.Location = new System.Drawing.Point(514, 585);
                        this.button6.Name = "button6";
                        this.button6.Size = new System.Drawing.Size(48, 28);
                        this.button6.TabIndex = 24;
                        this.button6.Text = "返回";
                        this.button6.UseVisualStyleBackColor = true;
                        this.button6.Visible = false;
                        this.button6.Click += new System.EventHandler(this.button6_Click);
                        // 
                        // button5
                        // 
                        this.button5.Location = new System.Drawing.Point(620, 532);
                        this.button5.Name = "button5";
                        this.button5.Size = new System.Drawing.Size(75, 23);
                        this.button5.TabIndex = 25;
                        this.button5.Text = "写入数据";
                        this.button5.UseVisualStyleBackColor = true;
                        this.button5.Click += new System.EventHandler(this.button5_Click_1);
                        // 
                        // button8
                        // 
                        this.button8.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        this.button8.Location = new System.Drawing.Point(34, 286);
                        this.button8.Name = "button8";
                        this.button8.Size = new System.Drawing.Size(104, 69);
                        this.button8.TabIndex = 27;
                        this.button8.Text = "准备2";
                        this.button8.UseVisualStyleBackColor = true;
                        this.button8.Click += new System.EventHandler(this.button8_Click);
                        // 
                        // button7
                        // 
                        this.button7.Location = new System.Drawing.Point(709, 571);
                        this.button7.Name = "button7";
                        this.button7.Size = new System.Drawing.Size(75, 23);
                        this.button7.TabIndex = 28;
                        this.button7.Text = "批量抽取";
                        this.button7.UseVisualStyleBackColor = true;
                        this.button7.Click += new System.EventHandler(this.button7_Click);
                        // 
                        // textBox5
                        // 
                        this.textBox5.Location = new System.Drawing.Point(620, 571);
                        this.textBox5.Name = "textBox5";
                        this.textBox5.Size = new System.Drawing.Size(75, 21);
                        this.textBox5.TabIndex = 29;
                        this.textBox5.Text = "8";
                        this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
                        // 
                        // button9
                        // 
                        this.button9.Location = new System.Drawing.Point(799, 532);
                        this.button9.Name = "button9";
                        this.button9.Size = new System.Drawing.Size(75, 23);
                        this.button9.TabIndex = 30;
                        this.button9.Text = "执行命令";
                        this.button9.UseVisualStyleBackColor = true;
                        this.button9.Click += new System.EventHandler(this.button9_Click);
                        // 
                        // button10
                        // 
                        this.button10.Location = new System.Drawing.Point(709, 532);
                        this.button10.Name = "button10";
                        this.button10.Size = new System.Drawing.Size(75, 23);
                        this.button10.TabIndex = 31;
                        this.button10.Text = "导出数据";
                        this.button10.UseVisualStyleBackColor = true;
                        this.button10.Click += new System.EventHandler(this.button10_Click);
                        // 
                        // button11
                        // 
                        this.button11.Enabled = false;
                        this.button11.Location = new System.Drawing.Point(974, 243);
                        this.button11.Name = "button11";
                        this.button11.Size = new System.Drawing.Size(75, 23);
                        this.button11.TabIndex = 32;
                        this.button11.Text = "清空数据";
                        this.button11.UseVisualStyleBackColor = true;
                        this.button11.Visible = false;
                        this.button11.Click += new System.EventHandler(this.button11_Click);
                        // 
                        // Form1
                        // 
                        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                        this.ClientSize = new System.Drawing.Size(947, 663);
                        this.Controls.Add(this.listView1);
                        this.Controls.Add(this.button11);
                        this.Controls.Add(this.button10);
                        this.Controls.Add(this.button9);
                        this.Controls.Add(this.textBox5);
                        this.Controls.Add(this.button7);
                        this.Controls.Add(this.button8);
                        this.Controls.Add(this.button5);
                        this.Controls.Add(this.button6);
                        this.Controls.Add(this.statusStrip1);
                        this.Controls.Add(this.label3);
                        this.Controls.Add(this.label2);
                        this.Controls.Add(this.label1);
                        this.Controls.Add(this.checkBox1);
                        this.Controls.Add(this.textBox4);
                        this.Controls.Add(this.textBox3);
                        this.Controls.Add(this.textBox2);
                        this.Controls.Add(this.textBox1);
                        this.Controls.Add(this.pictureBox1);
                        this.Controls.Add(this.button4);
                        this.Controls.Add(this.button3);
                        this.Controls.Add(this.button2);
                        this.Controls.Add(this.button1);
                        this.Name = "Form1";
                        this.Text = "Form1";
                        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
                        this.Load += new System.EventHandler(this.Form1_Load);
                        ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
                        this.statusStrip1.ResumeLayout(false);
                        this.statusStrip1.PerformLayout();
                        this.ResumeLayout(false);
                        this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
    }
}

