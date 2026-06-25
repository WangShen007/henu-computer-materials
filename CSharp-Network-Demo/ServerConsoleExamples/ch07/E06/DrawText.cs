using System.Drawing;
using System.Runtime.Serialization;

namespace ServerConsoleExamples.ch07.E06
{
    [DataContract(Namespace = "http://V4B2Server/ch07")]
    class DrawText : DrawTextHandle
    {
        public DrawText(Point p1, Point p2, float angle, string textToDraw, Color textColor, int fontHeight, int id)
        {
            StartPoint = p1;
            EndPoint = p2;
            Angle = angle;
            Text = textToDraw;
            PenColor = textColor;
            FontHeight = fontHeight;
            ID = id;
        }

    }
}
