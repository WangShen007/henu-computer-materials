namespace ClientWinFormsExamples.ch07.E05
{
    /// <summary>绘图工具类型</summary>
    public enum MyToolType { Pointer, Curve, ArrowCurve };

    public class MyToolObject
    {
        protected bool isNewObjectAdded = false;

        public virtual void OnMouseDown(MyUC myuc, MouseEventArgs e)
        {
            isNewObjectAdded = false;
            MyCC.SetNewID();
        }

        public virtual void OnMouseMove(MyUC myuc, MouseEventArgs e)
        {
            if (isNewObjectAdded == false)
            {
                return;
            }
            Point point = new(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
            {
                int index = MyCC.FindObjectIndex(MyCC.ID);
                MyDrawObject? w = myuc.Graphics[index];
                w?.MoveHandleTo(point, 5);
            }
            myuc.Refresh();
        }

        public virtual void OnMouseUp(MyUC myuc, MouseEventArgs e)
        {
            myuc.Capture = false;
            myuc.Refresh();
            isNewObjectAdded = false;
        }

        /// <summary>添加新的图形对象</summary>
        protected virtual void AddNewObject(MyUC myuc, MyDrawObject w)
        {
            myuc.Graphics.UnselectAll();
            w.Selected = true;
            myuc.Graphics.Add(w);
            myuc.Capture = true;
            myuc.Refresh();
        }
    }
}
