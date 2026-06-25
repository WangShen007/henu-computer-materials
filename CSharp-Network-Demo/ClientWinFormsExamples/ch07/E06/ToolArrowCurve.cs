using System.Text;
namespace ClientWinFormsExamples.ch07.E06
{
    class ToolArrowCurve : ToolObject
    {
        private readonly int minDistance = 10;
        private Point myLastPoint;

        private readonly E0706DrawForm fm;
        public ToolArrowCurve(E0706DrawForm fm):base(fm)
        {
            this.fm = fm;
        }


        public override void OnMouseDown(PanelUC palette, MouseEventArgs e)
        {
            base.OnMouseDown(palette, e);
            fm.IsToolPoint = false;
            Point p = new(e.X, e.Y);
            DrawArrowCurve w = new(fm, p, Color.Red, 2, fm.UC1.ID);
            AddNewObject(palette, w);
            myLastPoint = p;
            isNewObjectAdded = true;
        }

        public override void OnMouseMove(PanelUC palette, MouseEventArgs e)
        {
            if (isNewObjectAdded == false)
            {
                return;
            }
            Point point = new(e.X, e.Y);
            int index = fm.UC1.FindObjectIndex();
            var a = palette.Graphics[index];
            if(a != null)
            {
                DrawArrowCurve w = (DrawArrowCurve)a;
                if (e.Button == MouseButtons.Left)
                {
                    int dx = myLastPoint.X - point.X;
                    int dy = myLastPoint.Y - point.Y;
                    int distance = (int)Math.Sqrt(dx * dx + dy * dy);
                    if (distance < minDistance)
                    {
                        if (w.PointList.Count > 1)
                        {
                            w.MoveHandleTo(point, w.HandleCount);
                        }
                    }
                    else
                    {
                        w.AddPoint(point);
                        myLastPoint = point;
                    }
                }
                palette.Refresh();
            }
        }

        public override void OnMouseUp(PanelUC palette, MouseEventArgs e)
        {
            if (isNewObjectAdded == false)
            {
                return;
            }
            base.OnMouseUp(palette, e);
            int index = fm.UC1.FindObjectIndex();
            DrawArrowCurve w = (DrawArrowCurve)palette.Graphics[index]!;
            int count = w.PointList.Count;
            if (count > 2)
            {
                StringBuilder x1 = new(count);
                StringBuilder y1 = new(count);
                for (int i = 0; i < count; i++)
                {
                    x1.Append("@" + w.PointList[i].X);
                    y1.Append("@" + w.PointList[i].Y);
                }
                x1 = x1.Remove(0, 1);
                y1 = y1.Remove(0, 1);
                //x点数,y点数,线条宽度,线条颜色,id
                fm.MyClient?.SendToServer(string.Format("DrawMyArrowCurve,{0},{1},{2},{3},{4}",
                    x1, y1, w.PenWidth, w.PenColor.ToArgb(), fm.UC1.ID));
            }
            palette.Graphics.Remove(fm.UC1.ID);
        }
    }
}
