using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace ExampleWpfApp.Ch05
{
    public class E06_1_DrawLine : E06_0_DrawObject
    {
        public E06_1_DrawLine(Image image) : base(image)
        {
        }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public double LineWidth
        {
            get { return pen.Thickness; }
            set { pen.Thickness = value; }
        }
        public override void Draw()
        {
            gd.Geometry = new LineGeometry
            {
                StartPoint = StartPoint,
                EndPoint = EndPoint
            };
            Image.Source = new DrawingImage(gd);
        }
    }
}
