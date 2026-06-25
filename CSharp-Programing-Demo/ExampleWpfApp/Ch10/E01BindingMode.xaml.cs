using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Shapes;
namespace ExampleWpfApp.Ch10
{
    public partial class E01BindingMode : Page
    {
        public E01BindingMode()
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                //简单示例
                Binding b1 = new Binding()
                {
                    ElementName = slide1.Name,
                    Path = new PropertyPath(Slider.ValueProperty),
                    StringFormat = "{0:f0}%"
                };
                BindingOperations.SetBinding(r1, WidthProperty, b1);
                BindingOperations.SetBinding(t1, TextBlock.TextProperty, b1);
                //数据库操作示例（如果无数据，请先运行【例7-1】初始化，然后再运行该例子）
                using (var c = new MyDb1Entities())
                {
                    var students = (from t in c.Student select t).ToList();
                    dataGrid1.ItemsSource = students;
                    dataGrid1.SelectedIndex = students.Count() > 0 ? 0 : -1;
                }
            };
        }
    }
}
