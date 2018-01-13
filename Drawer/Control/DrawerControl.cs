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
        public List<Classroom> classAll = new List<Classroom>();
        //显示的班级
        public List<Classroom> classSelected = new List<Classroom>();
        //勾选的班级
        public List<Classroom> classMarked = new List<Classroom>();
        public List<Student> AllStudents = new List<Student>();
        public List<Student> stdSelected = new List<Student>();
        public List<Student> stdFound = new List<Student>();
        public List<Student> stdReady = new List<Student>();
        SQLiteConnection conn = new SQLiteConnection();
        public MainForm mainform;
        private bool SECURITY_Enabled;
        public DrawerControl()
        {
conn.ConnectionString = "Data Source=" + Assistance.Settings.DBpath;
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
            conn.ConnectionString = "Data source=" + Assistance.Settings.DBpath;
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
            var sw1 = new StreamWriter(Assistance.Settings.SHA1ofDBpath, false);
            sw1.WriteLine(Assistance.GetSHA1Hash(Assistance.Settings.DBpath));
            sw1.Close();
            mainform.spb.add("完成更新！用时" + sw.ElapsedMilliseconds + "ms");
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
                updateDataBase();
            }
            try
            {
                if (conn.State != ConnectionState.Open)
                {

                    mainform.spb.add("正在连接数据库");
                    conn.Open();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("数据库连接失败！");
            }
            try
            {
               mainform. spb.add("数据库连接成功");
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
                mainform.statusPrint(ex.Message);
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

            mainform.spb.add(AllStudents.Count + "已读取");
        }
        public void CloseConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                updateDataBase();
                conn.Close();
            }
        }
        public void OpenConnection()
        {

        }

    }
}
