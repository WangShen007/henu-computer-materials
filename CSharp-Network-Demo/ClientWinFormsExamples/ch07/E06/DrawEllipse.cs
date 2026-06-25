using System.Runtime.Serialization;

namespace ClientWinFormsExamples.ch07.E06
{
    [DataContract(Namespace = "http://V4B2Server/ch07")]
    class DrawEllipse : DrawRectangleHandle
    {
        public DrawEllipse(E0706DrawForm fm):base(fm)
        {
        }

        public DrawEllipse(E0706DrawForm fm,int x, int y, int width, int height, Color penColor, int id) : base(fm)
        {
            ObjRectangle = new Rectangle(x, y, width, height);
            PenColor = penColor;
            ID = id;
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new(PenColor);
            g.DrawEllipse(pen, ObjRectangle);
            pen.Dispose();
        }

    }
}
