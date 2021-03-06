﻿using System;
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
                
            }
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
