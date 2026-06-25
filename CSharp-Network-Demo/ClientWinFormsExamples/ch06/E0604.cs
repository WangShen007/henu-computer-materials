using System.Text;

namespace ClientWinFormsExamples.ch06
{
    public partial class E0604 : Form
    {
        public E0604()
        {
            InitializeComponent();
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
        }

        private void Button1_Click(object? sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (EncodingInfo ei in Encoding.GetEncodings())
            {
                Encoding en = ei.GetEncoding();
                listBox1.Items.Add($"编码名称：{ei.Name}，说明：{en.EncodingName}");
            }
        }

        private void Button2_Click(object? sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string s = "ab,12,软件";
            listBox1.Items.Add($"被编码的字符串：{s}");
            EncodeAndDecode(s, Encoding.ASCII);
            EncodeAndDecode(s, Encoding.UTF8);
            EncodeAndDecode(s, Encoding.Unicode);
        }

        private void EncodeAndDecode(string s, Encoding encoding)
        {
            //发送方将字符串编码为字节数组，然后通过网络发送给接收方
            byte[] bytes = encoding.GetBytes(s);
            //接收方收到发送方发来的信息后，再将接收的字节数组解码为字符串
            string str = encoding.GetString(bytes);
            //显示结果
            string encodeResult = BitConverter.ToString(bytes);
            listBox1.Items.Add("");
            listBox1.Items.Add($"编码为：{encoding}（{encoding.EncodingName}），编码结果：{encodeResult}");
            listBox1.Items.Add($"解码结果：{str}");
        }
    }
}
