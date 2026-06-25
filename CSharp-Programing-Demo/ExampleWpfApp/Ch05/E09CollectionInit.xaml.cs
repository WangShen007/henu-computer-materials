using System.Collections.Generic;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch05
{
    public partial class E09CollectionInit : Page
    {
        public E09CollectionInit()
        {
            InitializeComponent();
            Loaded += delegate { ShowDemo(); };
        }
        private string s = "";
        private void ShowDemo()
        {
            s = "学号\t姓名\t性别\t成绩\n" + new string('-', 40) + "\n";
            // 用法1：使用默认值
            E09Student s1 = new E09Student();
            AppendLine(s1);
            // 用法2：初始化时同时对属性赋初值
            E09Student s2 = new E09Student { Name = "张三", Gender = '男', Score = 80 };
            AppendLine(s2);
            // 用法3：初始化时同时对部分属性赋初值
            E09Student s3 = new E09Student { Gender = '男' };
            AppendLine(s3);
            // 用法4：创建并初始化多条记录
            List<E09Student> students = new List<E09Student>
                {
                    new E09Student{Name="张三", Gender='男', Score=81},
                    new E09Student{Name="李四", Gender='男', Score=83},
                    new E09Student{Name="李五", Gender='女', Score=85},
                    new E09Student{Name="王六", Gender='男', Score=83}
                };
            foreach (var v in students)
            {
                AppendLine(v);
            }
            uc.Result.Text = s;
        }
        private void AppendLine(E09Student t)
        {
            s += $"{t.ID}\t{t.Name}\t{t.Gender}\t{t.Score}\n";
        }
    }
    public class E09Student
    {
        private static int id = 1;
        public string ID
        {
            get { return (id++).ToString("d4"); }
        }
        public string Name { get; set; } = "未知";
        public char Gender { get; set; } = '男';
        public int Score { get; set; }
    }
}
