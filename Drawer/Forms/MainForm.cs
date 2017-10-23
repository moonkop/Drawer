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
using Drawer.Classes;

namespace Drawer.Forms
{

    public partial class MainForm : Form
    {
        //所有的班级
        public List<Classroom> classAll = new List<Classroom>();
        //显示的班级
        public List<Classroom> classSelected = new List<Classroom>();
        //勾选的班级
        public List<Classroom> classMarked = new List<Classroom>();
        public List<Student> AllStudents = new List<Student>();
        public List<Student> stdSelected = new List<Student>();
        public List<Student> stdFound = new List<Student>();
        public List<Student> stdReady = new List<Student>();
        public List<System.Windows.Forms.CheckBox> CheckboxClassroom = new List<System.Windows.Forms.CheckBox>();
        public Random rd = new Random();
        public DateTime currentTime = new DateTime();
        SQLiteConnection conn = new SQLiteConnection();
        StatusPrintBuffer spb = new StatusPrintBuffer();
        public int seekNums;
        public int seekPointer;
        bool textBox4Changed;
        bool textBox2Changed;
        bool textBox3Changed;

        Drawer.Classes.Student.selectedType st;
        public Student Hitter;
        int maxnum;
        private bool checkBoxChanged;
        private string pastDBSHA1;
        private bool SECURITY_Enabled;

        public static MySettings Settings
        {
            get
            {
                return Assistance.Settings;
            }
        }

