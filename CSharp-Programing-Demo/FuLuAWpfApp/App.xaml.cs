using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FuLuAWpfApp
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static void ExecConsoleApp(string arg)
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path1 = path.Replace("FuLuAWpfApp", "FuLuAConsoleApp");
            System.Diagnostics.Process.Start(path1, arg);
        }
    }
}
