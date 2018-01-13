using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Drawer.Model;

namespace Drawer.UserControls
{
    public partial class MutiplyDrawerItem : UserControl
    {
        Student student;
        double grade;
        public MutiplyDrawerItem()
        {
            InitializeComponent();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        public void LoadStudent(Student student)
        {
            this.student = student;
            this.pictureBox.Load(student.PicturePath);
            this.textBoxName.Text = student.Name;
            this.textBoxClassNum.Text = student.Classroom.ClassID;
        }

        public bool GradeIsVaild()
        {
            return double.TryParse(textBoxGrade.Text, out this.grade);

        }
        public double GetGrade()
        {
            try
            {
                return double.Parse(textBoxGrade.Text);
            }
            catch (Exception ex)
            {
                throw new Exception ("输入的成绩不合法");
            }
        }
    }
}
