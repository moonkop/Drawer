using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
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
            textBoxID.DataBindings.Add("Text", student, "ID",false,DataSourceUpdateMode.OnPropertyChanged);
            textBoxName.DataBindings.Add("Text", student, "Name",false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxClass.DataBindings.Add("Text", student.classroom, "classID",false,DataSourceUpdateMode.OnPropertyChanged);
            checkBoxMutiply.DataBindings.Add("Checked",student,"selected_Mutiply",false,DataSourceUpdateMode.OnPropertyChanged);
            checkBoxSingle.DataBindings.Add("Checked",student, "selected_Single", false,DataSourceUpdateMode.OnPropertyChanged);
            checkBoxReport.DataBindings.Add("Checked",student, "selected_Report", false,DataSourceUpdateMode.OnPropertyChanged);
            textBoxMutiplyScore.DataBindings.Add("Text", student, "grade", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxMutiplyScore.DataBindings.Add("Visible",checkBoxMutiply,"Checked",false,DataSourceUpdateMode.OnPropertyChanged);

            //textBoxPicPath.DataBindings.Add("Text", student, "");

          //  student.ID
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
