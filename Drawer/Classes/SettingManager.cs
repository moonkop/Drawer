using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Drawer.Classes;
using System.IO;

namespace Drawer
{
    /// <summary>
    /// 此类负责读写设置
    /// </summary>
    public class SettingManager
    {

        // 设置保存的实体
        public MySettings settings;

        string settingPath = "";
        //设置转换后的Json字符串
        string JsonObjectString = "";

        public SettingManager()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="specifiedSettingPath">设置路径</param>
        public SettingManager(string specifiedSettingPath) : this()
        {
            this.settingPath = specifiedSettingPath;
        }
        /// <summary>
        /// 设置的路径，为空则使用上级路径
        /// </summary>
        public string SettingPath
        {
            get
            {
                if (settingPath == "")
                {
                    if (Assistance.DefaultSettingPath == "")
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
        /// <summary>
        /// 从字符串加载设置实体
        /// </summary>
        /// <returns>设置实体</returns>
        public MySettings Load()
        {
            return settings = (MySettings)JsonConvert.DeserializeObject(this.JsonObjectString, typeof(MySettings));
        }
        /// <summary>
        /// 从设置换换为字符串
        /// </summary>
        /// <returns>设置的Json字符串</returns>
        public string Store()
        {
            return JsonObjectString = JsonConvert.SerializeObject(settings);
        }
        /// <summary>
        /// 从文件加载设置
        /// </summary>
        /// <param name="SettingPath"></param>
        /// <returns>设置实体</returns>
        public MySettings LoadFromFile(string SettingPath = "")
        {
            if (SettingPath == "")
            {
                SettingPath = this.SettingPath;
            }
            if (!Assistance.IsFileExist(this.SettingPath))
            {
                throw new FileNotFoundException("Setting File Not Found");
            }
            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                fs = new FileStream(SettingPath, FileMode.Open);
                sr = new StreamReader(fs);
                this.JsonObjectString = sr.ReadToEnd();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
                if (fs != null)
                {
                    fs.Close();
                }
       
            }
            return Load();
        }
        /// <summary>
        /// 保存设置到文件
        /// </summary>
        /// <param name="SettingPath">文件路径</param>
        public void StoreToFile(string SettingPath = "")
        {
            if (SettingPath == "")
            {
                SettingPath = this.SettingPath;
            }
            FileStream fs = null;
            StreamWriter sw = null;

            try
            {
                fs = new FileStream(SettingPath, FileMode.Create);
                sw = new StreamWriter(fs);
                sw.Write(this.Store());
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
                if (fs != null)
                {
                    fs.Close();
                }
         
            }


        }
    }
}
