using System.Text.RegularExpressions;
using System.Collections;

namespace VehicleEntryEx
{
    public static class ExtensionMethod
    {
        public static string ToFormatString(this string str,params object[] param)
        {
            return string.Format(str,param);
        }

        /// <summary>
        /// 检查是否是Double类型的数据
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDoubleValue(this string str)
        {
            if (str.Length == System.Text.RegularExpressions.Regex.Match(str, "[1-9]\\d*\\.\\d+|0\\.0*[1-9]+|[1-9]\\d*").Value.Length)
                return true;
            else
                return false;
        }

       /// <summary>
        /// 检查是否是整型的数据
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsIntegerValue(this string str)
        {
            if (str.Length == System.Text.RegularExpressions.Regex.Match(str, "[1-9]\\d*|0").Value.Length)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 将字符串按照规定的字符分割并返回哈希表
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Hashtable AnalysisToHash(this string str)
        {
            var hash = new Hashtable();
            var elements = str.Split('|');
            int length = elements.Length;
            for (int i = 0; i < length; i++)
            {
                var tmpStr = elements[i].Split(':');
                if (tmpStr.Length > 0)
                {
                    if (tmpStr[1].Contains(","))
                    {
                        hash.Add(tmpStr[0], tmpStr[1].Split(','));
                    }
                    else
                        hash.Add(tmpStr[0], tmpStr[1]);
                }
                else
                    hash.Add(tmpStr[0], null);
            }
            return hash;
        }

        /// <summary>
        /// 将Json字符串解析为哈希表
        /// </summary>
        /// <param name="jsonstr"></param>
        /// <returns></returns>
        public static Hashtable AnalysisJsonString(this string jsonstr)
        {
            string patternStr = "\"\\w+\":\"[^\"]*\"|\"\\w+\":\\[[^\\[\\]]*\\]|\"\\w+\":\\{[^\\{\\}]*\\}|\"\\w+\":[\\d]*";
            return jsonstr.AnalysisJsonString(patternStr);
        }

        /// <summary>
        /// 将Json字符串解析为哈希表
        /// </summary>
        /// <param name="jsonstr"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static Hashtable AnalysisJsonString(this string jsonstr,string pattern)
        {
            string patternStr = pattern;
            var hash = new Hashtable();
            var mc = Regex.Matches(jsonstr, patternStr);
            foreach (Match m in mc)
            {
                var tmpKey = m.Value.Substring(0, m.Value.IndexOf(':'));
                var tmpValue = SetChildrenValue(m.Value.Replace(tmpKey, "").TrimStart(':'));
                hash.Add(tmpKey.ToString().Replace("\"", ""), tmpValue);
            }
            return hash;
        }

        private static object SetChildrenValue(string str)
        {
            var tmpStr = str;
            if (tmpStr.Contains("{") && tmpStr.Contains("["))
            {
                var mc = Regex.Matches(tmpStr, "{[^{}]+}");
                var hashGrp=new object[mc.Count];
                int i = 0;
                foreach (Match m in mc)
                {
                    hashGrp[i++] = m.Value.AnalysisJsonString();
                }
                return hashGrp;
            }
            else if (tmpStr.Contains("{"))
            {
                return tmpStr.AnalysisJsonString();
            }
            else if (tmpStr.Contains("["))
            {
                var tmpStrGrp = tmpStr.Replace("[", "").Replace("]", "").Split(',');
                return tmpStrGrp;
            }
            else
            {
                return tmpStr.Replace("\"","");
            }
        }
    }
}
