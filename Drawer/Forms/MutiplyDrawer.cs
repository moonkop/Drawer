﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Drawer
{
    public partial class roll5 : Form
    {
        public int[][] l = new int[100][];
        MainForm obj;
        public TextBox[][] tb = new TextBox[100][];
        public PictureBox[] pb = new PictureBox[30];
        public Button[] bt = new Button[30];
        Timer timer2 = new Timer();
        Timer timer1 = new Timer();
        public int rollnum;
        private int currentPointer;
        public Student[] stdNamed = new Student[30];
        public bool saved = true;
        Student.selectedType selectType;
        private bool mouseIsDown;
        public roll5(MainForm obj1, int nums, Student.selectedType st)
        {
            InitializeComponent();
            obj = obj1;
            rollnum = nums;
            selectType = st;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 3000;
            timer1.Enabled = true;
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Interval = obj.timer1.Interval;
            Assistance.record("roll5 start   selectType=" + st.ToString() + " " + "selectNum=" + rollnum.ToString());
        }
        void timer2_Tick(object sender, EventArgs e)
        {
            showdata(obj.Hitter, currentPointer);
        }
        void showdata(Student std, int pointer)
        {
            try
            {
                tb[pointer][1].Text = std.ID;
                tb[pointer][2].Text = std.name + "  " + std.classroom.classID;
                pb[pointer].Load(MainForm.PicPath + std.ID + ".jpg");
            }
            catch (Exception)
            { }
        }
        void timer1_Tick(object sender, EventArgs e)
        {
            obj.stopRoll5(selectType);
            stdNamed[currentPointer] = obj.Hitter;
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
                obj.startRoll5();
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            int i;
            int rNumsForEachLine = int.Parse(Assistance.GetConfigurations(MainForm.ConfigPath, "rNumsForEachLine"));
            timer1.Interval = int.Parse(Assistance.GetConfigurations(MainForm.ConfigPath, "bigTimerInterval"));
            int rWidthForEach = int.Parse(Assistance.GetConfigurations(MainForm.ConfigPath, "rWidthForEach"));
            int rXBlankspace = int.Parse(Assistance.GetConfigurations(MainForm.ConfigPath, "rXBlankspace"));
            int rTextboxheight = int.Parse(Assistance.GetConfigurations(MainForm.ConfigPath, "rTextboxheight"));
            int rPictureboxHeight = int.Parse(Assistance.GetConfigurations(MainForm.ConfigPath, "rPictureboxHeight"));
            int rCommandHeight = int.Parse(Assistance.GetConfigurations(MainForm.ConfigPath, "rCommandHeight"));
            int yTextboxBlankSpace = int.Parse(Assistance.GetConfigurations(MainForm.ConfigPath, "yTextboxBlankSpace"));
            bool autoSizeEnabled = Convert.ToBoolean(Assistance.GetConfigurations(MainForm.ConfigPath, "autoSizeEnabled"));
            bool autoNumsForEachLine = Convert.ToBoolean(Assistance.GetConfigurations(MainForm.ConfigPath, "autoNumsForEachLine"));
            // autoNumsForEachLine = false;
            //rNumsForEachLine = 10;
            //   autoSizeEnabled = false;
            int SH;
            int SW;
            int rHeightForOneLine = rPictureboxHeight + 5 * yTextboxBlankSpace + 3 * rTextboxheight;
            int rLines = (rollnum - 1) / rNumsForEachLine + 1;
            SH = SystemInformation.WorkingArea.Height;
            SW = SystemInformation.WorkingArea.Width;
            int heightProvideForEachLine;
            #region autosize
            if (autoSizeEnabled)//如果长度或者宽度超出屏幕大小
            {
                #region 如果长度或者宽度超出屏幕大小
                bool IsOverSized = false;
                if (rollnum * rWidthForEach + (rollnum - 1) * rXBlankspace > SW && rollnum <= rNumsForEachLine)//一行时超过屏幕宽度
                {
                    IsOverSized = true;
                }
                if (rollnum > rNumsForEachLine && rNumsForEachLine * rWidthForEach + (rNumsForEachLine - 1) * rXBlankspace > SW)//多行时超过屏幕宽度
                {
                    IsOverSized = true;
                }
                if ((rollnum / rNumsForEachLine) * (rPictureboxHeight + 3 * rTextboxheight + 5 * yTextboxBlankSpace) > SH)//多行时超过屏幕高度
                {
                    IsOverSized = true;
                }
                #endregion

                if (IsOverSized)
                {
                    if (autoNumsForEachLine)
                    {
                        for (int k = 1; k < 10; k++)
                        {
                            heightProvideForEachLine = SH / k;
                            rNumsForEachLine = SW / (heightProvideForEachLine / 2);
                            rWidthForEach = SW / rNumsForEachLine;
                            rLines = k;
                            float textHeight = heightProvideForEachLine / 10 / 2;
                            rTextboxheight = Convert.ToInt32(textHeight * 2);
                            this.textBox0.Font = new System.Drawing.Font("微软雅黑", textHeight, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                            rPictureboxHeight = heightProvideForEachLine - 3 * rTextboxheight;
                            if (rLines * rNumsForEachLine >= rollnum)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        rXBlankspace = 0;
                        if (rollnum <= rNumsForEachLine && rollnum * rWidthForEach + (rollnum - 1) * rXBlankspace > SW)
                        {
                            rWidthForEach = SW / rNumsForEachLine;
                        }
                        else if (rollnum >= rNumsForEachLine && rNumsForEachLine * rWidthForEach + (rNumsForEachLine - 1) * rXBlankspace > SW)
                        {
                            rWidthForEach = SW / rollnum;
                        }
                        if (rPictureboxHeight + 5 * yTextboxBlankSpace + 3 * rTextboxheight > SH)
                        {
                            yTextboxBlankSpace = 0;
                            rTextboxheight = 30;
                            rPictureboxHeight = SH - 3 * rTextboxheight;
                        }
                        if (rollnum > rNumsForEachLine && ((rPictureboxHeight + 5 * yTextboxBlankSpace + 3 * rTextboxheight) * rLines > SH))
                        {
                            int heightProvidedForEachLine = SH / rLines;
                            float textHeight = heightProvidedForEachLine / 10 / 2;
                            rTextboxheight = Convert.ToInt32(textHeight * 2);
                            this.textBox0.Font = new System.Drawing.Font("微软雅黑", textHeight, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                            rPictureboxHeight = heightProvidedForEachLine - 3 * rTextboxheight;
                        }
                    }
                }
            }
            #endregion
            button0.Width = 50;
            pictureBox0.Width = rWidthForEach;
            textBox0.Width = rWidthForEach;
            textBox0.Height = rTextboxheight;
            pictureBox0.Height = rPictureboxHeight;
            button0.Height = rCommandHeight;
            pictureBox0.Left -= rWidthForEach + rXBlankspace;
            pictureBox0.Visible = false;
            textBox0.Top = pictureBox0.Top + rPictureboxHeight - rTextboxheight;
            textBox0.Visible = false;
            button0.Top = pictureBox0.Top + rPictureboxHeight + rTextboxheight * 2 + 3 * yTextboxBlankSpace;
            button0.Left -= rWidthForEach + rXBlankspace;
            button0.Visible = true;

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
                pb[i].BorderStyle = BorderStyle.None;
                if ((i - 1) % rNumsForEachLine != 0 || i == 1)
                {
                    pb[i].Left = pb[i - 1].Left + rWidthForEach + rXBlankspace;
                    pb[i].Top = pb[i - 1].Top;
                    pb[i].Visible = true;
                    pb[i].MouseDown += roll5_MouseDown;
                    pb[i].MouseMove += roll5_MouseMove;
                    pb[i].MouseUp += roll5_MouseUp;
                    this.Controls.Add(pb[i]);
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
                }
            }
            rHeightForOneLine = rPictureboxHeight + 5 * yTextboxBlankSpace + 3 * rTextboxheight;
            rLines = (rollnum - 1) / rNumsForEachLine + 1;
            if (rLines == 1)
            {
                this.Height = pb[1].Top + rHeightForOneLine;
                //  this.Height = pb[1].Top * 4 + rPictureboxHeight + 5 * yTextboxBlankSpace + 3 * rTextboxheight + rCommandHeight + 10;
                this.Width = rWidthForEach * rollnum + pb[1].Left * 2 + (rollnum - 1) * rXBlankspace;
            }
            else
            {
                this.Height = rLines * rHeightForOneLine + pb[1].Top;
                this.Width = rWidthForEach * rNumsForEachLine + pb[1].Left * 2 + (rNumsForEachLine - 1) * rXBlankspace;
                if (autoNumsForEachLine)
                {

                }

            }
            for (int k = 1; k <= rollnum; k++)
            {
                tb[k][3].TextChanged += roll5_TextChanged;
            }
            if (selectType == Student.selectedType.Report)
            {
                for (int k = 1; k <= rollnum; k++)
                {
                    tb[k][3].Visible = false;
                }
            }
            //生成关闭按钮
            button3.Left = this.Width - button3.Width;
            button4.Left = button3.Left - button4.Width;
            button2.Left = button4.Left - button2.Width;
#if false
                        for (int k = 1; k <=rollnum; k++)
                        {
                                for (int j = 1; j < 3; j++)
                                {
                                        tb[k][j].Visible = false;
                                }
                        }
#endif
            //生成换一个按钮
            for (int k = 1; k <= rollnum; k++)
            {
                bt[k] = new Button();
                clone(bt[k], bt[0]);
                bt[k].Left = pb[k].Left;
                bt[k].Height = tb[k][1].Height;
                bt[k].Top = pb[k].Top + rPictureboxHeight - rCommandHeight - 6;
                this.Controls.Add(bt[k]);
                bt[k].Visible = true;
                this.Controls.SetChildIndex(this.bt[k], 0);
                bt[k].Text = "换一个";
                bt[k].Click += roll5_ButtonClick;
                bt[k].Tag = k;
            }
            if (selectType == Student.selectedType.Report)
            {
                saved = false;
            }
            button1_Click_1(null, EventArgs.Empty);
        }
        void roll5_ButtonClick(object sender, EventArgs e)
        {
            //MessageBox.Show(((Button)sender).Tag.ToString());
            int target = int.Parse(((Button)sender).Tag.ToString());
            obj.startRoll5();
            obj.stopRoll5(selectType);
            showdata(obj.Hitter, target);
            switch (selectType)
            {
                case Student.selectedType.Mutiply:
                    stdNamed[target].selected_Mutiply = false;
                    break;
                case Student.selectedType.Single:
                    break;
                case Student.selectedType.Report:
                    stdNamed[target].selected_Report = false;
                    break;
                default:
                    break;
            }
            Assistance.record("roll5 skip student =" + stdNamed[target].name + stdNamed[target].ID.ToString());
            stdNamed[target] = obj.Hitter;
            Assistance.record("roll5 next student =" + stdNamed[target].name + stdNamed[target].ID.ToString());
        }
        #region mouse
        void roll5_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
        }
        Point lastPoint = new Point();
        Point currentPoint = new Point();
        void roll5_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseIsDown && e.Button == MouseButtons.Left)
            {
                if (lastPoint.X == lastPoint.Y && lastPoint.X == 0)
                {
                    lastPoint = Control.MousePosition;
                }
                currentPoint = Control.MousePosition;
                var formPoint = this.Location;
                this.Location = new Point(formPoint.X + currentPoint.X - lastPoint.X, formPoint.Y + currentPoint.Y - lastPoint.Y);
                lastPoint.X = currentPoint.X;
                lastPoint.Y = currentPoint.Y;
            }
        }

        void roll5_MouseDown(object sender, MouseEventArgs e)
        {
            mouseIsDown = true;
            lastPoint.X = 0;
            lastPoint.Y = 0;
        }

        #endregion
        void roll5_TextChanged(object sender, EventArgs e)
        {
            saved = false;
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
                obj.startRoll5();

            }
            else
            {
                MessageBox.Show("请选择班级!");
            }
        }
        private void roll5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Assistance.record("roll5 tryclosing");
            timer1.Enabled = false;
            timer2.Enabled = false;
            obj.timer1.Enabled = false;
            switch (selectType)
            {
                case Student.selectedType.Mutiply:
                    if (saved == false)
                    {
                        var choice = MessageBox.Show("已填入数据，您要保存吗？", "提示", MessageBoxButtons.YesNoCancel);
                        if (choice == DialogResult.Yes)
                        {
                            try
                            {
                                saveResult(null, EventArgs.Empty);
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
                            Assistance.record("roll5 DONOTsaving selectType=Mutiply");
                            try
                            {
                                for (int i = 1; i <= rollnum; i++)
                                {
                                    stdNamed[i].selected_Mutiply = false;
                                }
                            }
                            catch (Exception)
                            { }
                            this.Dispose();
                        }
                    }
                    else
                    {
                        bool clear = true;
                        try
                        {
                            for (int i = 1; i < rollnum; i++)
                            {
                                if (tb[i][3].Text != "")
                                {
                                    clear = false;
                                    break;
                                }
                            }
                            if (clear == true)
                            {
                                for (int i = 1; i <= rollnum; i++)
                                {
                                    stdNamed[i].selected_Mutiply = false;
                                }
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                    break;
                case Student.selectedType.Report:
                    if (saved == false)
                    {
                        saveResult(null, EventArgs.Empty);
                    }

                    break;
                default:
                    break;
            }

        }
        private void saveResult(object sender, EventArgs e)
        {
            Assistance.record("roll5 trysaving selectType=" + selectType.ToString());
            switch (selectType)
            {
                case Student.selectedType.Mutiply:
                    for (int i = 1; i <= rollnum; i++)
                    {
                        if (tb[i][3].Text != "")
                        {
                            try
                            {
                                stdNamed[i].grade = double.Parse(tb[i][3].Text);
                                Assistance.record("saving success student=" + stdNamed[i].name + "|" + stdNamed[i].ID.ToString() + "grade=" + stdNamed[i].grade.ToString());
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("请输入数字并重新保存");
                                Assistance.record("saving failure case inputbox not number where student=" + stdNamed[i].name + "|" + stdNamed[i].ID.ToString());
                                return;
                            }
                            stdNamed[i].selected_Mutiply = true;
                        }
                        else
                        {
                            Assistance.record("saving NULL student=" + stdNamed[i].name + "|" + stdNamed[i].ID.ToString());
                            stdNamed[i].selected_Mutiply = false;
                            stdNamed[i].grade = -1;
                        }
                        saved = true;
                    }
                    MessageBox.Show("记录已保存");
                    break;
                case Student.selectedType.Report:
                    if (MessageBox.Show("要保存记录吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        Assistance.record("roll5 DONOTsaving selectType=Report");
                        try
                        {
                            for (int i = 1; i <= rollnum; i++)
                            {
                                stdNamed[i].selected_Report = false;
                            }
                        }
                        catch (Exception)
                        { }
                    }
                    else
                    {
                        try
                        {
                            for (int i = 1; i <= rollnum; i++)
                            {
                                Assistance.record(stdNamed[i], "REPORT SAVING");
                            }
                        }
                        catch (Exception)
                        { }
                        MessageBox.Show("记录已保存");
                    }
                    break;
                default:
                    break;
            }
            obj.updateDataBase();
            saved = true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}