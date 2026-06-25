using System.Runtime.Serialization;
using System.Xml;

namespace ClientWinFormsExamples.ch06
{
    public partial class E0605 : Form
    {
        private byte[]? bytes;
        public E0605()
        {
            InitializeComponent();

            button1.Click += Button1_Click;
            button2.Click += Button2_Click;

            UserInfo user = new();
            ShowMessage($"序列化之前：ID={user.Id}，Name={user.Name}，Age={user.Age} ");
        }

        private void Button1_Click(object? sender, EventArgs e)
        {
            UserInfo user = new();
            try
            {
                //序列化
                bytes = Serialize(user);
            }
            catch (Exception ex)
            {
                ShowMessage($"序列化失败：{ex.Message}");
            }
            if (bytes != null)
            {
                ShowMessage($"已成功将UserInfo对象序列化为字节数组。");
            }
        }

        private void Button2_Click(object? sender, EventArgs e)
        {
            //反序列化
            if (bytes == null)
            {
                ShowMessage("字节数组为null，无法反序列化。");
                return;
            }
            UserInfo? user = Deserialize<UserInfo>(bytes);
            if (user != null)
            {
                var userName = user.Name ?? "null";
                ShowMessage($"反序列化后的结果：ID={user.Id}，Name={userName}，Age={user.Age} ");
            }
        }

        private void ShowMessage(string message)
        {
            listBox1.Items.Add(message);
        }

        public static byte[]? Serialize(object? obj)
        {
            if (obj == null)
            {
                return null;
            }
            MemoryStream memoryStream = new();
            DataContractSerializer dcs = new(typeof(object));
            dcs.WriteObject(memoryStream, obj);
            var data = memoryStream.ToArray();
            return data;
        }


        public static T? Deserialize<T>(byte[] data)
        {
            if (data == null)
            {
                return default;
            }
            using MemoryStream memoryStream = new(data);
            XmlDictionaryReaderQuotas xmlDictionaryReaderQuotas = new()
            {
                MaxArrayLength = 1024 * 1024 * 20
            };
            XmlDictionaryReaderQuotas readerQuotas = xmlDictionaryReaderQuotas;
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(memoryStream, readerQuotas);
            DataContractSerializer ser = new(typeof(T));
            var result = (T?)ser.ReadObject(reader, true);
            return result;
        }

    }

    [DataContract]
    [KnownType(typeof(UserInfo))]
    public class UserInfo
    {
        [DataMember]
        public int Id { get; set; }
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }
        public UserInfo()
        {
            Id = 9912053;
            Name = "张三";
            Age = 20;
        }
    }
}
