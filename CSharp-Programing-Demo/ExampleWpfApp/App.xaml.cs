using System.Windows;
namespace ExampleWpfApp
{
    public partial class App : Application
    {
        public static void ExecConsoleApp(string arg)
        {
            //获取ExampleWpfApp.exe文件的完整路径
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //得到ExampleConsoleApp.exe的完整路径
            path = path.Replace(@"ExampleWpfApp\bin\Debug\ExampleWpfApp.exe",
                                @"ExampleConsoleApp\bin\Debug\ExampleConsoleApp.exe");
            System.Diagnostics.Process.Start(path, arg);
        }
    }
}
