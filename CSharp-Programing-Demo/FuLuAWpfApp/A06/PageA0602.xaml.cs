using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FuLuAWpfApp.A06
{
    /// <summary>
    /// PageA0602.xaml 的交互逻辑
    /// </summary>
    public partial class PageA0602 : Page
    {
        public PageA0602()
        {
            InitializeComponent();

            textBoxFilePath.Text = @"D:\ls\MyFile.txt";
            textBox1.Text = "长歌行" +
                "\n\n作者：汉乐府" +
                "\n\n青青园中葵，朝露待日晞。" +
                "\n阳春布德泽，万物生光辉。" +
                "\n常恐秋节至，焜黄华叶衰。" +
                "\n百川东到海，何时复西归？" +
                "\n少壮不努力，老大徒伤悲。";
            btnBrower.Click += (s, e) =>
            {
                OpenFileDialog f = new OpenFileDialog();
                if (f.ShowDialog() == true)
                {
                    textBoxFilePath.Text = f.FileName;
                }
            };
            btnRead.Click += (s, e) =>
            {
                try
                {
                    string[] str = File.ReadAllLines(textBoxFilePath.Text, Encoding.Default);
                    textBox1.Text = string.Join("\r\n", str);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message + "\n\n系统将自动创建该文件。");
                    textBox1.Text = "";
                }
            };
            btnSave.Click += (s, e) =>
            {
                try
                {
                    File.WriteAllLines(textBoxFilePath.Text,
                        textBox1.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None), Encoding.Default);
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
