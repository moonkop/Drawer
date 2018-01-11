using Drawer.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Drawer.Forms
{
    public partial class StudentStatus : Form
    {
        private Student student;
        public Student Student
        {
            get
            {
                return student;
            }

            set
            {
                student = value;
            }
        }
        public StudentStatus(Student stu)
        {
            InitializeComponent();
            Student = stu;

        }



        private void StudentStatus_Load(object sender, EventArgs e)
        {
            textBoxID.DataBindings.Add("Text", student, "Id",false,DataSourceUpdateMode.OnPropertyChanged);
            textBoxName.DataBindings.Add("Text", student, "Name",false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxClass.DataBindings.Add("Text", student.Classroom, "ClassID",false,DataSourceUpdateMode.OnPropertyChanged);
            checkBoxMutiply.DataBindings.Add("Checked",student, "Selected_Mutiply", false,DataSourceUpdateMode.OnPropertyChanged);
            checkBoxSingle.DataBindings.Add("Checked",student, "Selected_Single", false,DataSourceUpdateMode.OnPropertyChanged);
            checkBoxReport.DataBindings.Add("Checked",student, "Selected_Report", false,DataSourceUpdateMode.OnPropertyChanged);
            textBoxMutiplyScore.DataBindings.Add("Text", student, "Grade", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxMutiplyScore.DataBindings.Add("Visible",checkBoxMutiply,"Checked",false,DataSourceUpdateMode.OnPropertyChanged);
            pictureBox.DataBindings.Add("ImageLocation", student, "PicturePath", false, DataSourceUpdateMode.OnPropertyChanged);
            checkBoxMutiply.CheckedChanged += checkBoxMutiply_CheckedChanged;
        }
        

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

        double gradeBefore = 0;


        private void checkBoxMutiply_CheckedChanged(object sender, EventArgs e)
        {
            

            if (checkBoxMutiply.Checked==false)
            {
                double.TryParse(textBoxMutiplyScore.Text, out gradeBefore);
                student.Grade = -1;
            }
            else
            {
                student.Grade = gradeBefore ;
                textBoxMutiplyScore.Text = student.Grade.ToString();
                
            }

        }
    }
}
