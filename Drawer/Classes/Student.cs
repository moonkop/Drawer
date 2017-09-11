using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drawer.Forms;

namespace Drawer.Classes
{
    public class Student
    {
        public string name;
        public string ID;
        public Classroom classroom;
        public double grade;
        public string sha1;
        public string sex;
        public string currentSHA1;
        private string picturePath;
        public bool selected_Mutiply;
        public bool selected_Single;
        public bool selected_Report;
        public string ReprotTime;

        public string PicturePath
        {
            get
            {
           //  return  Assistance.IsFileExist(picturePath)?picturePath:Assistance.def
         
                return picturePath;
            }

            set
            {
                picturePath = value;
            }
        }

        public enum selectedType
        {
            Mutiply = 1,
            Single = 2,
            Report = 3
        }
        public string getSHA1()
        {
            string str;
            str = this.ID + this.name + this.grade + MainForm.Settings.SHA1ofPASSWORD;
            currentSHA1 = Assistance.getSHA1ofString(str);
            return currentSHA1;
        }
        public int select_Mutiply_StatusGetint()
        {
            return selected_Mutiply == true ? 1 : 0;
        }
        public int select_Single_StatusGetint()
        {
            return selected_Single == true ? 1 : 0;
        }
        public int select_Report_StatusGetint()
        {
            return selected_Report == true ? 1 : 0;
        }
    }
}
