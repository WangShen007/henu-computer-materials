namespace ClientWinFormsExamples.ch07.E06
{
    /// <summary>绘图工具类型</summary>
    public enum ToolType { Pointer, Rectangle, Ellipse, Text, Curve, ArrowCurve, Image };

    public class ToolObject
    {
        protected bool isNewObjectAdded = false;

        private readonly E0706DrawForm fm;
        public ToolObject(E0706DrawForm fm)
        {
            this.fm = fm;
        }

        public virtual void OnMouseDown(PanelUC palette, MouseEventArgs e)
        {
            isNewObjectAdded = false;
            fm.MyClient?.SetNewID();
        }

        public virtual void OnMouseMove(PanelUC panelUC, MouseEventArgs e)
        {
            if (isNewObjectAdded == false)
            {
                return;
            }
            Point point = new(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
            {
                int index = fm.UC1.FindObjectIndex();
                DrawObject? w = panelUC.Graphics[index];
                w?.MoveHandleTo(point, 5);
            }
            panelUC.Refresh();
        }

        public virtual void OnMouseUp(PanelUC panelUC, MouseEventArgs e)
        {
            panelUC.Capture = false;
            panelUC.Refresh();
            isNewObjectAdded = false;
        }

        /// <summary>添加新的图形对象</summary>
        protected virtual void AddNewObject(PanelUC panelUC, DrawObject w)
        {
            panelUC.Graphics.UnselectAll();
            w.Selected = true;
            panelUC.Graphics.Add(w);
            panelUC.Capture = true;
            panelUC.Refresh();
        }
    }
}

