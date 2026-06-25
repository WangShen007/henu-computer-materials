using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace ExampleWpfApp.Ch11
{
    public partial class E06Arc : Page
    {
        public E06Arc()
        {
            InitializeComponent();
            PathSegmentCollection paths = new PathSegmentCollection
            {
                new ArcSegment(
                    point: new Point(200, 200),
                    size: new Size(50, 60),
                    rotationAngle: 0,
                    isLargeArc: false,
                    sweepDirection: SweepDirection.Clockwise,
                    isStroked: true),
                new QuadraticBezierSegment(
                    point1:new Point(200,200),
                    point2:new Point(300,100),
                    isStroked:true ),
                new BezierSegment(
                    point1:new Point(100,0),
                    point2:new Point(200,300),
                    point3:new Point(80,240),
                    isStroked:true)
            };
            PathFigureCollection figures = new PathFigureCollection
            {
                new PathFigure( start:new Point(10,200), segments:paths, closed:true )
            };
            path1.Data = new PathGeometry { Figures = figures };
        }
    }
}
