using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2210050000_name_lab04
{
    internal class DataBaseConfig
    {
        public static string ConnectionString
        {
            get
            {
                //F:\Study\ComputerScience\CSharp\lab\lab04\2210050000_name_lab04\2210050000_name_lab04\2210050000_name_StudentTable.mdf
                // 动态获取运行目录,获取的应该是debug
                string runDirectory = AppDomain.CurrentDomain.BaseDirectory;

                // 拼接数据库文件路径
                string relativePath = @"..\..\..\2210050000_name_StudentTable.mdf";
                string databasePath = Path.GetFullPath(Path.Combine(runDirectory, relativePath));

                // 返回完整连接字符串
                return $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={databasePath};Integrated Security=True;Connect Timeout=30";
            }
        }
    }
}
