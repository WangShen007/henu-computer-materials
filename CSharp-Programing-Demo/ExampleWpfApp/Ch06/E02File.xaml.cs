using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch06
{
    public partial class E02File : Page
    {
        public E02File()
        {
            InitializeComponent();
            InitDemo();
        }
        private void InitDemo()
        {
            string fileName = @"d:\ls\E0602.txt";
            txtFileName.Text = fileName;
            btnCreateDirectory.Click += delegate
            {
                var directoryName = System.IO.Path.GetDirectoryName(fileName);
                if (Directory.Exists(directoryName))
                {
                    txtState.Text = $"文件夹 {directoryName} 已存在，不能重复创建";
                    return;
                }
                try
                {
                    Directory.CreateDirectory(directoryName);
                    txtState.Text = $"创建 {directoryName} 成功";
                }
                catch (Exception ex)
                {
                    txtState.Text = $"创建 {directoryName} 失败：{ex.Message}";
                }
            };
            btnCreateFile.Click += delegate
            {
                if (File.Exists(fileName) == false)
                {
                    File.Delete(fileName);
                }
                string[] appendText = { "单位：某某学院", "姓名：张三", "成绩：90" };
                File.WriteAllLines(fileName, appendText, Encoding.Default);
                txtState.Text = $"创建 {fileName} 成功";
            };
            btnOpen.Click += (s, e) =>
            {
                var open = new OpenFileDialog
                {
                    InitialDirectory = System.IO.Path.GetDirectoryName(fileName),
                    Filter="文本文件（*.txt）|*.txt|所有文件（*.*）|*.*",
                    FileName = fileName
                };
                if (open.ShowDialog() == true)
                {
                    fileName = open.FileName;
                    txtFileName.Text = fileName;
                    txtResult.Text = File.ReadAllText(fileName, Encoding.Default);
                    txtState.Text = "文件已打开，请添加或者删除一些内容，然后保存。";
                }
            };
            btnSave.Click += (s, e) =>
            {
                var save = new SaveFileDialog
                {
                    InitialDirectory = System.IO.Path.GetDirectoryName(fileName),
                    FileName = fileName
                };
                if (save.ShowDialog() == true)
                {
                    fileName = save.FileName;
                    try
                    {
                        File.WriteAllText(fileName, txtResult.Text, Encoding.Default);
                        txtResult.Text = "";
                        txtState.Text = "保存成功。";
                    }
                    catch (Exception ex)
                    {
                        txtState.Text = $"保存失败：{ex.Message}";
                    }
                }
            };
        }
    }
}
