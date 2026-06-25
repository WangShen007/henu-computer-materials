namespace ClientWinFormsExamples.ch07.E06
{
    class ToolText : ToolObject
    {
        private readonly E0706DrawForm fm;
        public ToolText(E0706DrawForm fm):base(fm)
        {
            this.fm = fm;
        }

        public override void OnMouseDown(PanelUC palette, MouseEventArgs e)
        {
            base.OnMouseDown(palette, e);
            DrawText w = new(fm, e.X, e.Y, fm.TextInfo.Text, fm.TextInfo.Color, fm.UC1.ID);
            AddNewObject(palette, w);
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
            if (e.Button == MouseButtons.Left)
            {
                var a = palette.Graphics[index];
                if(a != null)
                {
                    DrawObject w = a;
                    w.MoveHandleTo(point, 2);
                }
            }
            palette.Refresh();
        }

        public override void OnMouseUp(PanelUC palette, MouseEventArgs e)
        {
            if (isNewObjectAdded == false)
            {
                return;
            }
            base.OnMouseUp(palette, e);
            int index = fm.UC1.FindObjectIndex();
            var a = palette.Graphics[index];
            if(a != null)
            {
                DrawText w = (DrawText)a;
                //x1，y1,x2,y2,旋转角度,文字内容,颜色,文字高,id
                fm.MyClient?.SendToServer(string.Format("DrawMyText,{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                    w.StartPoint.X, w.StartPoint.Y, w.EndPoint.X, w.EndPoint.Y, w.Angle,
                    w.Text, w.PenColor.ToArgb(), w.FontHeight, w.ID));
                palette.Graphics.Remove(fm.UC1.ID);
            }
        }
    }
}
