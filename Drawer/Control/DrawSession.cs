using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Drawer.Model;
using Drawer.Untils;
using Drawer.Forms;
namespace Drawer.Control
{
    class DrawSession
    {
        List<Student> studentReady;
        Random random;
        SelectType selectType;
        public void DrawerSession(SelectType selectType)
        {
            this.selectType = selectType;

        }

    }
}
