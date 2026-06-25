using System.Drawing;
using System.Runtime.Serialization;

namespace ServerConsoleExamples.ch07.E06
{
    [DataContract(Namespace = "http://V4B2Server/ch07")]
    class DrawEllipse : DrawRectangleHandle
    {
        public DrawEllipse() { }

        public DrawEllipse(int x, int y, int width, int height, Color penColor, int id)
        {
            ObjRectangle = new Rectangle(x, y, width, height);
            PenColor = penColor;
            ID = id;
        }
    }
}
