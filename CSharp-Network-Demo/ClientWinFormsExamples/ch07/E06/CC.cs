using System.Runtime.Serialization;

namespace ClientWinFormsExamples.ch07.E06
{
    internal class CC
    {


        /// <summary>将矩形框变为从左上角到右下角</summary>
        public static Rectangle GetNormalizedRectangle(int x1, int y1, int x2, int y2)
        {
            if (x2 < x1)
            {
                //下面的交换x1和x2是用元组来实现的，它相当于：int tmp = x2; x2 = x1; x1 = tmp;
                (x1, x2) = (x2, x1);
            }

            if (y2 < y1)
            {
                (y1, y2) = (y2, y1);
            }
            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        /// <summary>将矩形框变为从左上角到右下角</summary>
        public static Rectangle GetNormalizedRectangle(Point p1, Point p2)
        {
            return GetNormalizedRectangle(p1.X, p1.Y, p2.X, p2.Y);
        }


        public static byte[] BitmapToGrayByte(Bitmap bitmap)
        {
            using MemoryStream ms = new();
            bitmap.Save(ms, bitmap.RawFormat);
            byte[] data = ms.ToArray();
            return data;
        }

        /// <summary>序列化</summary>
        public static byte[]? Serialize<T>(T obj)
        {
            if (obj == null) return null;
            MemoryStream memoryStream = new();
            DataContractSerializer ser = new(typeof(T));
            ser.WriteObject(memoryStream, obj);
            var data = memoryStream.ToArray();
            return data;
        }

        /// <summary>反序列化</summary>
        public static T? Deserialize<T>(byte[] data)
        {
            if (data == null) return default;
            using var memoryStream = new MemoryStream(data);
            DataContractSerializer ser = new(typeof(T));
            var result = (T?)ser.ReadObject(memoryStream);
            return result;
        }
    }
}
