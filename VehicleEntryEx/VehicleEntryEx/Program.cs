using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VehicleEntryEx
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [MTAThread]
        static void Main()
        {
            ConfigMethod.GetWebServiceUrl();
            Application.Run(new formLogin());
        }
    }
}