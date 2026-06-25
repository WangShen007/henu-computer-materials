using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace ExampleWpfApp.Ch05
{
    public class E06_3_DrawEllipse : E06_0_DrawObject
    {
        public E06_3_DrawEllipse(Image image) : base(image)
        {
        }
        public Point CenterPoint { get; set; }
        public double RadiusH { get; set; }
        public double RadiusV { get; set; }
        public override void Draw()
        {
            gd.Geometry = new EllipseGeometry
            {
                Center = CenterPoint,
                RadiusX = RadiusH,
                RadiusY = RadiusV
            };
            Image.Source = new DrawingImage(gd);
        }
    }
}
