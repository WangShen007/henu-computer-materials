using System.Text;
namespace ClientWinFormsExamples.ch05
{
    public partial class E0501 : Form
    {
        public E0501()
        {
            InitializeComponent();

            buttonCreate.Click += (s, e) =>
            {
                string fileName = textBox1.Text;
                if (File.Exists(fileName) == true)
                {
                    File.Delete(fileName);
                }
                string[] appendText = { "单位：某某学院", "姓名：张三", "成绩：90" };
                try
                {
                    File.WriteAllLines(fileName, appendText, Encoding.Default);
                }
                catch (Exception ex)
                {
                    labelTip.Text = $"创建 {fileName}失败：{ex.Message}";
                }
                labelTip.Text = $"创建 {fileName} 成功";
            };
            buttonOpen.Click += (s, e) =>
            {
                string fileName = textBox1.Text;
                var d = new OpenFileDialog
                {
                    InitialDirectory = System.IO.Path.GetDirectoryName(fileName),
                    Filter = "文本文件|*.txt|所有文件|*.*",
                    FileName = fileName
                };
                if (d.ShowDialog() == DialogResult.OK)
                {
                    fileName = d.FileName;
                    textBox1.Text = fileName;
                    try
                    {
                        textBox2.Text = File.ReadAllText(fileName, Encoding.Default);
                    }
                    catch (Exception ex)
                    {
                        labelTip.Text = $"打开文件失败：{ex.Message}";
                    }
                    labelTip.Text = "提示：文件已打开，请添加或者删除一些内容，然后保存。";
                }
            };
            buttonSave.Click += (s, e) =>
            {
                string fileName = textBox1.Text;
                var d = new SaveFileDialog
                {
                    InitialDirectory = System.IO.Path.GetDirectoryName(fileName),
                    Filter = "文本文件|*.txt|所有文件|*.*",
                    FileName = fileName
                };
                if (d.ShowDialog() == DialogResult.OK)
                {
                    fileName = d.FileName;
                    try
                    {
                        File.WriteAllText(fileName, textBox2.Text, Encoding.Default);
                        textBox2.Text = "";
                        labelTip.Text = "保存成功。";
                    }
                    catch (Exception ex)
                    {
                        labelTip.Text = $"保存失败：{ex.Message}";
                    }
                }
            };
        }
    }
}
