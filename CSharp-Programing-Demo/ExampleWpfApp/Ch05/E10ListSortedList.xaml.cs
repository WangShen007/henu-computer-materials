using System.Collections.Generic;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch05
{
    public partial class E10ListSortedList : Page
    {
        public E10ListSortedList()
        {
            InitializeComponent();
            var v1 = new ListDemo();
            uc1.tip.Text = "List<string>";
            uc1.Result.Text = v1.Result;
            var v2 = new SortedListDemo();
            uc2.tip.Text = "SortedList<string,int>";
            uc2.Result.Text += v2.Result;
        }
    }
    public class ListDemo
    {
        public string Result { get; set; } = "";
        public ListDemo()
        {
            //初始化
            List<string> list = new List<string> { "张三", "李四", "王五" };
            //插入
            list.Insert(0, "赵六");
            //添加（避免重复）
            if (list.Contains("胡七") == false) { list.Add("胡七"); }
            //遍历（方式1）
            foreach (var v in list) { Result += $"{v}\t"; }
            Result += "\n";
            //遍历（方式2）
            for (int i = 0; i < list.Count; i++)
            {
                Result += $"list[{i}]={list[i]}\t";
            }
        }
    }
    public class SortedListDemo
    {
        public string Result { get; set; } = "";
        public SortedListDemo()
        {
            //初始化
            var sl = new SortedList<string, int>
            {
                { "张三", 20 },
                { "李四", 21 },
                { "王五", 22 }
            };
            //遍历
            foreach (var v in sl)
            {
                Result += $"{v.Key}\t{v.Value}\n";
            }
        }
    }
}
