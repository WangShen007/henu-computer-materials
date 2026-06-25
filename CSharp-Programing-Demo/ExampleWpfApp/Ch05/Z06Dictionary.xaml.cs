using System.Collections.Generic;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch05
{
    public partial class Z06Dictionary : Page
    {
        public Z06Dictionary()
        {
            InitializeComponent();
            var v1 = new DictionaryDemo();
            uc1.tip.Text = "Dictionary<string, int>";
            uc1.Result.Text = v1.Result;
            var v2 = new SortedDictionaryDemo();
            uc1.tip.Text = "SortedDictionary<int, string>";
            uc2.Result.Text += v2.Result;
        }
    }
    public class DictionaryDemo
    {
        public string Result { get; set; } = "";
        public DictionaryDemo()
        {
            Dictionary<string, int> storedBooks = new Dictionary<string, int>
            {
                { "book1", 15 },
                { "book2", 25 },
                { "book3", 5 }
            };
            //输出字典中所有的书籍名称和存书数量
            foreach (var v in storedBooks)
            {
                Result += $"Key={v.Key},Value={v.Value}\t";
            }
            //检查字典中是否存在mybook
            if (!storedBooks.ContainsKey("mybook"))
            {
                storedBooks.Add("mybook", 30);
            }
            //输出book2中保存的数量
            Result += $"\n{storedBooks["book2"]}";

            //如果存在book4，修改数量；如果不存在book4，将其添加到字典中
            storedBooks["book4"] = 20;
            //获取book2的数量
            if (storedBooks.TryGetValue("book2", out int value))
            {
                Result += $"\n[book2], value = {value}";
            }
            else
            {
                Result += "\n[book2]在字典中不存在";
            }
            //如果存在book0，将其从字典中删除
            storedBooks.Remove("book0");
        }
    }
    public class SortedDictionaryDemo
    {
        public string Result { get; set; } = "";
        public SortedDictionaryDemo()
        {
            SortedDictionary<int, string> students = new SortedDictionary<int, string>
            {
              { 2, "李四"},
              { 1, "张三"},
              { 3, "王五"}
            };
            foreach (var v in students)
            {
                Result += $"编号：{v.Key:d4}--姓名：{v.Value}\n";
            }
        }
    }
}
