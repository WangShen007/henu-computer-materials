using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ExampleWpfApp.Ch03
{
    public partial class E12foreach : Page
    {
        public E12foreach()
        {
            InitializeComponent();
            btn1.Click += delegate
            {
                App.ExecConsoleApp("ExampleConsoleApp.Ch03.E12foreach");
            };
            btn2.Click += delegate
            {
                //基本用法
                var c = new Wpfz.Ch03.C12foreach();
                textBlock1.Text = c.BaseUsage();
            };
            btn3.Click += delegate
            {
                //利用反射获取Brushes类的所有属性，此为高级用法，了解即可
                var properties = typeof(Brushes).GetTypeInfo().DeclaredProperties;
                foreach (PropertyInfo p in properties)
                {
                    listBox1.Items.Add(GetStackPanel(p));
                }
            };
        }
        //高级用法(了解即可)
        private StackPanel GetStackPanel(PropertyInfo p)
        {
            SolidColorBrush brush = (SolidColorBrush)p.GetValue(null);
            TextBlock t1 = new TextBlock()
            {
                FontFamily = new FontFamily("宋体"),
                FontSize = 18,
                Text = string.Format("{0,-20}", p.Name),
                Background = brush,
            };
            TextBlock t2 = new TextBlock()
            {
                Margin = new Thickness(5, 0, 0, 0),
                FontSize = 18,
                Text = p.Name,
                Foreground = brush
            };
            StackPanel sp = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
            };
            sp.Children.Add(t1);
            sp.Children.Add(t2);
            return sp;
        }
    }
}
