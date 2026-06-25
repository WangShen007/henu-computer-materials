using System;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch04
{
    public partial class E01 : Page
    {
        public E01()
        {
            InitializeComponent();
            Loaded += delegate
            {
                var v1 = new C01();
                var s = $"{v1.Result}\n";
                var v2 = new C01("李四", new DateTime(1998, 10, 15));
                s += v2.Result;
                uc.Result.Content = s;
            };
        }
    }
    public class C01
    {
        //属性
        public string Result { get; private set; } = "";
        public string Name { get; } = "张三";
        public DateTime BirthDate { get; set; } = new DateTime(2000, 9, 13);
        //构造函数
        public C01()
        {
            AddToResult();
        }
        public C01(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
            AddToResult();
        }
        //方法
        private void AddToResult()
        {
            Result += $"姓名：{Name},出生日期：{BirthDate:yyyy-MM-dd}\n";
        }
    }
}
