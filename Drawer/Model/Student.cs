using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drawer.Forms;
using Drawer.Untils;
using Drawer.Control;
using Drawer.Model;
using Drawer.UserControls;

namespace Drawer.Model
{
    public class Student
    {
        private string name;
        private string id;
        private Classroom classroom;
        private double grade;
        private string sha1Old;
        private string sex;
        private string picturePath;
        private bool selected_Mutiply;
        private bool selected_Single;
        private bool selected_Report;
        private string reprotTime;
        public string DefaultPicturePath
        {
            get
            {
                if (System.IO.File.Exists(Assistance.Settings.PicPath + this.Id + ".jpg"))
                {
                    return Assistance.Settings.PicPath + this.Id + ".jpg";
                }
                else
                {
                    return Assistance.Settings.PicPath +Assistance.Settings.defaultPicPath;
                }
            }
        }
        #region 属性
        public string Grade_ForReading
        {
            get
            {
                return grade == -1 ? "暂无" : grade.ToString();
            }
        }
        public string Selected_Mutiply_ForReading
        {
            get
            {
                return Selected_Mutiply == true ? "是" : "否";
            }
        }

        public string Selected_Single_ForReading
        {
            get
            {
                return Selected_Single == true ? "是" : "否";
            }
        }
        public string Selected_Report_ForReading
        {
            get
            {
                return Selected_Report == true ? "是" : "否";
            }
        }


        public string PicturePath
        {
            get
            {
                if (picturePath != null)
                {
                    return picturePath;
                }
                else if (System.IO.File.Exists(this.DefaultPicturePath))
                {
                    return DefaultPicturePath;
                }
                return "";
            }
            set
            {

                PicturePath = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public Classroom Classroom
        {
            get
            {
                return classroom;
            }

            set
            {
                classroom = value;
            }
        }

        public double Grade
        {
            get
            {
                return grade;
            }

            set
            {
                grade = value;
            }
        }

        public string Sha1Old
        {
            get
            {
                return sha1Old;
            }

            set
            {
                sha1Old = value;
            }
        }

        public string Sex
        {
            get
            {
                return sex;
            }

            set
            {
                sex = value;
            }
        }
        
        public bool Selected_Mutiply
        {
            get
            {
                return selected_Mutiply;
            }

            set
            {
                selected_Mutiply = value;
            }
        }

        public bool Selected_Single
        {
            get
            {
                return selected_Single;
            }

            set
            {
                selected_Single = value;
            }
        }

        public bool Selected_Report
        {
            get
            {
                return selected_Report;
            }

            set
            {
                selected_Report = value;
            }
        }

        public string ReprotTime
        {
            get
            {
                return reprotTime;
            }

            set
            {
                reprotTime = value;
            }
        }
        #endregion


        public string CurrentSHA1
        {
            get
            {
                string str;
                str = this.Id + this.Name + this.Grade + MainForm.Settings.SHA1ofPASSWORD;
                return Assistance.getSHA1ofString(str);
            }
        }
        public string UpdateSHA1()
        {
            return this.sha1Old = this.CurrentSHA1;
        }

        public int Select_Mutiply_StatusGetint()
        {
            return Selected_Mutiply == true ? 1 : 0;
        }
        public int Select_Single_StatusGetint()
        {
            return Selected_Single == true ? 1 : 0;
        }
        public int Select_Report_StatusGetint()
        {
            return Selected_Report == true ? 1 : 0;
        }
    }

    public enum SelectedType
    {
        Mutiply = 1,
        Single = 2,
        Report = 3
    }
}
