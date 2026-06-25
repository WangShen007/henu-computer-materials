using System.Drawing;
using System.Runtime.Serialization;
using System.Xml;

namespace ServerConsoleExamples.ch07.E06
{
    internal class CC
    {
        /// <summary>自动备份文件名</summary>
        public static string BackupFileName { get; set; } = "serverbackup.gcs";
        public static E0706TcpServer? Server { get; set; }
        /// <summary>对象的唯一标识</summary>
        public static int ID { get; set; } = 1;
        /// <summary>绘图对象列表</summary>
        public static GraphicsList MyGraphicsList { get; set; } = new GraphicsList();

        /// <summary>将矩形框变为从左上角到右下角</summary>
        public static Rectangle GetNormalizedRectangle(int x1, int y1, int x2, int y2)
        {
            if (x2 < x1) { (x1, x2) = (x2, x1); }
            if (y2 < y1) { (y1, y2) = (y2, y1); }
            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        /// <summary>序列化 </summary>
        public static byte[]? Serialize<T>(T obj)
        {
            if (obj == null) return null;
            MemoryStream memoryStream = new();
            DataContractSerializer ser = new(typeof(T));
            ser.WriteObject(memoryStream, obj);
            var data = memoryStream.ToArray();
            return data;
        }

        /// <summary>将Graphics序列化到fileName中</summary>
        public static void SerializeObject(GraphicsList serializedGraphics, string fileName)
        {
            try
            {
                using Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                byte[]? buffer = Serialize(serializedGraphics);
                if (buffer != null) stream.Write(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine("保存文件失败，原因：" + ex.Message);
            }
        }


        /// <summary>反序列化 </summary>
        public static T? Deserialize<T>(byte[] data)
        {
            if (data == null) return default;

            using var memoryStream = new MemoryStream(data);
            DataContractSerializer ser = new(typeof(T));
            var result = (T?)ser.ReadObject(memoryStream);
            return result;
        }

        /// <summary>将fileName反序列化到Graphics中</summary>
        public static void DeserializeObject(string fileName)
        {
            if (File.Exists(fileName) == false) return;
            try
            {
                int id = 0;
                using FileStream fs = new(fileName, FileMode.Open, FileAccess.Read);
                int count = (int)fs.Length;
                byte[] buffer = new byte[count];
                int realreadlength = fs.Read(buffer, 0, count);
                MyGraphicsList = Deserialize<GraphicsList>(buffer) ?? new();
                for (int i = 0; i < MyGraphicsList.Count; i++)
                {
                    if (MyGraphicsList[i]!.ID > id) id = MyGraphicsList[i]!.ID;
                }
                id++;
                ID = id;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"打开文件失败，文件名：{fileName}\n原因：{ex.Message}");
            }
        }
    }
}
