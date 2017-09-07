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

namespace WindowsFormsApplication1
{
        public partial class Form1 : Form
        {
                public static string PASSWORD;
                public static string SHA1ofPASSWORD = "54F8C89CE615405C74493D35CDD01BB875ED7428";
                public bool ready;

                public static bool useTxtForDatabase;
                public int zjz;
                public int NameNumLength;
                public int classroomNumber;
                public string LogPath;
                public string numpath;
                public string PicPath;
                public string DBpath;
                public string SHA1ofDBpath;
                public string pastDBSHA1;
                public bool checkBoxChanged;
                public static string ConfigPath = System.Environment.CurrentDirectory + @"\config.cfg";
                public static Classroom[] classrooms = new Classroom[20];
                public Student[] std = new Student[500];
                public Student[] stdSelected = new Student[500];
                public Random rd = new Random();
                public CheckBox[] ckb = new CheckBox[20];
                private int studentsSelectedNum;
                public DateTime currentTime = new DateTime();
                SQLiteConnection conn = new SQLiteConnection();
                statusPrintBuffer spb = new statusPrintBuffer();
                //----------查找
                public Student[] stdFound = new Student[500];
                public int seekNums;
                public int seekPointer;
                bool textBox4Changed;
                bool textBox2Changed;
                bool textBox3Changed;
                public ListViewItem createListViewItem(Student std1, int index)
                {
                        ListViewItem lv = new ListViewItem();
                        lv.Text = index.ToString();
                        lv.SubItems.Add(std1.classroom.classID);
                        lv.SubItems.Add(std1.name);
                        lv.SubItems.Add(std1.num);
                        if (std1.grade != -1)
                        {
                                lv.SubItems.Add(std1.grade.ToString());

                        }
                        else
                        {
                                lv.SubItems.Add("暂无");
                        }
                        lv.SubItems.Add(std1.selected == true ? "是" : "否");

                        return lv;
                }
                public static string GetSHA1Hash(string pathName)
                {
                        string strResult = "";
                        string strHashData = "";
                        byte[] arrbytHashValue;

                        System.IO.FileStream oFileStream = null;

                        System.Security.Cryptography.SHA1CryptoServiceProvider osha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
                        try
                        {
                                oFileStream = new System.IO.FileStream(pathName.Replace("\"", ""), System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);

                                arrbytHashValue = osha1.ComputeHash(oFileStream); //计算指定Stream 对象的哈希值

                                oFileStream.Close();

                                //由以连字符分隔的十六进制对构成的String，其中每一对表示value 中对应的元素；例如“F-2C-4A”

                                strHashData = System.BitConverter.ToString(arrbytHashValue);

                                //替换-
                                strHashData = strHashData.Replace("-", "");

                                strResult = strHashData;
                        }

                        catch (System.Exception ex)
                        {
                                Console.WriteLine(ex.Message);
                        }
                        return strResult;
                }
                public static string getSHA1ofString(string strclean)
                {
                        byte[] btclean = Encoding.Default.GetBytes(strclean);
                        byte[] bt = SHA1.Create().ComputeHash(btclean);
                        return BitConverter.ToString(bt).Replace("-", "");

                }
                public void studentSecurtiyCheck()
                {

                }

