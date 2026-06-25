using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch10
{
    public partial class E05Regex : Page
    {
        public E05Regex()
        {
            InitializeComponent();
            textBoxStr.Text = "abcd\n...\n(01)\n(010)\n(0123)123abc45\na12345\n数据结构\n操作系统";
            listBox1.SelectionChanged += (s, e) =>
            {
                var item = (s as ListBox).SelectedItem as ListBoxItem;
                if (item.Content != null)
                {
                    textBoxRegex.Text = item.Tag.ToString();
                }
            };
            btnSearch.Click += delegate
            {
                textBlockResult.Text = "";
                Regex r = null;
                try
                {
                    if (textBoxStr.Text.Contains("\n"))
                        r = new Regex(textBoxRegex.Text, RegexOptions.Multiline);
                    else
                        r = new Regex(textBoxRegex.Text, RegexOptions.Singleline);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "正则表达式格式不正确");
                    return;
                }
                if (r.IsMatch(textBoxStr.Text) == false)
                {
                    textBlockResult.Text = "没有匹配项";
                }
                else
                {
                    Match myMatch = r.Match(textBoxStr.Text);
                    int i = 0;
                    while (myMatch.Success)
                    {
                        textBlockResult.Text += string.Format(
                            "第{0}个匹配项：{1}\n", ++i,
                            myMatch.Groups[0].Value);
                        myMatch = myMatch.NextMatch();
                    }
                }
            };
        }
    }
}
