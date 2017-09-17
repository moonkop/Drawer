using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Drawer.UserControls;
namespace Drawer.Forms
{
    public partial class NewMutiplyDrawer : Form
    {
        private List<MutiplyDrawerItem> items;
        public List<MutiplyDrawerItem> Items
        {
            get
            {
                return items;
            }

        }

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
                Items.Add(item);
            }
            foreach (var item in Items)
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

        private void toolBoxGroup1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ToolBoxItem item = new ToolBoxItem();
            item.Left = 100;
            toolBoxGroup1.Add(item);
        }
    }
}
