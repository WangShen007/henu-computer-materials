using System.Text;

namespace ClientWinFormsExamples.ch07.E05
{
    class MyToolArrowCurve : MyToolObject
    {
        private readonly int minDistance = 10;
        private Point myLastPoint;

        public override void OnMouseDown(MyUC myuc, MouseEventArgs e)
        {
            base.OnMouseDown(myuc, e);
            MyCC.IsToolPoint = false;
            Point p = new(e.X, e.Y);
            MyDrawArrowCurve w = new(p, Color.Red, 2, MyCC.ID);
            AddNewObject(myuc, w);
            myLastPoint = p;
            isNewObjectAdded = true;
        }

        public override void OnMouseMove(MyUC myuc, MouseEventArgs e)
        {
            if (isNewObjectAdded == false)
            {
                return;
            }
            Point point = new(e.X, e.Y);
            int index = MyCC.FindObjectIndex(MyCC.ID);
            MyDrawArrowCurve w = (MyDrawArrowCurve)myuc.Graphics[index]!;
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
            myuc.Refresh();
        }

        public override void OnMouseUp(MyUC myuc, MouseEventArgs e)
        {
            if (isNewObjectAdded == false)
            {
                return;
            }
            base.OnMouseUp(myuc, e);
        }
    }
}
