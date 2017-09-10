namespace Drawer
{
    using System.Windows.Forms;
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        /// 
        
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.BTFind = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxClassroom = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.listViewResults = new System.Windows.Forms.ListView();
            this.ch1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button6 = new System.Windows.Forms.Button();
            this.buttonMutiplyDraw = new System.Windows.Forms.Button();
            this.TextBoxMutiplyNum = new System.Windows.Forms.TextBox();
            this.button11 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读取数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入照片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.批量导入照片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.批量导入学生ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.班级设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读取设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.高级ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.执行命令ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.安全设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.BTExcCmd = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TBOutput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTFind
            // 
            this.BTFind.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BTFind.Location = new System.Drawing.Point(246, 227);
            this.BTFind.Name = "BTFind";
            this.BTFind.Size = new System.Drawing.Size(92, 51);
            this.BTFind.TabIndex = 3;
            this.BTFind.Text = "查找";
            this.BTFind.UseVisualStyleBackColor = true;
            this.BTFind.Click += new System.EventHandler(this.button4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(373, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(382, 472);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(861, 275);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(210, 236);
            this.textBox1.TabIndex = 11;
            this.textBox1.Visible = false;
            // 
            // TextBoxName
            // 
            this.TextBoxName.Font = new System.Drawing.Font("微软雅黑", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextBoxName.Location = new System.Drawing.Point(125, 35);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(213, 51);
            this.TextBoxName.TabIndex = 12;
            this.TextBoxName.Click += new System.EventHandler(this.textBox2_Click);
            // 
            // textBoxID
            // 
            this.textBoxID.Font = new System.Drawing.Font("微软雅黑", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxID.Location = new System.Drawing.Point(125, 95);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(213, 51);
            this.textBoxID.TabIndex = 13;
            this.textBoxID.Click += new System.EventHandler(this.textBox3_Click);
            // 
            // textBoxClassroom
            // 
            this.textBoxClassroom.Font = new System.Drawing.Font("微软雅黑", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxClassroom.Location = new System.Drawing.Point(125, 155);
            this.textBoxClassroom.Name = "textBoxClassroom";
            this.textBoxClassroom.Size = new System.Drawing.Size(213, 51);
            this.textBoxClassroom.TabIndex = 15;
            this.textBoxClassroom.Click += new System.EventHandler(this.textBox4_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkBox1.Location = new System.Drawing.Point(79, 240);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(170, 27);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(23, 45);
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
            this.label2.Location = new System.Drawing.Point(23, 105);
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
            this.label3.Location = new System.Drawing.Point(23, 165);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 514);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(764, 22);
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "123123123";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // listViewResults
            // 
            this.listViewResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch1,
            this.ch2,
            this.ch3,
            this.ch4,
            this.ch5,
            this.ch6,
            this.ch7,
            this.ch8,
            this.ch9});
            this.listViewResults.FullRowSelect = true;
            this.listViewResults.Location = new System.Drawing.Point(775, 28);
            this.listViewResults.Name = "listViewResults";
            this.listViewResults.Size = new System.Drawing.Size(436, 472);
            this.listViewResults.TabIndex = 23;
            this.listViewResults.UseCompatibleStateImageBehavior = false;
            this.listViewResults.View = System.Windows.Forms.View.Details;
            this.listViewResults.Visible = false;
            this.listViewResults.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listViewResults.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged_1);
            // 
            // ch1
            // 
            this.ch1.Text = "序号";
            this.ch1.Width = 30;
            // 
            // ch2
            // 
            this.ch2.Text = "班级";
            this.ch2.Width = 40;
            // 
            // ch3
            // 
            this.ch3.Text = "姓名";
            // 
            // ch4
            // 
            this.ch4.Text = "学号";
            this.ch4.Width = 80;
            // 
            // ch5
            // 
            this.ch5.Text = "成绩";
            this.ch5.Width = 40;
            // 
            // ch6
            // 
            this.ch6.Text = "默写已抽";
            // 
            // ch7
            // 
            this.ch7.Text = "随机已抽";
            // 
            // ch8
            // 
            this.ch8.Text = "报告已抽";
            // 
            // ch9
            // 
            this.ch9.Text = "报告时间";
            this.ch9.Width = 80;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1217, 427);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(29, 72);
            this.button6.TabIndex = 24;
            this.button6.Text = "<<";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // buttonMutiplyDraw
            // 
            this.buttonMutiplyDraw.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonMutiplyDraw.Location = new System.Drawing.Point(246, 397);
            this.buttonMutiplyDraw.Name = "buttonMutiplyDraw";
            this.buttonMutiplyDraw.Size = new System.Drawing.Size(96, 50);
            this.buttonMutiplyDraw.TabIndex = 28;
            this.buttonMutiplyDraw.Text = "批量抽取";
            this.buttonMutiplyDraw.UseVisualStyleBackColor = true;
            this.buttonMutiplyDraw.Click += new System.EventHandler(this.roll5Init);
            // 
            // TextBoxMutiplyNum
            // 
            this.TextBoxMutiplyNum.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextBoxMutiplyNum.Location = new System.Drawing.Point(324, 461);
            this.TextBoxMutiplyNum.Name = "TextBoxMutiplyNum";
            this.TextBoxMutiplyNum.Size = new System.Drawing.Size(43, 39);
            this.TextBoxMutiplyNum.TabIndex = 29;
            this.TextBoxMutiplyNum.Text = "8";
            // 
            // button11
            // 
            this.button11.Enabled = false;
            this.button11.Location = new System.Drawing.Point(861, 243);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 32;
            this.button11.Text = "清空数据";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Visible = false;
            this.button11.Click += new System.EventHandler(this.buttonDeleteAll_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(246, 461);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(71, 16);
            this.radioButton1.TabIndex = 33;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "每周一问";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(246, 484);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(71, 16);
            this.radioButton2.TabIndex = 34;
            this.radioButton2.Text = "实验报告";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonStart.Location = new System.Drawing.Point(246, 284);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(92, 51);
            this.buttonStart.TabIndex = 35;
            this.buttonStart.Text = "开始";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonStop.Location = new System.Drawing.Point(246, 341);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(92, 51);
            this.buttonStop.TabIndex = 36;
            this.buttonStop.Text = "停止";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.设置ToolStripMenuItem,
            this.高级ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(764, 25);
            this.menuStrip1.TabIndex = 38;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.保存数据ToolStripMenuItem,
            this.读取数据ToolStripMenuItem,
            this.导出数据ToolStripMenuItem,
            this.导入照片ToolStripMenuItem,
            this.批量导入学生ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 保存数据ToolStripMenuItem
            // 
            this.保存数据ToolStripMenuItem.Name = "保存数据ToolStripMenuItem";
            this.保存数据ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.保存数据ToolStripMenuItem.Text = "保存数据";
            this.保存数据ToolStripMenuItem.Click += new System.EventHandler(this.保存数据ToolStripMenuItem_Click);
            // 
            // 读取数据ToolStripMenuItem
            // 
            this.读取数据ToolStripMenuItem.Name = "读取数据ToolStripMenuItem";
            this.读取数据ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.读取数据ToolStripMenuItem.Text = "读取数据";
            this.读取数据ToolStripMenuItem.Click += new System.EventHandler(this.读取数据ToolStripMenuItem_Click);
            // 
            // 导出数据ToolStripMenuItem
            // 
            this.导出数据ToolStripMenuItem.Name = "导出数据ToolStripMenuItem";
            this.导出数据ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.导出数据ToolStripMenuItem.Text = "导出数据";
            this.导出数据ToolStripMenuItem.Click += new System.EventHandler(this.导出数据ToolStripMenuItem_Click);
            // 
            // 导入照片ToolStripMenuItem
            // 
            this.导入照片ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.批量导入照片ToolStripMenuItem});
            this.导入照片ToolStripMenuItem.Name = "导入照片ToolStripMenuItem";
            this.导入照片ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.导入照片ToolStripMenuItem.Text = "导入照片";
            // 
            // 批量导入照片ToolStripMenuItem
            // 
            this.批量导入照片ToolStripMenuItem.Name = "批量导入照片ToolStripMenuItem";
            this.批量导入照片ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.批量导入照片ToolStripMenuItem.Text = "批量导入照片";
            this.批量导入照片ToolStripMenuItem.Click += new System.EventHandler(this.批量导入照片ToolStripMenuItem_Click);
            // 
            // 批量导入学生ToolStripMenuItem
            // 
            this.批量导入学生ToolStripMenuItem.Name = "批量导入学生ToolStripMenuItem";
            this.批量导入学生ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.批量导入学生ToolStripMenuItem.Text = "批量导入学生";
            this.批量导入学生ToolStripMenuItem.Click += new System.EventHandler(this.批量导入学生ToolStripMenuItem_Click);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.班级设置ToolStripMenuItem,
            this.读取设置ToolStripMenuItem,
            this.保存设置ToolStripMenuItem,
            this.导出设置ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 班级设置ToolStripMenuItem
            // 
            this.班级设置ToolStripMenuItem.Name = "班级设置ToolStripMenuItem";
            this.班级设置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.班级设置ToolStripMenuItem.Text = "班级设置";
            this.班级设置ToolStripMenuItem.Click += new System.EventHandler(this.班级设置ToolStripMenuItem_Click);
            // 
            // 读取设置ToolStripMenuItem
            // 
            this.读取设置ToolStripMenuItem.Name = "读取设置ToolStripMenuItem";
            this.读取设置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.读取设置ToolStripMenuItem.Text = "读取设置";
            this.读取设置ToolStripMenuItem.Click += new System.EventHandler(this.读取设置ToolStripMenuItem_Click);
            // 
            // 保存设置ToolStripMenuItem
            // 
            this.保存设置ToolStripMenuItem.Name = "保存设置ToolStripMenuItem";
            this.保存设置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.保存设置ToolStripMenuItem.Text = "保存设置";
            this.保存设置ToolStripMenuItem.Click += new System.EventHandler(this.保存设置ToolStripMenuItem_Click);
            // 
            // 导出设置ToolStripMenuItem
            // 
            this.导出设置ToolStripMenuItem.Name = "导出设置ToolStripMenuItem";
            this.导出设置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.导出设置ToolStripMenuItem.Text = "导出设置";
            this.导出设置ToolStripMenuItem.Click += new System.EventHandler(this.导出设置ToolStripMenuItem_Click);
            // 
            // 高级ToolStripMenuItem
            // 
            this.高级ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.执行命令ToolStripMenuItem,
            this.安全设置ToolStripMenuItem});
            this.高级ToolStripMenuItem.Name = "高级ToolStripMenuItem";
            this.高级ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.高级ToolStripMenuItem.Text = "高级";
            // 
            // 执行命令ToolStripMenuItem
            // 
            this.执行命令ToolStripMenuItem.Name = "执行命令ToolStripMenuItem";
            this.执行命令ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.执行命令ToolStripMenuItem.Text = "执行命令";
            this.执行命令ToolStripMenuItem.Click += new System.EventHandler(this.执行命令ToolStripMenuItem_Click);
            // 
            // 安全设置ToolStripMenuItem
            // 
            this.安全设置ToolStripMenuItem.Name = "安全设置ToolStripMenuItem";
            this.安全设置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.安全设置ToolStripMenuItem.Text = "安全设置";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助ToolStripMenuItem,
            this.关于ToolStripMenuItem1});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "帮助";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.帮助ToolStripMenuItem.Text = "帮助";
            this.帮助ToolStripMenuItem.Click += new System.EventHandler(this.帮助ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem1
            // 
            this.关于ToolStripMenuItem1.Name = "关于ToolStripMenuItem1";
            this.关于ToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.关于ToolStripMenuItem1.Text = "关于";
            // 
            // BTExcCmd
            // 
            this.BTExcCmd.Enabled = false;
            this.BTExcCmd.Location = new System.Drawing.Point(1088, 488);
            this.BTExcCmd.Name = "BTExcCmd";
            this.BTExcCmd.Size = new System.Drawing.Size(75, 23);
            this.BTExcCmd.TabIndex = 39;
            this.BTExcCmd.Text = "执行命令";
            this.BTExcCmd.UseVisualStyleBackColor = true;
            this.BTExcCmd.Visible = false;
            this.BTExcCmd.Click += new System.EventHandler(this.BTExcCmd_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(101, 48);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.修改ToolStripMenuItem.Text = "修改";
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            // 
            // TBOutput
            // 
            this.TBOutput.Location = new System.Drawing.Point(373, 28);
            this.TBOutput.MaxLength = 10000000;
            this.TBOutput.Multiline = true;
            this.TBOutput.Name = "TBOutput";
            this.TBOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TBOutput.Size = new System.Drawing.Size(100, 58);
            this.TBOutput.TabIndex = 40;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 536);
            this.Controls.Add(this.TBOutput);
            this.Controls.Add(this.BTExcCmd);
            this.Controls.Add(this.listViewResults);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.TextBoxMutiplyNum);
            this.Controls.Add(this.buttonMutiplyDraw);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBoxClassroom);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.TextBoxName);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BTFind);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "上课提问";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTFind;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxClassroom;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ListView listViewResults;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button buttonMutiplyDraw;
        private System.Windows.Forms.TextBox TextBoxMutiplyNum;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 读取数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 高级ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 执行命令ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 安全设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem1;
        private System.Windows.Forms.Button BTExcCmd;
        private ColumnHeader ch1;
        private ColumnHeader ch2;
        private ColumnHeader ch3;
        private ColumnHeader ch4;
        private ColumnHeader ch5;
        private ColumnHeader ch6;
        private ColumnHeader ch7;
        private ColumnHeader ch8;
        private ColumnHeader ch9;
        private ToolStripMenuItem 导入照片ToolStripMenuItem;
        private ToolStripMenuItem 批量导入照片ToolStripMenuItem;
        private ToolStripMenuItem 批量导入学生ToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem 修改ToolStripMenuItem;
        private ToolStripMenuItem 删除ToolStripMenuItem;
        private TextBox TBOutput;
        private ToolStripMenuItem 设置ToolStripMenuItem;
        private ToolStripMenuItem 班级设置ToolStripMenuItem;
        private ToolStripMenuItem 读取设置ToolStripMenuItem;
        private ToolStripMenuItem 保存设置ToolStripMenuItem;
        private ToolStripMenuItem 导出设置ToolStripMenuItem;
    }
}

