using System.Drawing.Drawing2D;
using System.Runtime.Serialization;

namespace ClientWinFormsExamples.ch07.E06
{
    [DataContract(Namespace = "http://V4B2Server/ch07")]
    class DrawText : DrawTextHandle
    {
        private readonly E0706DrawForm fm;

        public DrawText(E0706DrawForm fm):base(fm)
        {
            this.fm = fm;
        }

        public DrawText(E0706DrawForm fm, int x, int y, string textToDraw, Color textColor, int id):base(fm)
        {
            this.fm = fm;
            Text = textToDraw;
            PenColor = textColor;
            FontHeight = 1;
            ID = id;
            StartPoint = new Point(x, y);
            EndPoint = new Point(x + FontHeight * Text.Length, y);
        }

        public DrawText(E0706DrawForm fm, Point p1, Point p2, float angle, string textToDraw, Color textColor, int fontHeight, int id) : base(fm)
        {
            this.fm = fm;
            StartPoint = p1;
            EndPoint = p2;
            Angle = angle;
            Text = textToDraw;
            PenColor = textColor;
            FontHeight = fontHeight;
            ID = id;
        }

        public override void Draw(Graphics g)
        {
            Brush b = new SolidBrush(PenColor);
            font?.Dispose();
            font = new Font("ËÎÌו", FontHeight, FontStyle.Regular, GraphicsUnit.Pixel);
            Matrix matrix = new();
            matrix.RotateAt(Angle, StartPoint);
            g.Transform = matrix;
            g.DrawString(Text, font, b, StartPoint);
            g.ResetTransform();
            matrix.Dispose();
            b.Dispose();
        }
    }
}
