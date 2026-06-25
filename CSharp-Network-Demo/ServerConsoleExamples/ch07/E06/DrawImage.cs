using System.Drawing;
using System.Runtime.Serialization;

namespace ServerConsoleExamples.ch07.E06
{
    [DataContract(Namespace = "http://V4B2Server/ch07")]
    class DrawImage : DrawRectangleHandle
    {
        [DataMember]
        public byte[]? ImageBytes { get; set; }

        public DrawImage(int x, int y, int width, int height, byte[] imagesByte, int id)
        {
            ObjRectangle = new Rectangle(x, y, width, height);
            ImageBytes = imagesByte;
            ID = id;
        }
    }
}
