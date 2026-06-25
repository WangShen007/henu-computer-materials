using System;
using System.Collections.Generic;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch04
{
    public partial class E08Event : Page
    {
        public E08Event()
        {
            InitializeComponent();
            Loaded += delegate
            {
                var d1 = new EventDemo1();
                var d2 = new EventDemo2();
                uc.Result.Content = $"Demo1:\n{d1.Result}\nDemo2:\n{d2.Result}";
            };
        }
    }
    /// <summary>
    /// 本例子仅为了解释概念，实际应用项目中一般不这样写
    /// </summary>
    public class EventDemo1
    {
        private int count;
        MyItem m = new MyItem();
        public string Result { get; set; }
        public EventDemo1()
        {
            m.Handler += ItemChanged; //注册事件
            for (int i = 0; i < 5; i++)
            {
                m.OnItemChanged();    //引发事件【Handler!=null,执行ItemChanged】
            }
            m.Handler -= ItemChanged; //取消事件
        }

        //事件处理程序
        void ItemChanged()
        {
            count++;
            Result += $"{count}\t";
        }
        private class MyItem
        {
            public delegate void MyHandlerDelegate();
            public event MyHandlerDelegate Handler;
            public void OnItemChanged()
            {
                Handler?.Invoke();
            }
        }
    }
    /// <summary>
    /// 实际项目中自定义事件的用法示例，
    /// 一般在高级开发中才需要自定义事件（比如中间件或者组件开发），
    /// 如果是普通的应用项目，直接用控件提供的事件去实现就足以能满足需求了。
    /// </summary>
    public class EventDemo2
    {
        readonly List<Student> students = new List<Student> {
            new Student { Name = "张三", Grade = 70 },
            new Student { Name = "李四", Grade = 80 },
            new Student { Name = "王五", Grade = 90 }
        };
        public string Result { get; set; } = "";
        public EventDemo2()
        {
            StudentHandler d = new StudentHandler();

            #region 用法1
            d.Handler += delegate {
                Result += $"{DateTime.Now:HH:mm:ss}\t";
            };
            #endregion

            #region 用法2
            d.Handler += (s, e) =>
            {
                Result += $"【{e.Option}】姓名：{e.Name}，成绩：{e.Grade}\n";
            };
            foreach (var v in students)
            {
                d.OnAdd(v);
            }
            d.OnRemove(students[0]);
            #endregion
        }
    }
    public class StudentHandler
    {
        public event EventHandler<Student> Handler;
        public void OnAdd(Student args)
        {
            args.Option = HandlerOption.添加;
            Handler?.Invoke(this, args);
        }
        public void OnRemove(Student args)
        {
            args.Option = HandlerOption.删除;
            Handler?.Invoke(this, args);
        }
    }
    public enum HandlerOption { 添加, 删除 }
    public class Student : EventArgs
    {
        public HandlerOption Option { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
    }
}
