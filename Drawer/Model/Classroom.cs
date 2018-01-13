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
    public class Classroom
    {
        private string classID;
        private bool selected;
        public List<Student> students;

        public string ClassID
        {
            get
            {
                return classID;
            }

            set
            {
                classID = value;
            }
        }

        public bool Selected
        {
            get
            {
                return selected;
            }

            set
            {
                selected = value;
            }
        }

        public Classroom(string classId)
        {
            this.ClassID = classId;
            students = new List<Student>();

        }
        public void AddStudent(Student stu)
        {
            students.Add(stu);
            stu.Classroom = this;

        }
    }
}
