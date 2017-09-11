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
        List<ToolBoxItem> tools;
        public ToolBoxGroup()
        {
            InitializeComponent();
        }



        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ColumnHeaderCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        [Localizable(true)]
        [MergableProperty(false)]
        public List<ToolBoxItem> Tools
        {
            get
            {
                return tools;
            }

            set
            {
                tools = value;
            }
        }
    }
}
