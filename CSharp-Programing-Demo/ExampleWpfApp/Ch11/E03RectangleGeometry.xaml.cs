using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
namespace ExampleWpfApp.Ch11
{
    public partial class E03RectangleGeometry : Page
    {
        public E03RectangleGeometry()
        {
            InitializeComponent();
            double x = 450, y = 20;
            GeometryGroup g = new GeometryGroup();
            //楼梯
            x = 40; y = 30;
            for (int i = 0; i < 10; i++)
            {
                var r1 = new RectangleGeometry(new Rect(x, y, 45, 280 - y));
                r1.Freeze();  //冻结的目的是提高性能
                g.Children.Add(r1);
                x += 45; y += 25;
            }
            Path path = new Path { Stroke = Brushes.Black, Data = g };
            canvas1.Children.Add(path);
        }
    }
}
