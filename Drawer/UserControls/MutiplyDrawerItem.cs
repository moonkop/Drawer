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
        public Student student;
        double grade;
        SelectType selectType;
        public MutiplyDrawerItem(SelectType selectType)
        {
            
            InitializeComponent();
            this.selectType = selectType;
            this.pictureBox.MouseDown += PictureBox_MouseDown;
            switch (selectType)
            {
                case SelectType.Mutiply:

                    break;
                case SelectType.Report:
                    textBoxGrade.Dispose();
                    break;
            }
        }

      
        public void LoadStudent(Student student)
        {   
            try
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    this.student = student;
                    this.pictureBox.Load(student.PicturePath);
                    this.textBoxName.Text = student.Name;
                    this.textBoxClassNum.Text = student.Classroom.ClassID;
                }));
            }
            catch (Exception )
            {
            }
    
        }
        public bool CollectGrade()
        {
            bool returnval= double.TryParse(textBoxGrade.Text, out this.grade);
            if (returnval==true)
            {
                this.student.Grade = this.grade;
            }
            return returnval;
        }
        public bool GradeIsVaild()
        {
            return double.TryParse(this.textBoxGrade.Text  ,out this.grade );

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
        private void PictureBox_MouseMove(object sender, MouseEventArgs ex)
        {
            Point e = System.Windows.Forms.Control.MousePosition;
            if (ex.Button == MouseButtons.None)
            {
                this.pictureBox.MouseMove -= PictureBox_MouseMove;
                return;
            }
            this.ParentForm.Location = new Point(formLocation.X + (e.X - mouseDownLocation.X), formLocation.Y + (e.Y - mouseDownLocation.Y));
        }
        Point mouseDownLocation;
        Point formLocation;
        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            formLocation = this.ParentForm.Location;
            mouseDownLocation = System.Windows.Forms.Control.MousePosition;
            this.pictureBox.MouseMove += PictureBox_MouseMove;
        }


    }
}
