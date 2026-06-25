using System;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch04
{
    public partial class E12DateTime : Page
    {
        public E12DateTime()
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                var v = new DateTimeDemo();
                uc.Result.Content = v.R;
            };
        }
    }
    public class DateTimeDemo
    {
        public string R { get; set; }
        public DateTimeDemo()
        {
            //用法1：创建实例
            DateTime dt1 = new DateTime(2013, 1, 30);
            R += $"dt1：{dt1.ToLongDateString()}\n";
            //用法2：获取当前日期和时间
            DateTime dt2 = DateTime.Now;
            //用法3：格式化输出（注意大小写）
            R += $"dt2：{dt2.ToString("yyyy-MM-dd")}\n" +
                 $"{dt2.Year}年{dt2.Month}月{dt2.Hour}点{dt2.Minute}分\n";
            R += $"dt2：{dt2:yyyy-MM-dd HH:mm:ss)}";
            //获取两个日期相隔的天数
            TimeSpan ts = dt1 - dt2;
            R += $"dt1和dt2相隔{ts.Days}天";
        }
    }
}
