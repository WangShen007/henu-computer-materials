namespace ClientWinFormsExamples.ch07.E06
{
    class ToolImage : ToolObject
    {
        private readonly E0706DrawForm fm;
        public ToolImage(E0706DrawForm fm):base(fm)
        {
            this.fm = fm;
        }

        public override void OnMouseDown(PanelUC palette, MouseEventArgs e)
        {
            base.OnMouseDown(palette, e);
            DrawImage w = new(fm, e.X, e.Y, 15, 15, fm.Imagesbytes!, fm.UC1.ID);
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
            DrawImage w = (DrawImage)palette.Graphics[index]!;
            GraphicsList myGraphicsList = new();
            myGraphicsList.Add(w.Clone());
            //序列化
            try
            {
                using MemoryStream stream = new();
                byte[]? bytes = CC.Serialize(myGraphicsList);
                if (bytes != null)
                {
                    //层号，序列化后的字节数
                    fm.MyClient?.SendToServer($"DrawMyImage,{bytes.Length}");
                    fm.MyClient?.SendToServer(bytes);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "序列化失败");
            }
            palette.Graphics.Remove(fm.UC1.ID);
        }
    }
}
