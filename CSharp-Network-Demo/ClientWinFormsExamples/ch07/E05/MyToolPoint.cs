namespace ClientWinFormsExamples.ch07.E05
{
    internal enum MyToolSelectionMode { None, NetSelection, Move, Size }
    internal class MyToolPointer : MyToolObject
    {
        /// <summary>选择模式</summary>
        protected MyToolSelectionMode selectMode = MyToolSelectionMode.None;
        protected MyDrawObject? resizedObject;
        protected int resizedObjectHandle;

        protected Point lastPoint = new(0, 0);
        protected Point startPoint = new(0, 0);

        /// <summary>鼠标按下事件处理</summary>
        public override void OnMouseDown(MyUC myuc, MouseEventArgs e)
        {
            MyCC.IsToolPoint = true;

            Point p = new(e.X, e.Y);
            selectMode = MyToolSelectionMode.None;
            int n = myuc.Graphics.SelectionCount;
            for (int i = n - 1; i >= 0; i--)
            {
                MyDrawObject w = myuc.Graphics.GetSelectedObject(i)!;

                int handleNumber = w.HitTest(p);

                if (handleNumber > 0)
                {
                    selectMode = MyToolSelectionMode.Size;
                    resizedObject = w;
                    resizedObjectHandle = handleNumber;
                    myuc.Graphics.UnselectAll();
                    w.Selected = true;
                    break;
                }
            }
            if (selectMode == MyToolSelectionMode.None)
            {
                int n1 = myuc.Graphics.Count;
                MyDrawObject? w = null;
                //查找是否有对象被选中
                for (int i = n1 - 1; i >= 0; i--)
                {

                    if (myuc.Graphics[i]!.HitTest(p) == 0)
                    {
                        w = myuc.Graphics[i];
                        break;
                    }
                }
                if (w != null)
                {
                    selectMode = MyToolSelectionMode.Move;
                    if ((Control.ModifierKeys & Keys.Control) == 0 && !w.Selected)
                        myuc.Graphics.UnselectAll();
                    w.Selected = true;
                    myuc.Cursor = Cursors.SizeAll;
                }
            }
            if (selectMode == MyToolSelectionMode.None)
            {
                if ((Control.ModifierKeys & Keys.Control) == 0)
                {
                    myuc.Graphics.UnselectAll();
                }
                selectMode = MyToolSelectionMode.NetSelection;
                myuc.IsDrawNetRectangle = true;
            }
            lastPoint.X = p.X;
            lastPoint.Y = p.Y;
            startPoint.X = p.X;
            startPoint.Y = p.Y;
            myuc.Capture = true;
            myuc.NetRectangle = MyCC.GetNormalizedRectangle(startPoint, lastPoint);
            myuc.Refresh();
        }

        /// <summary>鼠标移动事件处理</summary>
        public override void OnMouseMove(MyUC myuc, MouseEventArgs e)
        {
            Point p = new(e.X, e.Y);
            if (e.Button == MouseButtons.None)
            {
                Cursor? cursor = null;
                if (myuc.Graphics != null)
                {
                    for (int i = myuc.Graphics.Count - 1; i >= 0; i--)
                    {
                        var pg = myuc.Graphics[i];
                        if (pg != null)
                        {
                            int n = pg.HitTest(p);
                            if (n == 0)
                            {
                                cursor = Cursors.Hand;
                            }
                            else if (n > 0)
                            {
                                cursor = pg.GetHandleCursor(n);
                                break;
                            }
                        }
                    }
                }

                if (cursor == null && myuc.Graphics != null)
                {
                    int x = 0;
                    for (int j = myuc.Graphics.Count - 1; j >= 0; j--)
                    {
                        var pg = myuc.Graphics[j];
                        if (pg != null && pg.Selected)
                        {
                            x++;
                        }
                    }
                    if (x == 1)
                    {
                        for (int j = myuc.Graphics.Count - 1; j >= 0; j--)
                        {
                            var pg = myuc.Graphics[j];
                            if (pg != null)
                            {
                                if (pg.Selected && pg.PointInObject(p))
                                {
                                    cursor = Cursors.NoMove2D;
                                }
                            }
                        }
                    }
                }
                myuc.Cursor = cursor;
                return;
            }
            if (e.Button != MouseButtons.Left) return;

            int dx = p.X - lastPoint.X;
            int dy = p.Y - lastPoint.Y;

            lastPoint.X = p.X;
            lastPoint.Y = p.Y;
            //如果鼠标的状态为Size，则要调整选中对象的大小。
            if (selectMode == MyToolSelectionMode.Size)
            {
                if (resizedObject != null)
                {
                    //通过调用对象的MoveHandleTo方法改变句柄点的位置。
                    resizedObject.MoveHandleTo(p, resizedObjectHandle);
                    myuc.Refresh();
                }
            }

            //如果鼠标指针的状态为Move，则实现点的平移
            if (selectMode == MyToolSelectionMode.Move)
            {
                int n = myuc.Graphics.SelectionCount;
                for (int i = n - 1; i >= 0; i--)
                {
                    myuc.Graphics.GetSelectedObject(i)?.Move(dx, dy);
                }
                myuc.Cursor = Cursors.SizeAll;
                myuc.Refresh();
            }

            //表示可以通过拖动鼠标选中一个或多个对象，此时会显示一个虚线框。
            if (selectMode == MyToolSelectionMode.NetSelection)
            {
                myuc.NetRectangle = MyCC.GetNormalizedRectangle(startPoint, lastPoint);
                myuc.Refresh();
                return;
            }
        }

        public override void OnMouseUp(MyUC myuc, MouseEventArgs e)
        {
            if (selectMode == MyToolSelectionMode.NetSelection)
            {
                myuc.Graphics.SelectInRectangle(myuc.NetRectangle);
                selectMode = MyToolSelectionMode.None;
                myuc.IsDrawNetRectangle = false;
            }


            if (resizedObject != null)
            {
                resizedObject = null;
            }
            myuc.Capture = false;
            myuc.Refresh();

        }
    }
}
