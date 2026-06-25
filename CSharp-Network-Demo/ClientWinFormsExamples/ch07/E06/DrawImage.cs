using System.Runtime.Serialization;

namespace ClientWinFormsExamples.ch07.E06
{
    [DataContract(Namespace = "http://V4B2Server/ch07")]
    class DrawImage : DrawRectangleHandle
    {
        [DataMember]
        public byte[]? ImageBytes { get; set; }

        private readonly E0706DrawForm fm;

        public DrawImage(E0706DrawForm fm):base(fm)
        {
            this.fm = fm;
        }

        public DrawImage(E0706DrawForm fm,int x, int y, int width, int height, byte[] imagesByte, int id) : base(fm)
        {
            this.fm = fm;
            ObjRectangle = new Rectangle(x, y, width, height);
            ImageBytes = imagesByte;
            ID = id;
        }

        public override DrawObject Clone()
        {
            DrawImage w = new(fm)
            {
                ObjRectangle = ObjRectangle,
                ImageBytes = ImageBytes
            };
            AddOtherFields(w);
            return w;
        }

        public override void Draw(Graphics g)
        {
            if (ImageBytes == null)
            {
                Pen p = new(Color.Black, -1f);
                g.DrawRectangle(p, ObjRectangle);
            }
            else
            {
                using MemoryStream memoryStream = new(ImageBytes);
                Bitmap bitmap = (Bitmap)Image.FromStream(memoryStream);

                //将bitmap设置为对其默认的透明色透明
                bitmap.MakeTransparent();
                g.DrawImage(bitmap, ObjRectangle, 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel);
            }
        }
    }
}
