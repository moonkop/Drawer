using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Drawer;
using Drawer.Forms;

namespace Drawer.UserControls
{
    public partial class ToolBoxGroup : UserControl
    {


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.CollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral", typeof(System.Drawing.Design.UITypeEditor))]
        [Localizable(true)]
        [MergableProperty(false)]
        public List<ToolBoxItem> Items { get; protected set; }

        public ToolBoxGroup()
        {
            Items = new List<ToolBoxItem>();
            InitializeComponent();
        }
        public int CalcPos()
        {
            return Items.Count * 30;

        }
        public void Add(ToolBoxItem item)
        {
            item.Left = CalcPos();
            Items.Add(item);
            this.Controls.Add(item);

        }




    }
}
