using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Drawer.Untils;
using Drawer.Control;
using Drawer.Model;
using Drawer.UserControls;

namespace Drawer.Forms
{
    public partial class PasswordInputDialog : Form
    {
        MainForm obj1;
        private bool forcedInput;


        public PasswordInputDialog(MainForm obj,string message,bool forcedinput )
        {
            InitializeComponent();
           obj.Enabled = false;
            obj1 = obj;
            forcedInput = forcedinput;

            MessageBox.Show(message);
        }
        
        private void passwordInputBox_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Assistance.getSHA1ofString(textBox1.Text) == MainForm.Settings.SHA1ofPASSWORD)
            {
                obj1.Enabled = true;
                obj1.Visible = true;
          

                this.Visible = false;

            }
            else 
            {
                MessageBox.Show("密码错误!");
                if (forcedInput==true)
                {
                    obj1.Dispose();
                    this.Dispose();

                }
                else
                {
                    obj1.Enabled = true;
                    this.Dispose();

                }

            }
        }

        private void passwordInputBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            obj1.Dispose();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            obj1.Dispose();
            this.Dispose();
        }
    }
}
