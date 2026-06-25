namespace ClientWinFormsExamples.ch07.E06
{
    class ToolRectangle : ToolObject
    {
        private readonly E0706DrawForm fm;
        public ToolRectangle(E0706DrawForm fm):base(fm)
        {
            this.fm = fm;
        }

        public override void OnMouseDown(PanelUC palette, MouseEventArgs e)
        {
            base.OnMouseDown(palette, e);
            DrawRectangle w = new(fm, e.X, e.Y, 15, 15, Color.Red, fm.UC1.ID);
            AddNewObject(palette, w);
            isNewObjectAdded = true;
        }

        public override void OnMouseUp(PanelUC palette, MouseEventArgs e)
        {
            if (isNewObjectAdded == false)
            {
                return;
            }
            base.OnMouseUp(palette, e);

            int index = fm.UC1.FindObjectIndex();
            DrawRectangle w = (DrawRectangle)palette.Graphics[index]!;
            //左上角x坐标，左上角y坐标,宽,高,颜色,id
            fm.MyClient?.SendToServer(string.Format("DrawMyRectangle,{0},{1},{2},{3},{4},{5}",
                w.ObjRectangle.X, w.ObjRectangle.Y, w.ObjRectangle.Width,
                w.ObjRectangle.Height, w.PenColor.ToArgb(), fm.UC1.ID));
            palette.Graphics.Remove(fm.UC1.ID);
        }
    }
}
