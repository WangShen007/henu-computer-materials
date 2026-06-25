using System;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch05
{
    public partial class E07Interface : Page
    {
        public E07Interface()
        {
            InitializeComponent();
            Loaded += delegate
            {
                string s = "";
                var v1 = new E07Demo1
                {
                    Name = "张三",
                    BirthDate = DateTime.Parse("1990-01-12")
                };
                s += $"姓名：{v1.Name}，出生日期：{v1.BirthDate:yyyy-MM-dd}，" +
                     $"M1:{v1.MyMethod1()}，M2:{v1.MyMethod2()}\n";
                var v2 = new E07Demo2
                {
                    Name = "李四",
                    BirthDate = DateTime.Parse("1991-02-24")
                };
                var d1 = (IDemo1)v2;
                var d2 = (IDemo2)v2;
                s += $"姓名：{v2.Name}，出生日期：{v2.BirthDate:yyyy-MM-dd}，" +
                     $"M1:{d1.MyMethod1()}，M2:{d2.MyMethod2()}";
                uc.Result.Text = s;
            };
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
    interface IDemo1 { string MyMethod1(); }
    interface IDemo2 { string MyMethod2(); }
    public class E07Demo1 : Person, IDemo1, IDemo2
    {
        #region 实现接口
        public string MyMethod1() { return "MyMethod1"; }
        public string MyMethod2() { return "MyMethod2"; }
        #endregion
    }
    public class E07Demo2 : Person, IDemo1, IDemo2
    {
        #region 显式实现接口
        string IDemo1.MyMethod1() { return "MyMethod1"; }
        string IDemo2.MyMethod2() { return "MyMethod2"; }
        #endregion
    }
}
