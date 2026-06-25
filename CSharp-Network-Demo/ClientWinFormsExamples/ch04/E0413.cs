namespace ClientWinFormsExamples.ch04
{
    public partial class E0413 : Form
    {
        public E0413()
        {
            InitializeComponent();
            var v1 = new ListDemo();
            label1.Text = v1.Result;
            var v2 = new SortedListDemo();
            label2.Text = v2.Result;
        }
    }
    public class ListDemo
    {
        public string Result { get; set; } = "";
        public ListDemo()
        {
            //初始化
            List<string> list = new() { "张三", "李四", "王五" };
            //插入
            list.Insert(0, "赵六");
            //添加（避免重复）
            if (list.Contains("胡七") == false)
            {
                list.Add("胡七");
            }
            //遍历
            for (int i = 0; i < list.Count; i++)
            {
                Result += $"list[{i}]={list[i]}\n";
            }
        }
    }
    public class SortedListDemo
    {
        public string Result { get; set; } = "";
        public SortedListDemo()
        {
            //初始化
            SortedList<string, int> sl = new()
            {
                { "张三", 20 },
                { "李四", 21 },
                { "王五", 22 },
                { "赵六", 23 },
                { "胡七", 24 },
            };
            //遍历
            foreach (var v in sl)
            {
                Result += $"{v.Key}  {v.Value}\n";
            }
        }
    }
}