                public void loadClassroom()
                {
                        string str = processConfig(ConfigPath, "classroom");
                        string[] strs = str.Split(',');
                        classroomNumber = 0;
                        int top = checkBox1.Top;
                        int left = checkBox1.Left;
                        checkBox1.Visible = false;

                        foreach (var str1 in strs)
                        {
                                classroomNumber++;
                                ckb[classroomNumber] = new CheckBox();
                                ckb[classroomNumber].Height = checkBox1.Height;

                                ckb[classroomNumber].Top = top;
                                ckb[classroomNumber].Left = left;
                                ckb[classroomNumber].Text = str1;
                                ckb[classroomNumber].Font = checkBox1.Font;
                                ckb[classroomNumber].CheckedChanged += new System.EventHandler(this.ckb_CheckedChanged);
                                top += 50;
                                this.Controls.Add(ckb[classroomNumber]);
                                classrooms[classroomNumber] = new Classroom();
                                classrooms[classroomNumber].classID = str1;
                                classrooms[classroomNumber].selected = false;
                        }
                }
                public void selectClassroom()
                {

                        for (int i = 1; i <= classroomNumber; i++)
                        {

                                {
                                        classrooms[i].selected = ckb[i].Checked;
                                        //  print(classrooms[i].selected);
                                }

                        }
                }
                public static string processConfig(string configPath, string option)
                {

                        try
                        {
                                string str = "";
                                FileStream file = new FileStream(configPath, FileMode.Open);
                                StreamReader sr = new StreamReader(file, Encoding.Default);
                                do
                                {
                                        str = sr.ReadLine();
                                        if (str.StartsWith(option + "="))
                                        {
                                                sr.Close();
                                                file.Close();
                                                return str.Substring(str.IndexOf("=") + 1);
                                        }
                                } while (str != null);

                                sr.Close();
                                file.Close();
                                return "NULL";
                        }
                        catch (Exception ex)
                        {
                                MessageBox.Show(ex.Message);
                                return "NULL";

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
                public void print<T>(T str)
                {
                        textBox1.Text += str + "\r\n";
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
                        textBox1.Text += str + (LR == 0 ? "" : "\r\n");
                }
                /// <summary>
                /// 把一个字符串按照分隔符分割
                /// </summary>
                /// <param name="str">字符串</param>
                /// <param name="dest">第dest个分隔符后面</param>
                /// <param name="spilt">分隔符</param>
                /// <returns></returns>
                public string cutstrs(string str, int dest, char spilt = ' ')
                {
                        try
                        {
                                string[] s = str.Split(spilt);
                                return s[dest];
                        }
                        catch (Exception ex)
                        {
                                return ex.Message;
                        }
                }
                public string readln(string path, long line)
                {
                        try
                        {
                                var file = new FileStream(path, FileMode.Open);
                                StreamReader sr = new StreamReader(file, Encoding.Default);
                                string strline = "";
                                for (int i = 0; i < line; i++)
                                {
                                        strline = sr.ReadLine();
                                }
                                sr.Close();
                                return strline;
                        }
                        catch (Exception ex)
                        {
                                MessageBox.Show(ex.Message);
                                return "failure";

                        }

                }
                public void writeln(string path, string str)
                {
                        StreamWriter sw = new StreamWriter(path, true);
                        sw.WriteLine(str);
                        sw.Close();
                }
                public void record(string path)
                {
                        currentTime = DateTime.Now;
                        writeln(path,
                            currentTime.ToString() + "|" +
                            stdSelected[zjz].classroom.classID + "|" +
                            stdSelected[zjz].name + "|" +
                            stdSelected[zjz].num);
                }
                public int FileLength(string path)
                {
                        var file = new FileStream(path, FileMode.Open);
                        var sr = new StreamReader(file, Encoding.Default);

                        int i = 0;
                        bool IsEndOfFile;
                        do
                        {
                                IsEndOfFile = (sr.ReadLine() != null);
                                i++;
                        } while (IsEndOfFile);
                        sr.Close();
                        file.Close();

                        return i - 1;

                }
                public bool doRepeat(string path, string str)
                {
                        for (int i = 1; i < FileLength(LogPath) + 1; i++)
                        {
                                if (str == cutstrs(readln(path, i), 3, '|'))
                                {
                                        return true;
                                }
                        }
                        return false;
                }
                public void updateDataBase()
                {
                        for (int i = 1; i <= NameNumLength; i++)
                        {
                                std[i].sha1 = std[i].getSHA1();
                        }
                        Stopwatch sw = new Stopwatch();
                        sw.Start();
                        SQLiteConnection conn = new SQLiteConnection();
                        conn.ConnectionString = "Data source=" + DBpath;
                        conn.Open();
                        var cmd = conn.CreateCommand();
                        cmd.CommandText = "replace  into students values(" + "\"" + std[1].num + "\",\"" + std[1].name + "\",\"" + std[1].classroom.classID + "\"," + std[1].grade + ",\"" + std[1].sha1 + "\"," + std[1].selectStatusGetint().ToString() + ")";
                        for (int i = 2; i <= NameNumLength; i++)
                        {
                                cmd.CommandText += ",(" + "\"" + std[i].num + "\",\"" + std[i].name + "\",\"" + std[i].classroom.classID + "\"," + std[i].grade + ",\"" + std[i].sha1 + "\"," + std[i].selectStatusGetint().ToString() + ")";
                                //print(cmd.CommandText);
                        }
                        cmd.ExecuteNonQuery();
                        // loadStudent();
                        sw.Stop();
                        var sw1 = new StreamWriter(SHA1ofDBpath, false);
                        sw1.WriteLine(GetSHA1Hash(DBpath));
                        sw1.Close();
                        spb.add("完成更新！用时" + sw.ElapsedMilliseconds + "ms");
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
                public void loadStudent()
                {
                        var conn = new SQLiteConnection();
                        conn.ConnectionString = "Data source=" + DBpath;
                        conn.Open();
                        var cmd = conn.CreateCommand();
                        cmd.CommandText = "select * from students";
                        var reader = cmd.ExecuteReader();
                        int i = 0;
                        while (reader.Read())
                        {
                                i++;
                                std[i] = new Student();
                                std[i].classroom = new Classroom();
                                std[i].num = reader.GetString(0);
                                std[i].classroom.classID = reader.GetString(2);
                                std[i].name = reader.GetString(1);
                                //std[i].grade = reader.GetInt32(3);
                        }
                }
                public void Loadconfig(string path)
                {
                        try
                        {
                                loadClassroom();
                                LogPath = System.Environment.CurrentDirectory + processConfig(ConfigPath, "logpath");
                                numpath = System.Environment.CurrentDirectory + processConfig(ConfigPath, "numpath");
                                PicPath = System.Environment.CurrentDirectory + processConfig(ConfigPath, "picpath");
                                DBpath = System.Environment.CurrentDirectory + processConfig(ConfigPath, "DBpath");
                                SHA1ofDBpath = System.Environment.CurrentDirectory + processConfig(ConfigPath, "SHA1ofDBpath");
                                timer1.Interval = int.Parse(processConfig(ConfigPath, "timerinterval"));
                                textBox5.Text = processConfig(ConfigPath, "defaultMutiplySelectCount");
                                if (processConfig(ConfigPath,"singleSelectIsAllowed")=="false")
                                {
                                        button3.Enabled = false;
                                        button2.Enabled = false;
                                }
                        }
                        catch (Exception ex)
                        {
                                MessageBox.Show(ex.Message);
                        }
                }
                public void showData(Student student)
                {
                        textBox2.Text = student.name;
                        textBox3.Text = student.num;
                        textBox4.Text = student.classroom.classID;
                        try
                        {
                                pictureBox1.Load(PicPath + student.num + ".jpg");
                        }
                        catch (Exception ex)
                        {
                                print(ex.Message);
                        }
                }
                public void roll()
                {
                        zjz = rd.Next() % (studentsSelectedNum) + 1;

                }
                public Form1()
                {
                        InitializeComponent();
                        CheckForIllegalCrossThreadCalls = false;

                }
                private void Form1_Load(object sender, EventArgs e)
                {

                        Loadconfig(ConfigPath);

                        //NameNumLength = FileLength(numpath);
                        listView1.FullRowSelect = true;

                        #region 初始化listview
                        ColumnHeader ch1 = new ColumnHeader();
                        ch1.Text = "序号";
                        ch1.Width = 40;
                        ch1.TextAlign = HorizontalAlignment.Left;
                        this.listView1.Columns.Add(ch1);
                        ColumnHeader ch2 = new ColumnHeader();
                        ch2.Text = "班级";
                        ch2.Width = 100;
                        ch2.TextAlign = HorizontalAlignment.Left;
                        this.listView1.Columns.Add(ch2);
                        ColumnHeader ch3 = new ColumnHeader();
                        ch3.Text = "姓名";
                        ch3.Width = 100;
                        ch3.TextAlign = HorizontalAlignment.Left;
                        this.listView1.Columns.Add(ch3);
                        ColumnHeader ch4 = new ColumnHeader();
                        ch4.Text = "学号";
                        ch4.Width = 100;
                        ch4.TextAlign = HorizontalAlignment.Left;
                        this.listView1.Columns.Add(ch4);
                        ColumnHeader ch5 = new ColumnHeader();
                        ch5.Text = "成绩";
                        ch5.Width = 50;
                        ch5.TextAlign = HorizontalAlignment.Left;
                        this.listView1.Columns.Add(ch5);
                        ColumnHeader ch6 = new ColumnHeader();
                        ch6.Text = "已抽";
                        ch6.Width = 50;
                        ch6.TextAlign = HorizontalAlignment.Left;
                        this.listView1.Columns.Add(ch6);
                        #endregion
                        spb.obj = toolStripStatusLabel1;
                        pastDBSHA1 = readln(SHA1ofDBpath, 1);
                        if (pastDBSHA1 != GetSHA1Hash(DBpath))
                        {
                                var pib = new passwordInputBox(this, "检测到不安全的数据修改，请输入管理员密码", true);
                                pib.Owner = this;
                                pib.Show();

                        }
                        conn.ConnectionString = "Data Source=" + DBpath;
                }
                private void button1_Click(object sender, EventArgs e)
                {
                        selectClassroom();

                        studentsSelectedNum = 0;
                        for (int i = 1; i < NameNumLength; i++)
                        {
                                std[i] = new Student();
                                std[i].classroom = new Classroom();
                                std[i].classroom.classID = cutstrs(readln(numpath, i), 0);
                                std[i].num = cutstrs(readln(numpath, i), 1);
                                std[i].name = cutstrs(readln(numpath, i), 2);
                                for (int j = 1; j <= classroomNumber; j++)
                                {
                                        if (std[i].classroom.classID == classrooms[j].classID && classrooms[j].selected == true)
                                        {
                                                std[i].classroom.selected = classrooms[j].selected;
                                                studentsSelectedNum++;
                                                stdSelected[studentsSelectedNum] = new Student();
                                                stdSelected[studentsSelectedNum].classroom = new Classroom();
                                                stdSelected[studentsSelectedNum] = std[i];
                                        }
                                }
                        }
                        if (stdSelected[1] == null)
                        {
                                spb.add("请选择班级");
                        }
                        checkBoxChanged = false;
                }
                public void button2_Click(object sender, EventArgs e)
                {

                        if (stdSelected[1] == null || checkBoxChanged == true)
                        {
                                button8_Click(null, EventArgs.Empty);
                        }
                        if (stdSelected[1] != null)
                        {
                                timer1.Enabled = true;
                                ready = false;

                        }
                        else spb.add("请选择班级");
                }
                public void button3_Click(object sender, EventArgs e)
                {
                        timer1.Enabled = false;
                        while (stdSelected[zjz].selected == true)
                        {
                                roll();
                                showData(stdSelected[zjz]);
                        }
                        stdSelected[zjz].selected = true;

                        record(LogPath);
                        ready = true;


                }
                private void button4_Click(object sender, EventArgs e)
                {
                        listView1.Visible = true;
                        listView1.View = View.Details;

                        button6.Visible = true;
                        seekNums = 0;

                        if (std[1] == null)
                        {
                                button8_Click(null, EventArgs.Empty);

                        }


                        string[] str2 = new string[500];
                        string[] str3 = new string[500];
                        for (int i = 1; i <= NameNumLength; i++)
                        {
                                str2[i] = std[i].num.Substring(8, 2);
                                str3[i] = std[i].num.Substring(7, 3);
                        }
                        if (textBox2Changed == true)
                        {
                                for (int i = 1; i <= NameNumLength; i++)
                                {
                                        if (textBox2.Text == std[i].name)
                                        {
                                                seekNums++;
                                                stdFound[seekNums] = new Student();
                                                stdFound[seekNums].classroom = new Classroom();
                                                stdFound[seekNums] = std[i];
                                        }
                                }
                        }
                        if (textBox3Changed == true)
                        {
                                for (int i = 1; i <= NameNumLength; i++)
                                {
                                        if (textBox3.Text == std[i].num || textBox3.Text == str3[i] || textBox3.Text == str2[i])
                                        {
                                                seekNums++;
                                                stdFound[seekNums] = new Student();
                                                stdFound[seekNums].classroom = new Classroom();
                                                stdFound[seekNums] = std[i];

                                        }
                                }
                        }
                        if (textBox4Changed == true)
                        {
                                for (int i = 1; i <= NameNumLength; i++)
                                {
                                        if (textBox4.Text == std[i].classroom.classID)
                                        {
                                                seekNums++;
                                                stdFound[seekNums] = new Student();
                                                stdFound[seekNums].classroom = new Classroom();
                                                stdFound[seekNums] = std[i];
                                        }
                                }
                        }
                        if (seekNums==0&&textBox2Changed==true)
                        {
                                for (int i = 1; i <= NameNumLength; i++)
                                {
                                        if (std[i].name.IndexOf(textBox2.Text)!=-1 )
                                        {
                                                seekNums++;
                                                stdFound[seekNums] = new Student();
                                                stdFound[seekNums].classroom = new Classroom();
                                                stdFound[seekNums] = std[i];
                                        }
                                }
                        }
                        statusPrint(seekNums.ToString() + "人已找到");
                        if (seekNums != 0)
                        {
                                showData(stdFound[seekNums]);

                        }
                        listView1.Items.Clear();

                        for (int i = 1; i <= seekNums; i++)
                        {
                                listView1.Items.Add(createListViewItem(stdFound[i], i));
                        }
                }
                private void button5_Click_1(object sender, EventArgs e)
                {
                        updateDataBase();

                }
                private void button6_Click(object sender, EventArgs e)
                {
                        listView1.Visible = false;
                        button6.Visible = false;

                }
                private void button8_Click(object sender, EventArgs e)
                {
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
                        selectClassroom();
                        studentsSelectedNum = 0;

                        try
                        {
                                spb.add("数据库连接成功");
                                var cmd = conn.CreateCommand();
                                cmd.CommandText = "select * from students";
                                var reader = cmd.ExecuteReader();
                                NameNumLength = 0;
                                while (reader.Read())
                                {
                                        NameNumLength++;
                                        std[NameNumLength] = new Student();
                                        std[NameNumLength].classroom = new Classroom();
                                        std[NameNumLength].num = reader.GetString(0);
                                        std[NameNumLength].name = reader.GetString(1);
                                        std[NameNumLength].classroom.classID = reader.GetString(2);
                                        std[NameNumLength].grade = reader.GetDouble(3);
                                        std[NameNumLength].sha1 = reader.GetString(4);
                                        std[NameNumLength].selected = reader.GetBoolean(5);
                                        for (int j = 1; j <= classroomNumber; j++)
                                        {
                                                if (std[NameNumLength].classroom.classID == classrooms[j].classID && classrooms[j].selected == true)
                                                {
                                                        std[NameNumLength].classroom.selected = classrooms[j].selected;
                                                        studentsSelectedNum++;
                                                        stdSelected[studentsSelectedNum] = new Student();
                                                        stdSelected[studentsSelectedNum].classroom = new Classroom();
                                                        stdSelected[studentsSelectedNum] = std[NameNumLength];
                                                }
                                        }
                                }

                        }


                        catch (Exception ex)
                        {
                                statusPrint(ex.Message);
                        }
                        for (int i = 1; i <= NameNumLength; i++)
                        {
                                if (std[i].getSHA1() != std[i].sha1)
                                {
                                        DialogResult ok = MessageBox.Show(std[i].name + std[i].num + "\n的成绩遭到非法修改" + "为" + std[i].grade + "\n是否清空？", "警告！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                        if (ok == DialogResult.Yes)
                                        {
                                                std[i].grade = -1;
                                                std[i].selected = false;
                                                updateDataBase();
                                        }
                                }
                        }
                        if (stdSelected[1] == null)
                        {
                                spb.add("请选择班级");
                        }
                        spb.add(NameNumLength.ToString() + "已读取," + studentsSelectedNum.ToString() + "已选中");


                        checkBoxChanged = false;
                }
                private void timer1_Tick(object sender, EventArgs e)
                {
                        roll();
                        showData(stdSelected[zjz]);
                }
                private void listView1_SelectedIndexChanged(object sender, EventArgs e)
                {

                }
                private void pictureBox1_Click(object sender, EventArgs e)
                {

                }
                private void ckb_CheckedChanged(object sender, EventArgs e)
                {
                        //MessageBox.Show(((CheckBox)sender).Text+"was clicked");

                        string number = (sender as CheckBox).Text;
                        checkBoxChanged = true;

                }
                private void checkBox1_CheckedChanged(object sender, EventArgs e)
                {

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
                private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
                {

                        var i = listView1.SelectedItems;
                        if (i.Count != 0)
                        {
                                showData(stdFound[int.Parse(i[0].Text)]);
                        }
                }
                private void Form1_FormClosing(object sender, FormClosingEventArgs e)
                {

                        if (conn.State == System.Data.ConnectionState.Open)
                        {
                                conn.Close();

                                updateDataBase();
                        }


                        // int i = 0;
                        //while (conn.State != ConnectionState.Closed && i < 1000)
                        //{
                        //    conn.Close();
                        //    i++;
                        //}
                        //if (i >= 1000)
                        //{
                        //    MessageBox.Show("无法安全关闭与数据库的连接");
                        //}
                        //else
                        //{
                        //    var sw = new StreamWriter(SHA1ofDBpath, false);
                        //    sw.WriteLine(GetSHA1Hash(DBpath));
                        //    sw.Close();
                        //}
                }




                private void button7_Click(object sender, EventArgs e)
                {

                        button8_Click(null, EventArgs.Empty);

                        if (stdSelected[1] == null)
                        {
                                MessageBox.Show("请选择班级");
                        }
                        else
                        {
                                try
                                {
                                        var roll5form = new roll5(this, int.Parse(textBox5.Text));
                                        roll5form.Show();
                                }
                                catch (Exception)
                                {
                                        MessageBox.Show("请输入数字");

                                }
                        }
                }

                private void button9_Click(object sender, EventArgs e)
                {
                        if (textBox1.Enabled == false)
                        {
                                var pib = new passwordInputBox(this, "请输入密码以执行命令", true);
                                pib.Show();

                                textBox1.Enabled = true;
                                textBox1.Visible = true;
                                button11.Enabled = true;
                                button11.Visible = true;

                                this.Width = 1215;
                                button9.Left = textBox1.Left;

                        }
                        else
                        {

                                ExecuteSQLcommand(textBox1.Text);
                                button8_Click(null, EventArgs.Empty);

                        }

                }

                private void button10_Click(object sender, EventArgs e)
                {
                        if (std[1] == null)
                        {
                                button8_Click(null, EventArgs.Empty);
                        }
                        StreamWriter sw = new StreamWriter(numpath);

                        for (int i = 1; i <= NameNumLength; i++)
                        {
                                sw.WriteLine(std[i].num + "\t" + std[i].name + "\t" + std[i].classroom.classID + "\t" + std[i].grade);
                        }
                        sw.Close();

                }

                private void button11_Click(object sender, EventArgs e)
                {
                        button8_Click(null, EventArgs.Empty);

                        if (MessageBox.Show("您确定要清空吗?","警告:",MessageBoxButtons.YesNo)==DialogResult.Yes)
                        {
                                for (int i =1; i < NameNumLength; i++)
                                {
                                        std[i].grade = -1;
                                        std[i].selected = false;

                                }
                                updateDataBase();

                               
                        }
                      

                }

                private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
                {

                }

                private void textBox5_TextChanged(object sender, EventArgs e)
                {

                }

        }
        public class Student
        {
                public string name;
                public string num;
                public Classroom classroom;
                public double grade;
                public string sha1;
                public string sex;
                public string currentSHA1;
                public bool selected;
                public string getSHA1()
                {
                        string str;
                        str = this.num + this.name + this.grade + Form1.SHA1ofPASSWORD;
                        currentSHA1 = Form1.getSHA1ofString(str);
                        return currentSHA1;
                }
                public int selectStatusGetint()
                {
                        return selected == true ? 1 : 0;
                }
        }
        public class Classroom
        {
                public string classID;
                public bool selected;
        }
}

