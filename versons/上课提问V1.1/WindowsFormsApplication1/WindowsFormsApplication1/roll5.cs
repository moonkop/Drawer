using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
        public partial class roll5 : Form
        {

                public int[][] l = new int[100][];
                Form1 obj;
                public TextBox[][] tb = new TextBox[100][];
                public PictureBox[] pb = new PictureBox[30];
                public Button[] bt = new Button[30];
                Timer timer2 = new Timer();
                Timer timer1 = new Timer();
                public int rollnum;
                private int currentPointer;
                public Student[] stdNamed = new Student[30];
                public bool saved = true;
                public roll5(Form1 obj1, int nums)
                {
                        InitializeComponent();
                        obj = obj1;
                        rollnum = nums;

                        timer1.Tick += new EventHandler(timer1_Tick);
                        timer1.Interval = 3000;
                        timer1.Enabled = true;

                        timer2.Tick += new EventHandler(timer2_Tick);
                        timer2.Interval = obj.timer1.Interval;

                }

                void timer2_Tick(object sender, EventArgs e)
                {
                        showdata(obj.stdSelected[obj.zjz], currentPointer);

                }
                void showdata(Student std, int pointer)
                {
                        tb[pointer][1].Text = std.num;
                        tb[pointer][2].Text = std.name + "  " + std.classroom.classID;

                        try
                        {
                                pb[pointer].Load(obj.PicPath + std.num + ".jpg");
                        }
                        catch (Exception)
                        { }

                }

                void timer1_Tick(object sender, EventArgs e)
                {
                        obj.button3_Click(null, EventArgs.Empty);

                        while (obj.ready != true)
                        {
                        }
                        stdNamed[currentPointer] = obj.stdSelected[obj.zjz];
                        //stdNamed[currentPointer].selected = false;

                        showdata(stdNamed[currentPointer], currentPointer);


                        currentPointer++;
                        if (currentPointer > rollnum)
                        {
                                timer1.Enabled = false;
                                timer2.Enabled = false;
                        }
                        else
                        {
                                obj.button2_Click(null, EventArgs.Empty);
                        }

                }

                private void loadConfig()
                {

                }
                private void Form2_Load(object sender, EventArgs e)
                {
                        int i;
                        int rNumsForEachLine = int.Parse(Form1.processConfig(Form1.ConfigPath, "rNumsForEachLine"));
                        timer1.Interval = int.Parse(Form1.processConfig(Form1.ConfigPath, "bigTimerInterval"));
                        int rWidthForEach = int.Parse(Form1.processConfig(Form1.ConfigPath, "rWidthForEach"));
                        int rXBlankspace = int.Parse(Form1.processConfig(Form1.ConfigPath, "rXBlankspace"));
                        int rTextboxheight = int.Parse(Form1.processConfig(Form1.ConfigPath, "rTextboxheight"));
                        int rPictureboxHeight = int.Parse(Form1.processConfig(Form1.ConfigPath, "rPictureboxHeight"));
                        int rCommandHeight = int.Parse(Form1.processConfig(Form1.ConfigPath, "rCommandHeight"));
                        int yTextboxBlankSpace = int.Parse(Form1.processConfig(Form1.ConfigPath, "yTextboxBlankSpace"));
                        button0.Width = rWidthForEach;
                        pictureBox0.Width = rWidthForEach;
                        textBox0.Width = rWidthForEach;
                        textBox0.Height = rTextboxheight;
                        pictureBox0.Height = rPictureboxHeight;
                        button0.Height = rCommandHeight;
                        pictureBox0.Left -= rWidthForEach + rXBlankspace;
                        pictureBox0.Visible = false;
                        textBox0.Top = pictureBox0.Top + rPictureboxHeight - rTextboxheight;
                        textBox0.Visible = false;
                        button0.Top = pictureBox0.Top + rPictureboxHeight + rTextboxheight * 3 + 5 * yTextboxBlankSpace;
                        button0.Left -= rWidthForEach + rXBlankspace;
                        button0.Visible = false;

                        pb[0] = pictureBox0;
                        bt[0] = button0;
                        for (int k = 1; k <= rollnum; k++)
                        {
                                tb[k] = new TextBox[4];
                        }

                        tb[1][0] = textBox0;

                        for (i = 1; i <= rollnum; i++)
                        {
                                pb[i] = new PictureBox();
                                clone(pb[i], pictureBox0);
                                pb[i].BorderStyle = BorderStyle.FixedSingle;
                                bt[i] = new Button();
                                clone(bt[i], bt[0]);

                                if ((i - 1) % rNumsForEachLine != 0 || i == 1)
                                {
                                        pb[i].Left = pb[i - 1].Left + rWidthForEach + rXBlankspace;
                                        pb[i].Top = pb[i - 1].Top;
                                        pb[i].Visible = true;

                                        this.Controls.Add(pb[i]);

                                        bt[i].Left = bt[i - 1].Left + rWidthForEach + rXBlankspace;
                                        bt[i].Top = bt[i - 1].Top;
                                        bt[i].Visible = false;
                                        this.Controls.Add(bt[i]);

                                        for (int j = 1; j <= 3; j++)
                                        {
                                                tb[i][j] = new TextBox();
                                                clone(tb[i][j], tb[1][0]);

                                                if (j == 1 && i != 1)
                                                {

                                                        tb[i][j].Top = tb[i - 1][j].Top;
                                                        tb[i][j].Left = tb[i - 1][j].Left + rWidthForEach + rXBlankspace;
                                                        tb[i][j].Visible = true;
                                                        this.Controls.Add(tb[i][j]);

                                                }
                                                else
                                                {
                                                        tb[i][j].Top = tb[i][j - 1].Top + rTextboxheight + yTextboxBlankSpace;
                                                        tb[i][j].Left = tb[i][j - 1].Left;
                                                        this.Controls.Add(tb[i][j]);
                                                }
                                                //tb[i][j].Text = i.ToString() + " , " + j.ToString();
                                        }
                                }
                                else
                                {
                                        pb[i].Top = pb[i - rNumsForEachLine].Top + pb[i - rNumsForEachLine].Height + 3 * rTextboxheight + 5 * yTextboxBlankSpace;
                                        pb[i].Left = pb[i - rNumsForEachLine].Left;
                                        pb[i].Height = rPictureboxHeight;
                                        pb[i].Width = rWidthForEach;
                                        pb[i].Visible = true;
                                        this.Controls.Add(pb[i]);
                                        tb[i][1] = new TextBox();
                                        clone(tb[i][1], tb[1][0]);
                                        tb[i][1].Left = tb[1][1].Left;
                                        tb[i][1].Top = pb[i].Top + rPictureboxHeight + yTextboxBlankSpace;
                                        tb[i][1].Width = rWidthForEach;
                                        tb[i][1].Height = rTextboxheight;
                                        tb[i][1].Visible = true;
                                        this.Controls.Add(tb[i][1]);

                                        for (int t = 2; t <= 3; t++)
                                        {
                                                tb[i][t] = new TextBox();
                                                clone(tb[i][t], tb[1][0]);
                                                tb[i][t].Top = tb[i][t - 1].Top + rTextboxheight + yTextboxBlankSpace;
                                                tb[i][t].Left = tb[i][t - 1].Left;
                                                tb[i][t].Visible = true;
                                                this.Controls.Add(tb[i][t]);
                                        }
                                        bt[i].Top = pb[i].Top + 3 * rTextboxheight + 5 * yTextboxBlankSpace + rPictureboxHeight;
                                        bt[i].Left = bt[i - rNumsForEachLine].Left;
                                        bt[i].Visible = false;
                                        this.Controls.Add(bt[i]);

                                }
                        }
                        int rHeightForOneLine = rPictureboxHeight + 5 * yTextboxBlankSpace + 3 * rTextboxheight + rCommandHeight;
                        int rLines = (rollnum - 1) / rNumsForEachLine + 1;
                        if (rLines == 1)
                        {
                                this.Height = pb[1].Top * 4 + rPictureboxHeight + 5 * yTextboxBlankSpace + 3 * rTextboxheight + rCommandHeight + 10;
                                this.Width = rWidthForEach * rollnum + pb[1].Left * 2 + (rollnum - 1) * rXBlankspace;

                        }
                        else
                        {
                                this.Height = rLines * rHeightForOneLine + pb[1].Top * 2 + 10;
                                this.Width = rWidthForEach * rNumsForEachLine + pb[1].Left * 2 + (rNumsForEachLine - 1) * rXBlankspace;

                        }
                        for (int k = 1; k <= rollnum; k++)
                        {
                                tb[k][3].TextChanged += roll5_TextChanged;
                        }
                        
                        button1_Click_1(null, EventArgs.Empty);
                        
                }

                void roll5_TextChanged(object sender, EventArgs e)
                {
                        saved = false;

                }

                private void button1_Click(object sender, EventArgs e)
                {

                }

                private void pictureBox1_Click(object sender, EventArgs e)
                {

                }
                private void clone(TextBox dest, TextBox source)
                {
                        dest.Left = source.Left;
                        dest.Top = source.Top;
                        dest.Width = source.Width;
                        dest.Height = source.Height;
                        dest.Font = source.Font;


                }
                private void clone(PictureBox dest, PictureBox source)
                {
                        dest.Left = source.Left;
                        dest.Top = source.Top;
                        dest.Width = source.Width;
                        dest.Height = source.Height;
                        dest.SizeMode = source.SizeMode;

                }
                private void clone(Button dest, Button source)
                {
                        dest.Left = source.Left;
                        dest.Top = source.Top;
                        dest.Width = source.Width;
                        dest.Height = source.Height;

                }

                private void button1_Click_1(object sender, EventArgs e)
                {
                        if (obj.stdSelected[1] != null)
                        {
                                timer1.Enabled = true;
                                timer2.Enabled = true;
                                currentPointer = 1;
                                obj.button2_Click(null, EventArgs.Empty);

                        }
                        else
                        {
                                MessageBox.Show("请选择班级!");
                        }
                }
                private void roll5_FormClosing(object sender, FormClosingEventArgs e)
                {
                        timer1.Enabled = false;
                        timer2.Enabled = false;
                        obj.timer1.Enabled = false;
                        bool clear = true;
                        for (int i = 1; i <= rollnum; i++)
                        {
                                if (tb[i][3].Text != "")
                                {
                                        clear = false;
                                }
                        }
                        if (saved == false)
                        {
                                var choice = MessageBox.Show("已填入数据，您要保存吗？", "提示", MessageBoxButtons.YesNoCancel);
                                if (choice == DialogResult.Yes)
                                {
                                        try
                                        {
                                                button2_Click(null, EventArgs.Empty);
                                        }
                                        catch (Exception)
                                        { }
                                }
                                else if (choice == DialogResult.Cancel)
                                {
                                        e.Cancel = true;
                                }
                                else
                                {
                                        try
                                        {
                                                for (int i = 1; i <= rollnum; i++)
                                                {
                                                        stdNamed[i].selected = false;
                                                }
                                        }
                                        catch (Exception)
                                        { }
                                        this.Dispose();
                                }
                        }

                }

                private void button2_Click(object sender, EventArgs e)
                {
                        for (int i = 1; i <= rollnum; i++)
                        {
                                if (tb[i][3].Text != "")
                                {
                                        try
                                        {
                                                stdNamed[i].grade = double.Parse(tb[i][3].Text);
                                        }
                                        catch (Exception)
                                        {

                                                MessageBox.Show("请输入数字");
                                                return;

                                        }
                                        stdNamed[i].selected = true;
                                }
                                else
                                {
                                        stdNamed[i].selected = false;
                                        stdNamed[i].grade = -1;
                                }
                        }
                        obj.updateDataBase();
                        saved = true;

                }

        }
}
