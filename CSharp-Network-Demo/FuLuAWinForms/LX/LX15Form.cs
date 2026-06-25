using System.Text;

namespace FuLuAWinForms
{
    public partial class LX15Form : Form
    {
        public LX15Form()
        {
            InitializeComponent();

            var newLine = Environment.NewLine;
            textBoxFilePath.Text = @"D:\ls\MyFile.txt";
            textBox1.Text = "长歌行" +
                $"{newLine}{newLine}作者：汉乐府" +
                $"{newLine}{newLine}青青园中葵，朝露待日晞。" +
                $"{newLine}阳春布德泽，万物生光辉。" +
                $"{newLine}常恐秋节至，焜黄华叶衰。" +
                $"{newLine}百川东到海，何时复西归？" +
                $"{newLine}少壮不努力，老大徒伤悲。";
            btnBrower.Click += (s, e) =>
            {
                OpenFileDialog f = new()
                {
                    InitialDirectory = @"D:\ls"
                };
                if (f.ShowDialog() == DialogResult.OK)
                {
                    textBoxFilePath.Text = f.FileName;
                }
            };
            btnRead.Click += (s, e) =>
            {
                try
                {
                    string str = File.ReadAllText(textBoxFilePath.Text, Encoding.Default);
                    textBox1.Text = str;
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                    textBox1.Text = "";
                }
            };
            btnSave.Click += (s, e) =>
            {
                try
                {
                    File.WriteAllText(textBoxFilePath.Text, textBox1.Text, Encoding.Default);
                    textBox1.Text = "";
                    MessageBox.Show("保存成功!");
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "保存文件失败!");
                }
            };
        }
    }
}
