using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Drawer.Forms
{
    public partial class SizeDragger : UserControl
    {
        public SizeDragger()
        {
            InitializeComponent();
        }

        private void SizeDragger_Load(object sender, EventArgs e)
        {
            //Parent.DataBindings.Add("Height", this, "Top");
            //Parent.DataBindings.Add("Width", this, "Left");
        }
        private void SetParentSize(int Width, int Height)
        {
            Parent.Height = Height;
            Parent.Width = Width;
        }
        private void SetParentSize(Size size)
        {
            SetParentSize(size.Height, size.Width);

        }
        Point pFirst;
        Point pCurrent;
        Point pLast;
        bool dynamicSizeChangeEnabled;

        public bool DynamicSizeChangeEnabled
        {
            get
            {
                return dynamicSizeChangeEnabled;
            }

            set
            {
                if (value)
                {
                    this.MouseMove += SizeDragger_MouseMove;
                }
                dynamicSizeChangeEnabled = value;
            }
        }



        private void SizeDragger_MouseDown(object sender, MouseEventArgs e)
        {
            pFirst = e.Location;
        }

        private void SizeDragger_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.None)
            {
                return;
            }
            if (dynamicSizeChangeEnabled)
            {
                // pCurrent = e.Location;
                SetParentSize(e.X + this.Width / 2 + this.Left, e.Y + this.Height / 2 + this.Top);
            }
            else
            {
                this.MouseMove -= SizeDragger_MouseMove;
            }
        }

        private void SizeDragger_MouseUp(object sender, MouseEventArgs e)
        {

            SetParentSize(e.X + this.Width / 2 + this.Left, e.Y + this.Height / 2 + this.Top);

        }
    }
}
