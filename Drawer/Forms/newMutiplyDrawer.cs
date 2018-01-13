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
    public partial class NewMutiplyDrawer : Form
    {
        private List<MutiplyDrawerItem> items;
        private MutiplyDrawerItem currentRollingItem;
        private DrawerControl drawerControl;
        private int drawNum;
        private Student.selectedType st;

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
                
            }
        }

        public NewMutiplyDrawer(DrawerControl drawerControl, int rollnum, Student.selectedType st)
        {
            this.drawerControl = drawerControl;
            this.drawNum = rollnum;
            this.st = st;
        }

        private void NewMutiplyDrawer_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTimePicker date = new DateTimePicker();
            date.Show();
            ToolBoxItem item = new ToolBoxItem();
            toolBoxGroup1.Add(item);
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("已保存");


        }

        private void toolBoxGroup1_Load(object sender, EventArgs e)
        {

        }
    }
}
