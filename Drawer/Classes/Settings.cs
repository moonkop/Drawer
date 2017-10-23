using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drawer.Classes
{
    public class MySettings
    {
        public string SHA1ofPASSWORD = "54F8C89CE615405C74493D35CDD01BB875ED7428";
        public string LogPath = "log.txt";
        public string dataOutPutPath = "outPut\\";
        public string PicPath = "pic\\";
        public string defaultPicPath = "default.jpg";
        public string DBpath = "data.db";
        public string ShA1OfDB = "";
        public string SHA1ofDBpath = "SHA1ofDB.txt";
        public int RollTimeInteval = 10;
        public int DefaultMutiplyDrawerNum = 6;
        public List<string> classStrs = new List<string>();
        //--mutiplyDrawer
        public int MutiplyDrawer_rNumsForEachLine = 4;
        public int MutiplyDrawer_bigTimerInterval = 500;
        public int MutiplyDrawer_rWidthForEach = 400;
        public int MutiplyDrawer_rXBlankspace = 5;
        public int MutiplyDrawer_rTextboxheight = 30;
        public int MutiplyDrawer_rPictureboxHeight = 500;
        public int MutiplyDrawer_rCommandHeight = 28;
        public int MutiplyDrawer_yTextboxBlankSpace = 0;
        public bool MutiplyDrawer_autoSizeEnabled = true;
        public bool MutiplyDrawer_autoNumsForEachLine = true;
    }
}
