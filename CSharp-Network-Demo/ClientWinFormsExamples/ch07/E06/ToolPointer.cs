namespace ClientWinFormsExamples.ch07.E06
{

    internal class ToolPointer : ToolObject
    {
        protected enum ToolSelectionMode { None, NetSelection, Move, Size }

        /// <summary>选择模式</summary>
        protected ToolSelectionMode selectMode = ToolSelectionMode.None;

        protected DrawObject? resizedObject;
        protected int resizedObjectHandle;

        protected Point lastPoint = new(0, 0);
        protected Point startPoint = new(0, 0);

        private readonly E0706DrawForm fm;
        public ToolPointer(E0706DrawForm fm):base(fm)
        {
            this.fm = fm;
        }

        /// <summary>鼠标按下事件处理</summary>
        public override void OnMouseDown(PanelUC palette, MouseEventArgs e)
        {
            fm.IsToolPoint = true;

            Point p = new(e.X, e.Y);
            selectMode = ToolSelectionMode.None;
            int n = palette.Graphics.SelectionCount;
            for (int i = n - 1; i >= 0; i--)
            {
                DrawObject w = palette.Graphics.GetSelectedObject(i)!;

                int handleNumber = w.HitTest(p);

                if (handleNumber > 0)
                {
                    selectMode = ToolSelectionMode.Size;
                    resizedObject = w;
                    resizedObjectHandle = handleNumber;
                    palette.Graphics.UnselectAll();
                    w.Selected = true;
                    break;
                }
            }
            if (selectMode == ToolSelectionMode.None)
            {
                int n1 = palette.Graphics.Count;
                DrawObject? w = null;
                //查找是否有对象被选中
                for (int i = n1 - 1; i >= 0; i--)
                {

                    if (palette.Graphics[i]!.HitTest(p) == 0)
                    {
                        w = palette.Graphics[i];
                        break;
                    }
                }
                if (w != null)
                {
                    selectMode = ToolSelectionMode.Move;
                    if ((Control.ModifierKeys & Keys.Control) == 0 && !w.Selected)
                        palette.Graphics.UnselectAll();
                    w.Selected = true;
                    palette.Cursor = Cursors.SizeAll;
                }
            }
            if (selectMode == ToolSelectionMode.None)
            {
                if ((Control.ModifierKeys & Keys.Control) == 0)
                {
                    palette.Graphics.UnselectAll();
                }
                selectMode = ToolSelectionMode.NetSelection;
                palette.IsDrawNetRectangle = true;
            }
            lastPoint.X = p.X;
            lastPoint.Y = p.Y;
            startPoint.X = p.X;
            startPoint.Y = p.Y;
            palette.Capture = true;
            palette.NetRectangle = CC.GetNormalizedRectangle(startPoint, lastPoint);
            palette.Refresh();
        }

        /// <summary>鼠标移动事件处理</summary>
        public override void OnMouseMove(PanelUC palette, MouseEventArgs e)
        {
            Point p = new(e.X, e.Y);
            if (e.Button == MouseButtons.None)
            {
                Cursor? cursor = null;
                if (palette.Graphics != null)
                {
                    for (int i = palette.Graphics.Count - 1; i >= 0; i--)
                    {
                        var pg = palette.Graphics[i];
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

                if (cursor == null && palette.Graphics != null)
                {
                    int x = 0;
                    for (int j = palette.Graphics.Count - 1; j >= 0; j--)
                    {
                        var pg = palette.Graphics[j];
                        if (pg != null && pg.Selected)
                        {
                            x++;
                        }
                    }
                    if (x == 1)
                    {
                        for (int j = palette.Graphics.Count - 1; j >= 0; j--)
                        {
                            var pg = palette.Graphics[j];
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
                palette.Cursor = cursor;
                return;
            }
            if (e.Button != MouseButtons.Left) return;

            int dx = p.X - lastPoint.X;
            int dy = p.Y - lastPoint.Y;

            lastPoint.X = p.X;
            lastPoint.Y = p.Y;
            //如果鼠标的状态为Size，则要调整选中对象的大小。
            if (selectMode == ToolSelectionMode.Size)
            {
                if (resizedObject != null)
                {
                    //通过调用对象的MoveHandleTo方法改变句柄点的位置。
                    resizedObject.MoveHandleTo(p, resizedObjectHandle);
                    palette.Refresh();
                }
            }
            //如果鼠标指针的状态为Move，则实现点的平移
            if (selectMode == ToolSelectionMode.Move)
            {
                int n = palette.Graphics.SelectionCount;
                for (int i = n - 1; i >= 0; i--)
                {
                    palette.Graphics.GetSelectedObject(i)?.Move(dx, dy);
                }
                palette.Cursor = Cursors.SizeAll;
                palette.Refresh();
            }
            //表示可以通过拖动鼠标选中一个或多个对象，此时会显示一个虚线框。
            if (selectMode == ToolSelectionMode.NetSelection)
            {
                palette.NetRectangle = CC.GetNormalizedRectangle(startPoint, lastPoint);
                palette.Refresh();
                return;
            }
        }

        public override void OnMouseUp(PanelUC palette, MouseEventArgs e)
        {
            if (selectMode == ToolSelectionMode.NetSelection)
            {
                palette.Graphics.SelectInRectangle(palette.NetRectangle);
                selectMode = ToolSelectionMode.None;
                palette.IsDrawNetRectangle = false;
            }

            if (selectMode == ToolSelectionMode.Size)
            {
                if (resizedObject != null)
                {
                    string s = resizedObject.ID.ToString() + "@" + resizedObjectHandle;
                    //x,y,移动对象ID和句柄,IPEndPoint
                    fm.MyClient?.SendToServer(string.Format("MoveObjectHandle,{0},{1},{2},{3}",
                        lastPoint.X, lastPoint.Y, s, fm.MyClient?.Client.Client.LocalEndPoint));
                }
            }
            else if (selectMode == ToolSelectionMode.Move)
            {
                int dx = lastPoint.X - startPoint.X;
                int dy = lastPoint.Y - startPoint.Y;
                int n = palette.Graphics.SelectionCount;
                string s = "";
                for (int i = n - 1; i >= 0; i--)
                {
                    DrawObject? w = palette.Graphics.GetSelectedObject(i)!;
                    s += w.ID + "@";
                }
                //x,y,移动的对象ID集合,IPEndPoint
                fm.MyClient?.SendToServer(string.Format("MoveObject,{0},{1},{2},{3}",
                    dx, dy, s.TrimEnd('@'), fm.MyClient?.Client.Client.LocalEndPoint));

            }
            if (resizedObject != null)
            {
                resizedObject = null;
            }
            palette.Capture = false;
            palette.Refresh();

        }
    }
}
