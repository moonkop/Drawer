using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drawer.Forms;

namespace Drawer.Classes
{
    public class Classroom
    {
        public string classID;
        public bool selected;
        public List<Student> students;
        public Classroom(string classId)
        {
            this.classID = classId;
            students = new List<Student>();

        }
        public void AddStudent(Student stu)
        {
            students.Add(stu);
            stu.classroom = this;

        }
    }
}
