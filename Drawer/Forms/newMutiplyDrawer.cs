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
        private DrawSession drawSession;
        System.Timers.Timer timerRoll;
        System.Timers.Timer timerFinal;
        public int rollTime = 10;
        private int drawNum;
        private SelectType st;

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
            timerRoll = new System.Timers.Timer();
            timerRoll.Interval = 20;
            timerRoll.Elapsed += TimerRoll_Elapsed;
        }

        private int currentRollTime;
        private void TimerRoll_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            currentRollingItem.LoadStudent(drawSession.nextWinner());
            if (currentRollTime-- == 0)
            {
                TimerFinal();
            }
        }
        private void TimerFinal()
        {
            timerRoll.Stop();
            currentRollingItem.LoadStudent(drawSession.GetFinalWinner());
            currentRollTime = rollTime;

            if (drawNum > items.Count)
            {
                AddDrawerItem();
                timerRoll.Start();
            }
        }
        public NewMutiplyDrawer(DrawSession drawSession, int drawNum, SelectType st) : this()
        {
            this.drawNum = drawNum;
            this.drawSession = drawSession;
            currentRollTime = rollTime;
        }


        private void AddDrawerItem()
        {
            currentRollingItem = new MutiplyDrawerItem();
            currentRollingItem.buttonSkip.Click += ButtonSkip_Click;
            this.items.Add(currentRollingItem);
            this.Invoke(new MethodInvoker(() =>
            {
                this.flowLayoutPanel1.Controls.Add(currentRollingItem);
            }));
        }

        private void ButtonSkip_Click(object sender, EventArgs e)
        {
            MutiplyDrawerItem item = (MutiplyDrawerItem)(((Button)sender).Parent);
            Student studentSkip = item.student;
            drawSession.PutBack(studentSkip);
            item.LoadStudent(drawSession.GetFinalWinner());

        }

        private void NewMutiplyDrawer_Load(object sender, EventArgs e)
        {
            AddDrawerItem();

            timerRoll.Start();
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
