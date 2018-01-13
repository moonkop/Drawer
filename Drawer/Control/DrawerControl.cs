using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Drawer.Untils;
using Drawer.Control;
using Drawer.Model;
using Drawer.UserControls;
using System.Data.SQLite;
using System.IO;
using Drawer.Forms;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data;

namespace Drawer.Control
{
    public class DrawerControl
    {
        //所有的班级
        public List<Classroom> classAll;
        //显示的班级
        public List<Classroom> classSelected;
        //勾选的班级
        public List<Classroom> classMarked;

        public List<Student> AllStudents;
        public List<Student> stdSelected;
        public List<Student> stdFound;
        public List<Student> stdReady;
        public LogForm logForm;
        public MainForm mainform;

        public StringBuilder logBuffer;
        private SQLiteConnection conn;

        private bool SECURITY_Enabled;

        public DrawerControl()
        {

            classAll = new List<Classroom>();
            classSelected = new List<Classroom>();
            classMarked = new List<Classroom>();
            AllStudents = new List<Student>();
            stdSelected = new List<Student>();
            stdFound = new List<Student>();
            stdReady = new List<Student>();
            conn = new SQLiteConnection();
            logBuffer = new StringBuilder();

            Assistance.Init();
            Assistance.LoadSettings();
            conn.ConnectionString = "Data Source=" + Assistance.Settings.DBpath;


        }
        public int Get_Selected_counts(SelectedType st)
        {
            int count = 0;
            switch (st)
            {
                case SelectedType.Mutiply:
                    foreach (Student astd in stdSelected)
                    {
                        if (astd.Selected_Mutiply == true)
                        {
                            count++;
                        }
                    }
                    break;
                case SelectedType.Single:
                    foreach (Student astd in stdSelected)
                    {
                        if (astd.Selected_Single == true)
                        {
                            count++;
                        }
                    }
                    break;
                case SelectedType.Report:
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
        public void OutPutData()
        {
            Assistance.Settings.dataOutPutPath = Assistance.Settings.dataOutPutPath + DateTime.Now.ToString("yyyy-mm-dd_hh.mm.ss") + ".csv";

            if (AllStudents.Count == 0)
            {
                ReadDataFromDatabase();
            }
            try
            {
                FileStream fs = new FileStream(Assistance.Settings.dataOutPutPath, FileMode.Create);

                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                foreach (Student astd in AllStudents)
                {
                    sw.WriteLine(astd.Id + "," + astd.Name + "," + astd.Classroom.ClassID + "," + ((astd.Grade.ToString() != "-1") ? astd.Grade.ToString() : ""));
                }
                sw.Close();
                fs.Close();

                System.Diagnostics.Process.Start(@"explorer.exe", @"/e,/select," + Assistance.Settings.dataOutPutPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        public void UpdateDataBase()
        {
            if (AllStudents.Count == 0)
            {
                return;
            }
            foreach (Student astd in AllStudents)
            {
                astd.UpdateSHA1();
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();
            SQLiteConnection conn = new SQLiteConnection();
            conn.ConnectionString = "Data source=" + Assistance.Settings.DBpath;
            conn.Open();
            var cmd = conn.CreateCommand();
            StringBuilder tempCmd = new StringBuilder("replace  into students values");
            foreach (var astd in AllStudents)
            {
                tempCmd.Append(GetStudentText(astd) + ",");
            }
            tempCmd.Remove(tempCmd.Length - 1, 1);
            cmd.CommandText = tempCmd.ToString();
            cmd.ExecuteNonQuery();
            // loadStudent();
            sw.Stop();
            var sw1 = new StreamWriter(Assistance.Settings.SHA1ofDBpath, false);
            sw1.WriteLine(Assistance.GetSHA1Hash(Assistance.Settings.DBpath));
            sw1.Close();
            mainform.spb.add("完成更新！用时" + sw.ElapsedMilliseconds + "ms");
        }
        public string GetStudentText(Student astd)
        {
            return "(" + "\"" +
                astd.Id + "\",\"" +
                astd.Name + "\",\"" +
                astd.Classroom.ClassID + "\"," +
                astd.Grade + ",\"" +
                astd.Sha1Old + "\"," +
                astd.Select_Mutiply_StatusGetint().ToString() + "," +
                astd.Select_Single_StatusGetint().ToString() + "," +
                astd.Select_Report_StatusGetint().ToString() + ")";
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
        public Classroom GetClassroomById(string ClassroomId)
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

        public Classroom GetOrCreateClassroomById(string ClassroomId)
        {
            Classroom cls = GetClassroomById(ClassroomId);
            if (cls == null)
            {
                cls = new Classroom(ClassroomId);
                classAll.Add(cls);
            }
            return cls;
        }

        public void ReadDataFromDatabase()
        {
            if (AllStudents.Count != 0)
            {
                UpdateDataBase();
            }
            try
            {
                if (conn.State != ConnectionState.Open)
                {

                    Log("正在连接数据库");
                    conn.Open();
                }
            }
            catch (Exception)
            {

                LogAndShow("数据库连接失败！");
            }
            try
            {
                Log("数据库连接成功");
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
                    tempstd.Sha1Old = reader.GetString(4);
                    tempstd.Selected_Mutiply = reader.GetBoolean(5);
                    tempstd.Selected_Single = reader.GetBoolean(6);
                    tempstd.Selected_Report = reader.GetBoolean(7);
                    AllStudents.Add(tempstd);
                }
            }
            catch (Exception ex)
            {
                LogAndShow(ex.Message);
            }
            if (SECURITY_Enabled == true)
            {
                foreach (Student astd in AllStudents)
                {
                    if (astd.CurrentSHA1 != astd.Sha1Old)
                    {
                        DialogResult ok = MessageBox.Show(astd.Name + astd.Id + "\n的成绩遭到非法修改" + "为" + astd.Grade + "\n是否清空？", "警告！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (ok == DialogResult.Yes)
                        {
                            astd.Grade = -1;
                            astd.Selected_Mutiply = false;
                            UpdateDataBase();
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
                        UpdateDataBase();
                    }
                }
            }

Log(AllStudents.Count + "已读取");
        }
        public void CloseConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                UpdateDataBase();
                conn.Close();
            }
        }
        public void OpenConnection()
        {

        }
        public void Log<T>(T str)
        {
            logBuffer.AppendLine(str.ToString());
            if (logForm != null)
            {
                logForm.RefreshLog();

            }
        }
        public void LogAndShow<T>(T str)
        {
            ShowLogForm();
            Log(str);
        }
        public void ShowLogForm()
        {
            if (logForm == null)
            {
                logForm = new LogForm(logBuffer);
            }
            logForm.Show();
            logForm.TopMost = true;
           

        }

    }
}
