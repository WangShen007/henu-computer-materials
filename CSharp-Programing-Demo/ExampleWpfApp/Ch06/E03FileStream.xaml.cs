using System.IO;
using System.Text;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch06
{
    public partial class E03FileStream : Page
    {
        public E03FileStream()
        {
            InitializeComponent();
            Loaded += delegate {
                ShowDemo();
            };
        }
        private void ShowDemo()
        {
            string path = @"d:\ls\E0603.txt";
            txtState.Text = $"写入内容到 {path} 中。";
            using (FileStream fs = File.Open(path, FileMode.Create))
            {
                byte[] b = Encoding.UTF8.GetBytes("你好！\nThis is some text in the file.");
                fs.Write(b, 0, b.Length);
            }
            txtState.Text += $"\n读取 {path} 的内容到文本框。";
            using (FileStream fs = File.Open(path, FileMode.Open))
            {
                byte[] b = new byte[1024];   //每次读取的缓存大小
                int len = 0;
                while ((len = fs.Read(b, 0, b.Length)) > 0)
                {
                    uc1.Result.Text = $"{Encoding.UTF8.GetString(b, 0, len)}\n";
                }
            }
        }
    }
}
