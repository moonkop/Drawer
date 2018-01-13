using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Configuration;
using Drawer.Untils;
using Drawer.Control;
using Drawer.Model;
using Drawer.UserControls;

namespace Drawer.Forms
{

    public partial class MainForm : Form
    {
        public List<System.Windows.Forms.CheckBox> CheckboxClassroom = new List<System.Windows.Forms.CheckBox>();
        public Random rd = new Random();
        public DateTime currentTime = new DateTime();
        public StatusPrintBuffer spb = new StatusPrintBuffer();
        public int seekNums;
        public int seekPointer;
        bool textBox4Changed;
        bool textBox2Changed;
        bool textBox3Changed;
        SelectType st;
        public Student winner;
        int maxnum;
        private string pastDBSHA1;
        private DrawerControl drawerControl
        {
            get
            {
                return Controllers.drawerControl;
            }
        }

        public static MySettings Settings
        {
            get
            {
                return Assistance.Settings;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        public ListViewItem UpdateListViewItemForStudent(ListViewItem lvi)
        {
            Student stu = (Student)lvi.Tag;
            lvi.SubItems[0].Text = stu.Classroom.ClassID;
            lvi.SubItems[1].Text = stu.Name;
            lvi.SubItems[2].Text = stu.Id;
            lvi.SubItems[3].Text = stu.Grade_ForReading;
            lvi.SubItems[4].Text = stu.Selected_Mutiply_ForReading;
            lvi.SubItems[5].Text = stu.Selected_Single_ForReading;
            lvi.SubItems[6].Text = stu.Selected_Report_ForReading;
            return lvi;
        }
        public ListViewItem CreateListViewItemForStudent(Student std1)
        {
            ListViewItem lv = new ListViewItem();
            lv.Tag = std1;
            lv.Text = std1.Classroom.ClassID;
            lv.SubItems.Add(std1.Name);
            lv.SubItems.Add(std1.Id);
            lv.SubItems.Add(std1.Grade_ForReading);
            lv.SubItems.Add(std1.Selected_Mutiply_ForReading);
            lv.SubItems.Add(std1.Selected_Single_ForReading);
            lv.SubItems.Add(std1.Selected_Report_ForReading);
            return lv;
        }
        public void LoadConfig_SelectedClassroom()
        {
           drawerControl.classShowed = new List<Classroom>();
            foreach (var str1 in Assistance.Settings.classStrs)
            {
                Classroom cls = drawerControl.GetOrCreateClassroomById(str1);
               drawerControl.classShowed.Add(cls);
            }
        }
        public void ShowSelectedClassroomCheckbox()
        {
            int top = checkBox1.Top;
            int left = checkBox1.Left;
            checkBox1.Visible = false;
            if (CheckboxClassroom.Count != 0)
            {
                foreach (CheckBox ckb in CheckboxClassroom)
                {
                    ckb.Dispose();
                }
                CheckboxClassroom.Clear();
            }
            foreach (Classroom cls in drawerControl.classShowed)
            {
                System.Windows.Forms.CheckBox tempckb = new System.Windows.Forms.CheckBox();
                tempckb = new System.Windows.Forms.CheckBox();
                tempckb.Height = checkBox1.Height;
                tempckb.Location = checkBox1.Location;
                tempckb.Top = top;
                tempckb.Size = checkBox1.Size;
                tempckb.Text = cls.ClassID;
                tempckb.Font = checkBox1.Font;
                tempckb.Tag = cls;

                tempckb.CheckedChanged += new System.EventHandler(this.ckb_CheckedChanged);
                CheckboxClassroom.Add(tempckb);
                top += 50;
                this.Controls.Add(tempckb);
            }
        }
        public void GetClassroomMarkStatus()
        {
            drawerControl.classMarked.Clear();
            foreach (CheckBox ckb in CheckboxClassroom)
            {
                if (ckb.Checked)
                {
                    Classroom cls = drawerControl.GetClassroomById(ckb.Text);
                    drawerControl.classMarked.Add(cls);
                }
            }
        }
        /// <summary>
        /// 打印任何东西在textbox1上
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        public void statusPrint<T>(T str)
        {
            toolStripStatusLabel1.Text = str.ToString();
        }
        public void loge<T>(T str)
        {
            drawerControl.LogAndShow(str);

        }
        /// <summary>
        /// 把一个字符串按照分隔符分割
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="dest">第dest个分隔符后面</param>
        /// <param name="spilt">分隔符</param>
        /// <returns></returns>
        public void BindingDatas()
        {
            TextBoxMutiplyNum.Text = Settings.DefaultMutiplyDrawerNum.ToString();
            timer1.Interval = Settings.RollTimeInteval;
        }
   
        public void DisplayStudentData(Student student)
        {
            TextBoxName.Text = student.Name;
            textBoxID.Text = student.Id;
            textBoxClassroom.Text = student.Classroom.ClassID;
            try
            {
                TBOutput.Visible = false;
                pictureBox1.Load(student.PicturePath);
            }
            catch (Exception)
            {
                // pictureBox1.Load();
             //   throw;

            }
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {

            BindingDatas();
            //NameNumLength = FileLength(numpath);
            spb.obj = toolStripStatusLabel1;
            pastDBSHA1 = Assistance.Settings.ShA1OfDB;
            if (drawerControl.SecurityEnabled == true)
            {
                if (pastDBSHA1 != Assistance.GetSHA1Hash(Settings.DBpath))
                {
                    var pib = new PasswordInputDialog(this, "检测到不安全的数据修改，请输入管理员密码", true);
                    pib.Owner = this;
                    pib.Show();
                }
            }
       
            TBOutput.Location = pictureBox1.Location;
            TBOutput.Size = pictureBox1.Size;
            TBOutput.Visible = false;
            drawerControl.ReadDataFromDatabase();
            LoadConfig_SelectedClassroom();
            ShowSelectedClassroomCheckbox();

        }
 //       private void roll5Init(object sender, EventArgs e)//批量抽取
 //       {
 //           selectStudents();
 //           if (drawerControl.stdSelected.Count == 0)
 //           {
 //               MessageBox.Show("请选择班级");
 //               return;
 //           }
 //           int rollnum = 0;
 //           if (!int.TryParse(TextBoxMutiplyNum.Text, out rollnum))
 //           {
 //               MessageBox.Show("请输入数字");
 //               return;
 //           }

 //           if (radioButton1.Checked == true)//批量抽取 每周一问
 //           {
 //               st = SelectType.Mutiply;
 //               if (GetStudentsReady(st) == 0)
 //               {
 //                   if (MessageBox.Show("每周一问已抽完，是否输出成绩并清空数据库？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
 //                   {
 //                       drawerControl.ExportData();
 //                       foreach (Student astd in drawerControl.stdSelected)
 //                       {
 //                           astd.Selected_Mutiply = false;
 //                           astd.Grade = -1;
 //                       }
 //                       MessageBox.Show("成绩已保存至" + Settings.dataOutPutPath + "\n并清空");
 //                       return;
 //                   }
 //                   else
 //                   {
 //                       return;
 //                   }
 //               }
 //               else if (rollnum > maxnum)
 //               {

 //                   MessageBox.Show("超过未抽取的人数，还有" + maxnum + "人可以抽取");
 //                   return;
 //               }
 //           }
 //           else//批量抽取 实验报告
 //           {
 //               st = SelectType.Report;
 //               if (GetStudentsReady(st) == 0)
 //               {
 //                   if (MessageBox.Show("一轮已抽完 是否清空记录进行下一轮？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
 //                   {
 //                       foreach (Student astd in drawerControl.stdSelected)
 //                       {
 //                           astd.Selected_Report = false;
 //                       }
 //                       MessageBox.Show("清空完毕！");
 //                       return;
 //                   }
 //                   else
 //                   {
 //                       return;
 //                   }
 //               }
 //               else if (rollnum > maxnum)
 //               {
 //                   MessageBox.Show("超过未抽取的人数，还有" + maxnum + "人可以抽取");
 //                   return;
 //               }
 //           }
 //new NewMutiplyDrawer(rollnum,st).Show();


 //       }
        public void startRoll5()
        {
            //if (stdSelected.Count == 0 || checkBoxChanged == true)
            //{
            //    selectStudents();
            //}
            //if (stdSelected.Count != 0)
            //{
            //    getReady(st);
            //    timer1.Enabled = true;
            //}
            //else spb.add("请选择班级");
            timer1.Enabled = true;
        }
        public void stopRoll5(SelectType st)
        {
            timer1.Enabled = false;
            if (drawerControl.Get_Selected_counts(st) ==drawerControl.stdSelected.Count)
            {
               drawerControl.stdSelected[0] = new Student();
               drawerControl.stdSelected[0].Id = "000000";
               drawerControl.stdSelected[0].Name = "NULL";
               drawerControl.stdSelected[0].Classroom = new Classroom("0000");
               drawerControl.stdSelected[0].Classroom.ClassID = "0000";
                Assistance.record("ERROR NO MORE STUDENTS");
                MessageBox.Show("没有更多的学生了");
                return;
            }
            else
            {
                DisplayStudentData(winner);
                switch (st)
                {
                    case SelectType.Mutiply:
                        winner.Selected_Mutiply = true;
                        break;
                    case SelectType.Report:
                        winner.Selected_Report = true;
                        break;
                    default:
                        break;
                }
                drawerControl.stdReady.Remove(winner);
                maxnum--;
            }
            Assistance.record(winner, "form roll5,selectTpye=" + st.ToString());
        }
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            listViewResults.Visible = true;
            button6.Visible = true;
            this.Width = 1263;

            drawerControl.stdFound.Clear();
            if (drawerControl.AllStudents.Count == 0)
            {
                drawerControl.ReadDataFromDatabase();
            }
            if (textBox2Changed == true)//按姓名完全匹配查找
            {
                foreach (Student astd in drawerControl.AllStudents)
                {
                    if (TextBoxName.Text == astd.Name)
                    {
                        drawerControl.stdFound.Add(astd);
                    }
                }

                if (drawerControl.stdFound.Count == 0)//按姓名查找未找到则转换为模糊查找
                {
                    foreach (Student astd in drawerControl.AllStudents)
                    {
                        if (astd.Name.IndexOf(TextBoxName.Text) != -1)
                        {
                            drawerControl.stdFound.Add(astd);
                        }
                    }
                }

            }
            if (textBox3Changed == true)//按学号查找
            {
                foreach (Student astd in drawerControl.AllStudents)
                {
                    if (astd.Id == textBoxID.Text || astd.Id.EndsWith(textBoxID.Text))
                    {
                        drawerControl.stdFound.Add(astd);
                    }
                }
            }

            if (textBox4Changed == true)//按班级查找
            {
                foreach (Student astd in drawerControl.AllStudents)
                {
                    if (textBoxClassroom.Text == "" || textBoxClassroom.Text == astd.Classroom.ClassID)
                    {
                        drawerControl.stdFound.Add(astd);
                    }
                }
                if (drawerControl.stdFound.Count == 0)//按班级查找未找到则转换为模糊查找
                {
                    foreach (Student astd in drawerControl.AllStudents)
                    {
                        if (astd.Classroom.ClassID.IndexOf(textBoxClassroom.Text) != -1)
                        {
                            drawerControl.stdFound.Add(astd);
                        }
                    }
                }
            }
            statusPrint(drawerControl.stdFound.Count + "人已找到");
            LoadstuFound();

        }

        internal List<Classroom> GetClassroomMarked()
        {
            List<Classroom> classroomMarked = new List<Classroom>();
            foreach (CheckBox item in CheckboxClassroom)
            {
                if (item.Checked==true)
                {
                    classroomMarked.Add((Classroom)item.Tag);
                }
            }
            return classroomMarked;
        }

        public void LoadstuFound()
        {
            if (drawerControl.stdFound.Count != 0)
            {
                DisplayStudentData(drawerControl.stdFound[0]);
            }
            listViewResults.Items.Clear();
            foreach (Student astd in drawerControl.stdFound)
            {
                listViewResults.Items.Add(CreateListViewItemForStudent(astd));
            }

        }
        private void button6_Click(object sender, EventArgs e)//listview 返回
        {
            HideListView();
        }

        private void HideListView()
        {
            listViewResults.Visible = false;
            button6.Visible = false;
            this.Width = 783;
        }


        private Student GetStudentById(string id)
        {
            foreach (var student in drawerControl.AllStudents)
            {
                if (student.Id == id)
                {
                    return student;
                }
            }
            return null;
        }
   
        private void timer1_Tick(object sender, EventArgs e)
        {
           
            DisplayStudentData(drawSingleSession.nextWinner());
        }
        private void ckb_CheckedChanged(object sender, EventArgs e)
        {
           drawerControl.classMarked= GetClassroomMarked();
        }
        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var i = listViewResults.SelectedItems;
            if (i.Count != 0)
            {
                Student studentSelected = (Student)listViewResults.SelectedItems[0].Tag;
                DisplayStudentData(studentSelected);
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            drawerControl.CloseConnection();
            CollectSettings();
            Assistance.StoreSettings();
        }
        public static string getPicturePathOrDefault(string path)
        {
            if (File.Exists(path))
            {
                return path;
            }
            else
            {
                return Settings.PicPath + "default.jpg";
            }
        }
        private void buttonDeleteAll_Click(object sender, EventArgs e)
        {
           drawerControl.ReadDataFromDatabase();
            if (MessageBox.Show("此操作将删除所有学生的成绩并将实验报告抽取记录、课堂提问抽取记录，随机提问抽取记录清零，是否确定？", "警告:", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (Student astd in drawerControl.AllStudents)
                {
                    astd.Grade = -1;
                    astd.Selected_Mutiply = false;
                    astd.Selected_Report = false;
                    astd.Selected_Single = false;
                }
               drawerControl.UpdateDataBase();
            }
        }
        DrawSession drawSingleSession;
        private void buttonStart_Click(object sender, EventArgs e) //开始按钮
        {
            drawSingleSession = drawerControl.GetDrawSession(SelectType.Single);
            if (drawSingleSession!=null)
            {
                timer1.Enabled = true;
            }
        }
        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (drawSingleSession==null)
            {
                return;
            }
            winner = drawSingleSession.GetFinalWinner();
            DisplayStudentData(winner);
            winner.Selected_Single = true;
            Assistance.record(winner, "from single ");
             drawSingleSession=null;

        }
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (listViewResults.Sorting == SortOrder.Ascending)
            {
                listViewResults.Sorting = SortOrder.Descending;
            }
            else
            {
                listViewResults.Sorting = SortOrder.Ascending;
            }
            listViewResults.ListViewItemSorter = new ListViewItemComparer(e.Column, listViewResults.Sorting);
            listViewResults.Sort();

        }
        private void BTExcCmd_Click(object sender, EventArgs e)
        {
            drawerControl.ExecuteSQLcommand(textBox1.Text);
            drawerControl.ReadDataFromDatabase();
        }
        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2Changed = true;
            textBox3Changed = false;
            textBox4Changed = false;
        }
        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3Changed = true;
            textBox4Changed = false;
            textBox2Changed = false;
        }
        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4Changed = true;
            textBox3Changed = false;
            textBox2Changed = false;
        }
        private void 读取数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawerControl.ReadDataFromDatabase();
        }
        private void 保存数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawerControl.UpdateDataBase();
        }
        private void 导出数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawerControl.ExportData();
        }
        private void 执行命令ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (drawerControl.SecurityEnabled == true)
            {
                var pib = new PasswordInputDialog(this, "请输入密码以执行命令", true);
                pib.Show();
            }
            textBox1.Enabled = true;
            textBox1.Visible = true;
            button11.Enabled = true;
            button11.Visible = true;
            BTExcCmd.Enabled = true;
            BTExcCmd.Visible = true;
            HideListView();

            this.Width = 1215;

        }
        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void 批量导入照片ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MessageBox.Show("请选中所有需要导入的照片并确认\n 提示：照片文件名即学号");

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图片|*.jpg;*.png;*.gif;*.tif;*.bmp";
            ofd.InitialDirectory = System.Environment.CurrentDirectory;
            ofd.Multiselect = true;

            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string[] pics = ofd.FileNames;
            if (pics.Count() == 0)
            {
                return;
            }


            foreach (var item in pics)
            {
                if (Path.GetDirectoryName(item) == Settings.PicPath)
                {
                    continue;
                }
                else
                {
                    System.IO.File.Copy(item, Settings.PicPath + Path.GetFileName(item), true);
                }
            }
        }
        private void 添加学生ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void 批量导入学生ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofd.Filter = "csv表格|*.csv|txt|*.txt|所有文件|*.*";
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;

            }

            char[] spiliters = { ',', '|', ';', '-', '\t', ' ', };
            StreamReader sr = new StreamReader(ofd.FileName, Encoding.Default);


            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (line.Length < 2)
                {
                    goto ErrorHandler;

                }
                bool spliterSetFlag = false;
                char spliter = ' ';
                foreach (char aspliter in spiliters)
                {
                    if (line.IndexOf(aspliter) != -1)
                    {
                        spliterSetFlag = true;
                        spliter = aspliter;
                        break;
                    }
                }
                if (!spliterSetFlag)
                {
                    goto ErrorHandler;

                }
                char[] spliterArray = new char[1];
                spliterArray[0] = spliter;
                string[] strsTemp = line.Split(spliterArray, StringSplitOptions.RemoveEmptyEntries);

                if (strsTemp.Length != 3)
                {
                    goto ErrorHandler;
                }

                Student newStudent = new Student();
                List<string> strs = new List<string>();

                foreach (var astr in strsTemp)
                {
                    strs.Add(astr.Replace(" ", ""));

                }
                foreach (string astr in strs)
                {
                    if (Regex.IsMatch(astr, @"\d{5,}"))
                    {
                        newStudent.Id = astr;
                    }
                    if (Regex.IsMatch(astr, @"[一-龥]{2,}"))
                    {
                        newStudent.Name = astr;
                    }
                    if (Regex.IsMatch(astr, @"^\D*\d{4,4}\D*$"))
                    {
                        Classroom cls = drawerControl.GetClassroomById(astr);
                        if (cls == null)
                        {
                            if (MessageBox.Show("该班级" + astr + "尚未创建，是否创建？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                cls = new Classroom(astr);
                                drawerControl.classAll.Add(cls);
                            }
                        }
                        newStudent.Classroom = cls;
                    }
                }
                if (newStudent.Name != "" && newStudent.Classroom != null && newStudent.Id != null)
                {
                    if (GetStudentById(newStudent.Id) != null)
                    {
                        if (MessageBox.Show("学号为" + newStudent.Id + "的学生已经存在，是否删除原学生？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            drawerControl.AllStudents.Remove(GetStudentById(newStudent.Id));
                        }
                        else
                        {
                            goto ErrorHandler;

                        }
                    }
                }
                else
                {
                    goto ErrorHandler;

                }
                newStudent.Grade = -1;

                drawerControl.AllStudents.Add(newStudent);
                loge("InputSuccess,Get: " + line);
                continue;
                ErrorHandler:
                loge("InputError,Get: " + line);

            }

        }
        private void 班级设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassPicker classPicker = new ClassPicker(drawerControl.classAll, drawerControl.classShowed);
            classPicker.Owner = this;
            classPicker.fm = this;
            classPicker.ShowDialog();
            ShowSelectedClassroomCheckbox();
        }
        private void 读取设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Assistance.LoadSettings();
        }

        private void 保存设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Assistance.StoreSettings();
        }

        private void 导出设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        public void CollectSettings()
        {
            Assistance.Settings.classStrs.Clear();
            foreach (Classroom cls in drawerControl.classShowed)
            {
                Assistance.Settings.classStrs.Add(cls.ClassID);

            }

        }

        private void newMutiplyToolStripMenuItem_Click(object sender, EventArgs e)
        {
       //     new NewMutiplyDrawer(20,SelectType.Mutiply).Show();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem itemSelected = listViewResults.SelectedItems[0];

            Student stuSelected = (Student)itemSelected.Tag;
            StudentStatus studentStatus = new StudentStatus(stuSelected);
            studentStatus.ShowDialog();
            UpdateListViewItemForStudent(itemSelected);

        }

        private void 显示日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawerControl.ShowLogForm();

        }
        SelectType GetChooseSelectType()
        {
            if (radioButtonMutiply.Checked=true)
            {
                return SelectType.Mutiply;
            }
            else
            {
                return SelectType.Report;
            }
        }
        private void buttonMutiplyDraw_Click(object sender, EventArgs e)
        {

            drawerControl.StartDrawMutiply(GetChooseSelectType(),int.Parse(TextBoxMutiplyNum.Text));



        }
    }
}

