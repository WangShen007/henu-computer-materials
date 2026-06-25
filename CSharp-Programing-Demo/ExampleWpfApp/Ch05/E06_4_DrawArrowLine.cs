using System.Windows.Controls;
using System.Windows.Media;

namespace ExampleWpfApp.Ch05
{
    public class E06_4_DrawArrowLine : E06_1_DrawLine
    {
        public E06_4_DrawArrowLine(Image image) : base(image)
        {
        }
        public override void Draw()
        {
            pen.EndLineCap = PenLineCap.Triangle;
            base.Draw();
        }
    }
}
