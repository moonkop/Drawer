using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Drawer.Forms;
using Drawer.Control;

namespace Drawer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DrawerControl drawerControl = new DrawerControl();
            MainForm mainForm = new MainForm(drawerControl);
            drawerControl.mainform = mainForm;
            Application.Run(mainForm);
        }
    }
}
