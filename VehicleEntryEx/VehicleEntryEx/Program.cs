using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VehicleEntryEx
{
    static class Program
    {
        public static formLogin login = null;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [MTAThread]
        static void Main()
        {
            ConfigMethod.GetWebServiceUrl();
            login = new formLogin();
            Application.Run(login);
        }
    }
}