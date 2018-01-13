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
    public partial class LogForm : Form
    {
        StringBuilder buffer;
        public LogForm(StringBuilder stringBuilder)
        {
            InitializeComponent();
            this.buffer = stringBuilder;
        }
       
        public void RefreshLog()
        {
            this.textBox1.Text = buffer.ToString();
        }
        private void LogForm_Load(object sender, EventArgs e)
        {
            RefreshLog();

        }
    }
}
