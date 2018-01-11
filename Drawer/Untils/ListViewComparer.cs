using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace Drawer.Untils
{
    class ListViewItemComparer : System.Collections.IComparer
    {
        int col;
        SortOrder so;
        public ListViewItemComparer()
        {
            col = 0;
            so = SortOrder.Ascending;
        }
        public ListViewItemComparer(int column, SortOrder order)
        {
            col = column;
            this.so = order;
        }
        public  int Compare(Object x, Object y)
        {
            int returnval = -1;
            int a = 0;
            int b = 0;
            int.TryParse(((ListViewItem)x).SubItems[col].Text, out a);
            int.TryParse(((ListViewItem)y).SubItems[col].Text, out b);
            if (a != 0 && b != 0)
            {
                returnval = a >= b ? (a == b ? 0 : 1) : -1;
            }
            else
            {
                returnval = string.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);

            }
            if (so == SortOrder.Descending)
            {
                returnval *= -1;
            }
            return returnval;

        }
    }
}
