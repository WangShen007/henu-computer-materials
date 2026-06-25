using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExampleWpfApp.Ch11
{
    public partial class Z01_DrawingBrush : Page
    {
        public Z01_DrawingBrush()
        {
            InitializeComponent();
            Loaded += delegate
            {
                DrawingBrush db1 = GetDrawingBrush("gd1");
                DrawingBrush db2 = GetDrawingBrush("gd2");
                AddTextToStackPanel("g1:");
                AddEllipseToStackPanel(db1, false);
                AddTextToStackPanel("g2:");
                AddEllipseToStackPanel(db2, true);
                AddTextToStackPanel("g3:");
                DrawingBrush db = new DrawingBrush()
                {
                    Viewport = new Rect(0, 0, 1, 1),
                    ViewportUnits = BrushMappingMode.RelativeToBoundingBox,
                    Stretch = Stretch.Fill,
                    TileMode = TileMode.None,
                    Drawing = GetDrawingGroup()
                };
                Rectangle r = new Rectangle()
                {
                    Width = 120,
                    Height = 100,
                    Fill = db
                };
                stackPanel1.Children.Add(r);
            };
        }
        private DrawingGroup GetDrawingGroup()
        {
            DrawingGroup dg = new DrawingGroup();
            GeometryDrawing gd1 = new GeometryDrawing
            {
                Brush = this.FindResource("rb1") as GradientBrush,
                Geometry = new EllipseGeometry()
                {
                    Center = new Point(55, 65),
                    RadiusX = 30,
                    RadiusY = 60
                }
            };
            dg.Children.Add(gd1);
            GeometryDrawing gd2 = gd1.Clone();
            gd2.Geometry = new EllipseGeometry()
            {
                Center = new Point(100, 65),
                RadiusX = 30,
                RadiusY = 60
            };
            dg.Children.Add(gd2);
            GeometryDrawing gd3 = new GeometryDrawing
            {
                Brush = this.FindResource("rb2") as GradientBrush,
                Geometry = Geometry.Parse("M80,0 L0,60 160,60Z")
            };
            dg.Children.Add(gd3);
            return dg;
        }
        private void AddEllipseToStackPanel(DrawingBrush db, bool isDrawStroke)
        {
            Ellipse ep = new Ellipse()
            {
                Margin = new Thickness(5, 0, 0, 0),
                Width = 60,
                Height = 60,
                Fill = db,
            };
            if (isDrawStroke == true)
            {
                ep.Stroke = Brushes.White;
                ep.StrokeThickness = 5;
            }
            stackPanel1.Children.Add(ep);
        }
        private DrawingBrush GetDrawingBrush(string GeometryDrawingResourceName)
        {
            DrawingBrush db = new DrawingBrush
            {
                Drawing = this.FindResource(GeometryDrawingResourceName) as GeometryDrawing
            };
            db.Freeze();
            return db;
        }
        private void AddTextToStackPanel(string text)
        {
            TextBlock textBlock = new TextBlock
            {
                Text = text,
                Margin = new Thickness(20, 0, 0, 0)
            };
            stackPanel1.Children.Add(textBlock);
        }
    }
}