        public int get_Selected_counts(Student.selectedType st)
        {
            int count = 0;
            switch (st)
            {
                case Student.selectedType.Mutiply:
                    foreach (Student astd in stdSelected)
                    {
                        if (astd.Selected_Mutiply == true)
                        {
                            count++;
                        }
                    }
                    break;
                case Student.selectedType.Single:
                    foreach (Student astd in stdSelected)
                    {
                        if (astd.Selected_Single == true)
                        {
                            count++;
                        }
                    }
                    break;
                case Student.selectedType.Report:
                    foreach (Student astd in stdSelected)
                    {
                        if (astd.Selected_Report == true)
                        {
                            count++;
                        }
                    }
                    break;
                default:
                    break;
            }
            return count;

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
            classSelected = new List<Classroom>();
            foreach (var str1 in Assistance.Settings.classStrs)
            {
                Classroom cls = GetOrCreateClassroomById(str1);
                classSelected.Add(cls);
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

            foreach (Classroom cls in classSelected)
            {
                System.Windows.Forms.CheckBox tempckb = new System.Windows.Forms.CheckBox();
                tempckb = new System.Windows.Forms.CheckBox();
                tempckb.Height = checkBox1.Height;

                tempckb.Location = checkBox1.Location;
                tempckb.Top = top;

                tempckb.Size = checkBox1.Size;
                tempckb.Text = cls.ClassID;
                tempckb.Font = checkBox1.Font;
                tempckb.CheckedChanged += new System.EventHandler(this.ckb_CheckedChanged);
                CheckboxClassroom.Add(tempckb);

                top += 50;
                this.Controls.Add(tempckb);
            }
        }
        public void GetClassroomMarkStatus()
        {
            classMarked.Clear();
            foreach (CheckBox ckb in CheckboxClassroom)
            {
                if (ckb.Checked)
                {
                    Classroom cls = GetClassroomById(ckb.Text);
                    classMarked.Add(cls);
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
            TBOutput.AppendText(str + "\r\n");
            TBOutput.Visible = true;
            TBOutput.Select(TBOutput.Text.Length, 0);
            TBOutput.ScrollToCaret();
        }
        public void print(string str = "")
        {
            textBox1.Text += str + "\r\n";
        }
        /// <summary>
        /// 打印string在textbox1上
        /// </summary>
        /// <param name="str"></param>
        /// <param name="LR">换行为true 不换行为false</param>
        public void print(string str, int LR)
        {
            textBox1.AppendText(str + (LR == 0 ? "" : "\r\n"));
        }
        /// <summary>
        /// 把一个字符串按照分隔符分割
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="dest">第dest个分隔符后面</param>
        /// <param name="spilt">分隔符</param>
        /// <returns></returns>
        private void OutPutData()
        {
            Settings.dataOutPutPath = Settings.dataOutPutPath + currentTime.ToString("yyyy-mm-dd_hh.mm.ss") + ".csv";

            if (AllStudents.Count == 0)
            {
                ReadDataFromDatabase();
            }
            try
            {
                FileStream fs = new FileStream(Settings.dataOutPutPath, FileMode.Create);

                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                foreach (Student astd in AllStudents)
                {
                    sw.WriteLine(astd.Id + "," + astd.Name + "," + astd.Classroom.ClassID + "," + ((astd.Grade.ToString() != "-1") ? astd.Grade.ToString() : ""));
                }
                sw.Close();
                fs.Close();

                System.Diagnostics.Process.Start(@"explorer.exe", @"/e,/select," + Settings.dataOutPutPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        public void updateDataBase()
        {
            if (AllStudents.Count == 0)
            {
                return;
            }
            foreach (Student astd in AllStudents)
            {
                astd.Sha1 = astd.getSHA1();
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();
            SQLiteConnection conn = new SQLiteConnection();
            conn.ConnectionString = "Data source=" + Settings.DBpath;
            conn.Open();
            var cmd = conn.CreateCommand();
            StringBuilder tempCmd = new StringBuilder("replace  into students values");
            foreach (var astd in AllStudents)
            {
                tempCmd.Append(getStudentText(astd) + ",");
            }
            tempCmd.Remove(tempCmd.Length - 1, 1);
            cmd.CommandText = tempCmd.ToString();
            cmd.ExecuteNonQuery();
            // loadStudent();
            sw.Stop();
            var sw1 = new StreamWriter(Settings.SHA1ofDBpath, false);
            sw1.WriteLine(Assistance.GetSHA1Hash(Settings.DBpath));
            sw1.Close();
            spb.add("完成更新！用时" + sw.ElapsedMilliseconds + "ms");
        }
        string getStudentText(Student astd)
        {
            return "(" + "\"" +
                astd.Id + "\",\"" +
                astd.Name + "\",\"" +
                astd.Classroom.ClassID + "\"," +
                astd.Grade + ",\"" +
                astd.Sha1 + "\"," +
                astd.select_Mutiply_StatusGetint().ToString() + "," +
                astd.select_Single_StatusGetint().ToString() + "," +
                astd.select_Report_StatusGetint().ToString() + ")";
        }
        public void ExecuteSQLcommand(string cmd)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                var command = conn.CreateCommand();
                command.CommandText = cmd; ;

                var str = command.ExecuteScalar();
                if (str != null)
                {
                    MessageBox.Show(str.ToString());
                }
                else
                {
                    MessageBox.Show("执行完成");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void BindingDatas()
        {
            TextBoxMutiplyNum.Text = Settings.DefaultMutiplyDrawerNum.ToString();
            timer1.Interval = Settings.RollTimeInteval;

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
        public void DisplayStudentData(Student student)
        {
            TextBoxName.Text = student.Name;
            textBoxID.Text = student.Id;
            textBoxClassroom.Text = student.Classroom.ClassID;
            try
            {
                TBOutput.Visible = false;

                pictureBox1.Load(getPicturePathOrDefault(Settings.PicPath + student.Id + ".jpg"));
            }
            catch (Exception)
            {
                // pictureBox1.Load();

            }

        }
        /// <summary>
        /// 把没有抽到过的学生放到一个数组里面
        /// </summary>
        public int GetStudentsReady(Student.selectedType st)
        {
            if (stdSelected.Count == 0)
            {
                selectStudents();
            }
            stdReady.Clear();
            foreach (Student astd in stdSelected)
            {
                switch (st)
                {
                    case Student.selectedType.Mutiply:
                        if (!astd.Selected_Mutiply)
                        {
                            stdReady.Add(astd);
                        }
                        break;
                    case Student.selectedType.Single:
                        if (!astd.Selected_Single)
                        {
                            stdReady.Add(astd);
                        }
                        break;
                    case Student.selectedType.Report:
                        if (!astd.Selected_Report)
                        {
                            stdReady.Add(astd);
                        }
                        break;
                }
            }
            maxnum = stdReady.Count;
            return maxnum;
        }
        public void rollStd()
        {
            int zjz = rd.Next(maxnum);
            Hitter = stdReady[zjz];
            //stdReady.RemoveAt(zjz);
        }
        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Assistance.Init();
            Assistance.LoadSettings();
            BindingDatas();
            //NameNumLength = FileLength(numpath);
            spb.obj = toolStripStatusLabel1;
            pastDBSHA1 = Assistance.Settings.ShA1OfDB;
            if (SECURITY_Enabled == true)
            {
                if (pastDBSHA1 != Assistance.GetSHA1Hash(Settings.DBpath))
                {
                    var pib = new PasswordInputDialog(this, "检测到不安全的数据修改，请输入管理员密码", true);
                    pib.Owner = this;
                    pib.Show();
                }
            }
            conn.ConnectionString = "Data Source=" + Settings.DBpath;
            TBOutput.Location = pictureBox1.Location;
            TBOutput.Size = pictureBox1.Size;
            TBOutput.Visible = false;
            ReadDataFromDatabase();
            LoadConfig_SelectedClassroom();
            ShowSelectedClassroomCheckbox();

        }
        private void roll5Init(object sender, EventArgs e)//批量抽取
        {
            selectStudents();
            if (stdSelected.Count == 0)
            {
                MessageBox.Show("请选择班级");
                return;
            }
            int rollnum = 0;
            if (!int.TryParse(TextBoxMutiplyNum.Text, out rollnum))
            {
                MessageBox.Show("请输入数字");
                return;
            }

            if (radioButton1.Checked == true)//批量抽取 每周一问
            {
                st = Student.selectedType.Mutiply;
                if (GetStudentsReady(st) == 0)
                {
                    if (MessageBox.Show("每周一问已抽完，是否输出成绩并清空数据库？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        OutPutData();
                        foreach (Student astd in stdSelected)
                        {
                            astd.Selected_Mutiply = false;
                            astd.Grade = -1;
                        }
                        MessageBox.Show("成绩已保存至" + Settings.dataOutPutPath + "\n并清空");
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
                else if (rollnum > maxnum)
                {

                    MessageBox.Show("超过未抽取的人数，还有" + maxnum + "人可以抽取");
                    return;
                }
            }
            else//批量抽取 实验报告
            {
                st = Student.selectedType.Report;
                if (GetStudentsReady(st) == 0)
                {
                    if (MessageBox.Show("一轮已抽完 是否清空记录进行下一轮？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        foreach (Student astd in stdSelected)
                        {
                            astd.Selected_Report = false;
                        }
                        MessageBox.Show("清空完毕！");
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
                else if (rollnum > maxnum)
                {
                    MessageBox.Show("超过未抽取的人数，还有" + maxnum + "人可以抽取");
                    return;
                }
            }
            var roll5form = new roll5(this, rollnum, st);
            roll5form.Show();

        }
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
        public void stopRoll5(Student.selectedType st)
        {
            timer1.Enabled = false;
            if (get_Selected_counts(st) == stdSelected.Count)
            {
                stdSelected[0] = new Student();
                stdSelected[0].Id = "000000";
                stdSelected[0].Name = "NULL";
                stdSelected[0].Classroom = new Classroom("0000");
                stdSelected[0].Classroom.ClassID = "0000";
                Assistance.record("ERROR NO MORE STUDENTS");
                MessageBox.Show("没有更多的学生了");
                return;
            }
            else
            {
                DisplayStudentData(Hitter);
                switch (st)
                {
                    case Student.selectedType.Mutiply:
                        Hitter.Selected_Mutiply = true;
                        break;
                    case Student.selectedType.Report:
                        Hitter.Selected_Report = true;
                        break;
                    default:
                        break;
                }
                stdReady.Remove(Hitter);
                maxnum--;
            }
            Assistance.record(Hitter, "form roll5,selectTpye=" + st.ToString());
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

            stdFound.Clear();
            if (AllStudents.Count == 0)
            {
                ReadDataFromDatabase();
            }
            if (textBox2Changed == true)//按姓名完全匹配查找
            {
                foreach (Student astd in AllStudents)
                {
                    if (TextBoxName.Text == astd.Name)
                    {
                        stdFound.Add(astd);
                    }
                }

                if (stdFound.Count == 0)//按姓名查找未找到则转换为模糊查找
                {
                    foreach (Student astd in AllStudents)
                    {
                        if (astd.Name.IndexOf(TextBoxName.Text) != -1)
                        {
                            stdFound.Add(astd);
                        }
                    }
                }

            }
            if (textBox3Changed == true)//按学号查找
            {
                foreach (Student astd in AllStudents)
                {
                    if (astd.Id == textBoxID.Text || astd.Id.EndsWith(textBoxID.Text))
                    {
                        stdFound.Add(astd);
                    }
                }
            }

            if (textBox4Changed == true)//按班级查找
            {
                foreach (Student astd in AllStudents)
                {
                    if (textBoxClassroom.Text == "" || textBoxClassroom.Text == astd.Classroom.ClassID)
                    {
                        stdFound.Add(astd);
                    }
                }
                if (stdFound.Count == 0)//按班级查找未找到则转换为模糊查找
                {
                    foreach (Student astd in AllStudents)
                    {
                        if (astd.Classroom.ClassID.IndexOf(textBoxClassroom.Text) != -1)
                        {
                            stdFound.Add(astd);
                        }
                    }
                }
            }
            statusPrint(stdFound.Count + "人已找到");
            loadstuFound();

        }
        public void loadstuFound()
        {
            if (stdFound.Count != 0)
            {
                DisplayStudentData(stdFound[0]);
            }
            listViewResults.Items.Clear();
            foreach (Student astd in stdFound)
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
        private void selectStudents()
        {
            if (AllStudents.Count == 0)
            {
                ReadDataFromDatabase();
            }
            stdSelected.Clear();
            GetClassroomMarkStatus();
            foreach (Classroom cls in classMarked)
            {
                foreach (Student stu in cls.students)
                {
                    stdSelected.Add(stu);
                }
            }
            spb.add(stdSelected.Count + "人已选中");
            checkBoxChanged = false;
        }
        private Classroom GetClassroomById(string ClassroomId)
        {
            foreach (var aclassroom in classAll)
            {
                if (aclassroom.ClassID == ClassroomId)
                {
                    return aclassroom;
                }
            }
            return null;
        }
        private Classroom GetOrCreateClassroomById(string ClassroomId)
        {
            Classroom cls = GetClassroomById(ClassroomId);
            if (cls == null)
            {
                cls = new Classroom(ClassroomId);
                classAll.Add(cls);
            }
            return cls;
        }
        private Student GetStudentById(string id)
        {
            foreach (var student in AllStudents)
            {
                if (student.Id == id)
                {
                    return student;

                }
            }
            return null;
        }
        private void ReadDataFromDatabase()
        {
            if (AllStudents.Count != 0)
            {
                updateDataBase();
            }
            try
            {
                if (conn.State != ConnectionState.Open)
                {

                    spb.add("正在连接数据库");
                    conn.Open();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("数据库连接失败！");
            }
            try
            {
                spb.add("数据库连接成功");
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select * from students";
                var reader = cmd.ExecuteReader();
                AllStudents.Clear();
                while (reader.Read())
                {
                    Student tempstd = new Student();
                    tempstd.Id = reader.GetString(0);
                    tempstd.Name = reader.GetString(1);
                    string tempStrClassID = reader.GetString(2);
                    Classroom cls = GetOrCreateClassroomById(tempStrClassID);

                    cls.AddStudent(tempstd);
                    tempstd.Classroom = cls;
                    tempstd.Grade = reader.GetDouble(3);
                    tempstd.Sha1 = reader.GetString(4);
                    tempstd.Selected_Mutiply = reader.GetBoolean(5);
                    tempstd.Selected_Single = reader.GetBoolean(6);
                    tempstd.Selected_Report = reader.GetBoolean(7);
                    AllStudents.Add(tempstd);
                }
            }
            catch (Exception ex)
            {
                statusPrint(ex.Message);
            }
            if (SECURITY_Enabled == true)
            {
                foreach (Student astd in AllStudents)
                {
                    if (astd.getSHA1() != astd.Sha1)
                    {
                        DialogResult ok = MessageBox.Show(astd.Name + astd.Id + "\n的成绩遭到非法修改" + "为" + astd.Grade + "\n是否清空？", "警告！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (ok == DialogResult.Yes)
                        {
                            astd.Grade = -1;
                            astd.Selected_Mutiply = false;
                            updateDataBase();
                        }
                    }
                }
            }
            foreach (Student astd in AllStudents)
            {
                if (astd.Grade != -1 && astd.Selected_Mutiply == false)
                {
                    DialogResult ok = MessageBox.Show(astd.Name + astd.Id + "\n的成绩" + "为" + astd.Grade + "\n但未生成抽取记录，是否重新生成？", "警告！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (ok == DialogResult.Yes)
                    {
                        astd.Selected_Mutiply = true;
                        updateDataBase();
                    }
                }
            }

            spb.add(AllStudents.Count + "已读取");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            rollStd();
            DisplayStudentData(Hitter);
        }
        private void ckb_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxChanged = true;
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

            if (conn.State == System.Data.ConnectionState.Open)
            {
                updateDataBase();
                conn.Close();
            }
            CollectSettings();
            Assistance.StoreSettings();

        }
        private void buttonDeleteAll_Click(object sender, EventArgs e)
        {
            ReadDataFromDatabase();
            if (MessageBox.Show("此操作将删除所有学生的成绩并将实验报告抽取记录、课堂提问抽取记录，随机提问抽取记录清零，是否确定？", "警告:", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (Student astd in AllStudents)
                {
                    astd.Grade = -1;
                    astd.Selected_Mutiply = false;
                    astd.Selected_Report = false;
                    astd.Selected_Single = false;
                }
                updateDataBase();
            }
        }
        private void buttonStart_Click(object sender, EventArgs e) //开始按钮
        {
            if (stdSelected.Count == 0 || checkBoxChanged == true)
            {
                selectStudents();
            }
            if (stdSelected.Count == 0)
            {
                spb.add("请选择班级");
                //    getReady(Student.selectedType.Single);
                //    maxnum = stdReady.Count;
                //    timer1.Enabled = true;
            }
            if (GetStudentsReady(Student.selectedType.Single) == 0)
            {
                MessageBox.Show("所有学生已抽过，记录已清空");
                foreach (Student astd in stdSelected)
                {
                    astd.Selected_Single = false;
                }
            }
            else
            {
                timer1.Enabled = true;
            }
        }
        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            DisplayStudentData(Hitter);
            Hitter.Selected_Single = true;
            Assistance.record(Hitter, "from single ");
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
            listViewResults.ListViewItemSorter = new Drawer.ListViewItemComparer(e.Column, listViewResults.Sorting);
            listViewResults.Sort();

        }
        private void BTExcCmd_Click(object sender, EventArgs e)
        {
            ExecuteSQLcommand(textBox1.Text);
            ReadDataFromDatabase();
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
            ReadDataFromDatabase();
        }
        private void 保存数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateDataBase();
        }
        private void 导出数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OutPutData();
        }
        private void 执行命令ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (SECURITY_Enabled == true)
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
                        Classroom cls = GetClassroomById(astr);
                        if (cls == null)
                        {
                            if (MessageBox.Show("该班级" + astr + "尚未创建，是否创建？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                cls = new Classroom(astr);
                                classAll.Add(cls);
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
                            AllStudents.Remove(GetStudentById(newStudent.Id));
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

                AllStudents.Add(newStudent);
                loge("InputSuccess,Get: " + line);
                continue;
                ErrorHandler:
                loge("InputError,Get: " + line);

            }

        }
        private void 班级设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassPicker classPicker = new ClassPicker(classAll, classSelected);
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
            foreach (Classroom cls in classSelected)
            {
                Assistance.Settings.classStrs.Add(cls.ClassID);

            }

        }

        private void newMutiplyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new NewMutiplyDrawer().Show();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem itemSelected = listViewResults.SelectedItems[0];

            Student stuSelected = (Student)itemSelected.Tag;
            StudentStatus studentStatus = new StudentStatus(stuSelected);
            studentStatus.ShowDialog();
            UpdateListViewItemForStudent(itemSelected);

        }
    }
}

