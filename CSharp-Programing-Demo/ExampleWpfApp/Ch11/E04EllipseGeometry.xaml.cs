using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
namespace ExampleWpfApp.Ch11
{
    public partial class E04EllipseGeometry : Page
    {
        public E04EllipseGeometry()
        {
            InitializeComponent();
            var g = new EllipseGeometry
            {
                Center = new Point(0, 0),
                RadiusX = 50,
                RadiusY = 25
            };
            Path path = new Path
            {
                Stroke = Brushes.Black,
                Fill = Brushes.Bisque,
                Data = g
            };
            Canvas.SetLeft(path, 300);
            Canvas.SetTop(path, 50);
            canvas1.Children.Add(path);
        }
    }
}
