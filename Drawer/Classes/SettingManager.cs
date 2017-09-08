using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Drawer.Classes;

namespace Drawer
{
    public class SettingManager
    {
        Settings settings;

        string settingPath = "";
        string JsonObjectString = "";
        
        public SettingManager()
        {
      
        }
        public SettingManager(string specifiedSettingPath) : this()
        {
            this.settingPath = specifiedSettingPath;
        }
        public string SettingPath
        {
            get
            {
                if (settingPath == "")
                {
                    if (Assistance.DefaultSettingPath=="")
                    {
                        throw new Exception("No Setting path");
                    }
                    return Assistance.DefaultSettingPath;
                }
                return settingPath;
            }

            set
            {
                settingPath = value;
            }
        }

        void Load()
        {

        }
        void Store()
        {
            JsonObjectString = JsonConvert.SerializeObject(this);
        }
    }
}
