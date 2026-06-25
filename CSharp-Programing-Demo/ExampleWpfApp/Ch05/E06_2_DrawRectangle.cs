using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace ExampleWpfApp.Ch05
{
    public class E06_2_DrawRectangle : E06_0_DrawObject
    {
        public E06_2_DrawRectangle(Image image) : base(image)
        {
        }
        public Rect Rect { get; set; }
        public override void Draw()
        {
            RectangleGeometry geometry = new RectangleGeometry(Rect);
            gd.Geometry = geometry;
            Image.Source = new DrawingImage(gd);
        }
    }
}
