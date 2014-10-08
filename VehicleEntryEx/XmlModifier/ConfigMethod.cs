using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace XmlModifier
{
    public static class ConfigMethod
    {
        public static bool _isConnected = false;
        public static MyConfig _config = new MyConfig();
        /// <summary>
        /// 获取配置信息
        /// </summary>
        public static bool GetWebServiceUrl()
        {   /*  XDEbzAXJSms=    1I5p7b4DsZs=    +F+dq6iu+M0=  */
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\myconfig.xml";
            try
            {
                if (System.IO.File.Exists(path))
                {
                    _config = DeSerialize<MyConfig>(path);
                }
                else
                {
                    Serialize<MyConfig>(_config, path);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool SetWebServiceUrl()
        {
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\myconfig.xml";
            try
            {
                Serialize<MyConfig>(_config, path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void Serialize<T>(T o, string filePath)
        {
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                StreamWriter sw = new StreamWriter(filePath, false);
                formatter.Serialize(sw, o);
                sw.Flush();
                sw.Close();

            }
            catch (Exception) { }
        }

        public static T DeSerialize<T>(string filePath)
        {
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                StreamReader sr = new StreamReader(filePath);
                T o = (T)formatter.Deserialize(sr);
                sr.Close();
                return o;
            }

            catch (Exception)
            {
            }
            return default(T);
        }
    }
}
