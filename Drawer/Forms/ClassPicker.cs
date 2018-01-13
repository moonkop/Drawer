using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Drawer.Classes;
using Drawer.Untils;
using Drawer.Control;
using Drawer.Model;
using Drawer.UserControls;

namespace Drawer.Forms
{
    public partial class ClassPicker : Form
    {
        public List<Classroom> classroomsAll;

        public ObservableCollection<Classroom> classroomSelected;
        public List<Classroom> _classroomSelected;
        public MainForm fm;

        public ClassPicker(List<Classroom> classroomsAll ,List<Classroom> classroomSelected)
        {
            
            InitializeComponent();
            this.classroomsAll = classroomsAll;
            this._classroomSelected = classroomSelected;
            this.classroomSelected = new ObservableCollection<Classroom>(classroomSelected);
            this.classroomSelected.CollectionChanged += ClassroomSelected_CollectionChanged;
        }

        private void ClassroomSelected_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            FlushListViewSelected();
        }
        private void FlushListViewSelected()
        {
            listViewSelected.Items.Clear();

            foreach (Classroom cls in classroomSelected)
            {
                AddClassroomToListView(cls, listViewSelected);
            }
        }


        private void AddClassroomToListView(Classroom cls,ListView lv )
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = cls.ClassID;
            lvi.SubItems.Add(cls.students.Count().ToString());
            lvi.Tag = cls;
            lv.Items.Add(lvi);

        }
        private void ClassPicker_Load(object sender, EventArgs e)
        {
            listViewSelected.Items.Clear();
            listViewAll.Items.Clear();

            foreach (Classroom cls in classroomsAll)
            {
                AddClassroomToListView(cls, listViewAll);

            }
            foreach (Classroom cls in classroomSelected)
            {
                AddClassroomToListView(cls, listViewSelected);

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (listViewAll.SelectedItems.Count==0)
            {
                return;
            }
            foreach (ListViewItem lvi in listViewAll.SelectedItems)
            {
                Classroom clsTemp = (Classroom)lvi.Tag;
                if (classroomSelected.IndexOf(clsTemp)==-1)
                {
                    classroomSelected.Add(clsTemp);

                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (listViewSelected.SelectedItems.Count == 0)
            {
                return;
            }
            foreach (ListViewItem lvi in listViewSelected.SelectedItems)
            {
                Classroom clsTemp = (Classroom)lvi.Tag;
                classroomSelected.Remove(clsTemp);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            _classroomSelected.Clear();
            _classroomSelected.AddRange(classroomSelected.ToList());
            this.Close();
        }
    }
}
