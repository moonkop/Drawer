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
    public partial class NewMutiplyDrawer : Form
    {
        List<MutiplyDrawerItem> items;
        public NewMutiplyDrawer()
        {
            InitializeComponent();
            items = new List<MutiplyDrawerItem>();
        }

        public NewMutiplyDrawer(int drawNum) : this()
        {
            for (int i = 0; i < drawNum; i++)
            {
                MutiplyDrawerItem item = new MutiplyDrawerItem();
                items.Add(item);
            }
            foreach (var item in items)
            {
                this.flowLayoutPanel1.Controls.Add(item);
             //   item.Show();
            }
        }

        private void NewMutiplyDrawer_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
