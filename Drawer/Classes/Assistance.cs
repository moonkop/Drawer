using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Drawer.Classes;
namespace Drawer
{
    public static class Assistance
    {
        private static SettingManager settingManager;
        public static string DefaultSettingPath;
        public static MySettings Settings
        {
            get
            {
                return settingManager.settings;
            }
            set
            {
                settingManager.settings = value;
            }
        }

        public static string GetSHA1Hash(string pathName)
        {
            string strResult = "";
            string strHashData = "";
            byte[] arrbytHashValue;

            System.IO.FileStream oFileStream = null;

            System.Security.Cryptography.SHA1CryptoServiceProvider osha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            try
            {
                oFileStream = new System.IO.FileStream(pathName.Replace("\"", ""), System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);

                arrbytHashValue = osha1.ComputeHash(oFileStream); //计算指定Stream 对象的哈希值

                oFileStream.Close();

                //由以连字符分隔的十六进制对构成的String，其中每一对表示value 中对应的元素；例如“F-2C-4A”

                strHashData = System.BitConverter.ToString(arrbytHashValue);

                //替换-
                strHashData = strHashData.Replace("-", "");

                strResult = strHashData;
            }

            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return strResult;
        }
        public static string getSHA1ofString(string strclean)
        {
            byte[] btclean = Encoding.Default.GetBytes(strclean);
            byte[] bt = SHA1.Create().ComputeHash(btclean);
            return BitConverter.ToString(bt).Replace("-", "");
        }
        public static string GetConfigurations1(string configPath, string option)
        {

            try
            {
                string str = "";
                FileStream file = new FileStream(configPath, FileMode.Open);
                StreamReader sr = new StreamReader(file, Encoding.Default);
                do
                {
                    str = sr.ReadLine();
                    if (str.StartsWith(option + "="))
                    {
                        sr.Close();
                        file.Close();
                        return str.Substring(str.IndexOf("=") + 1);
                    }
                } while (str != null);

                sr.Close();
                file.Close();
                return "NULL";
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public static string readln(string path, long line)
        {
            try
            {
                var file = new FileStream(path, FileMode.Open);
                StreamReader sr = new StreamReader(file, Encoding.Default);
                string strline = "";
                for (int i = 0; i < line; i++)
                {
                    strline = sr.ReadLine();
                }
                sr.Close();
                return strline;
            }
            catch (Exception)
            {
                throw;

            }
        }
        public static void writeln(string path, string str)
        {
            StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine(str);
            sw.Close();
        }
        public static void record(Student std1, string str)
        {
            string path = Settings.LogPath;
            writeln(path,
                 DateTime.Now.ToString() + "|" +
                 std1.Classroom.ClassID + "|" +
                 std1.Name + "|" +
              std1.Id + "|" + str);
        }
        public static void record(string str)
        {
            string path = Settings.LogPath;
            writeln(path, DateTime.Now.ToString() + "|" + str);
        }
        public static bool IsFileExist(string file)
        {
            return System.IO.File.Exists(file);
        }
        public static void Init()
        {
            settingManager = new SettingManager();
            DefaultSettingPath = Drawer.Properties.Settings.Default.SettingPath;
        }
        public static void LoadSettings(string SettingPath = "")
        {
            try
            {
                Settings = settingManager.LoadFromFile(SettingPath);
            }
            catch (Exception)
            {
            }
            if (Settings==null)
            {
                Settings = new MySettings();
            }
            //System.Reflection.FieldInfo[] fields = Settings.GetType().GetFields();
            //foreach (System.Reflection.FieldInfo field in fields)
            //{
            //    System.Reflection.FieldInfo field2 = typeof(Assistance).GetField(field.Name);
            //    if (field2 != null)
            //    {
            //        object fieldValueToRead = field.GetValue(Settings);
            //        field2.SetValue(null, fieldValueToRead);
            //    }
            //}
        }
        public static void StoreSettings(string SettingPath = "")
        {
            //System.Reflection.FieldInfo[] properties = Settings.GetType().GetFields();
            //foreach (System.Reflection.FieldInfo field in properties)
            //{
            //    System.Reflection.FieldInfo field2 = typeof(Assistance).GetField(field.Name);
            //    if (field2 != null)
            //    {
            //        object fieldValueToStore = field2.GetValue(null);
            //        field.SetValue(Settings, fieldValueToStore);
            //    }
            //}
            settingManager.StoreToFile(SettingPath);
        }
    }
}
