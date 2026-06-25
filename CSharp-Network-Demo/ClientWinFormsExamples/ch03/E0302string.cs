namespace ClientWinFormsExamples.ch03
{
    public partial class E0302string : Form
    {
        public E0302string()
        {
            InitializeComponent();

            this.Text = "例3-2 字符串基本用法";
            string s = "123abc123abc中国ing";
            char[] c = { 'a', 'b', '5', '8' };
            string r = "";
            r += $"字符串s为：{s}\n";
            r += $"字符数组c为：'a', 'b', '5', '8'\n\n";
            r += $"s中是否包含abc：{s.Contains("abc")}\n";
            r += $"s是否以abc开头：{s.StartsWith("abc")}，s是否以ing结尾：{s.EndsWith("ing")}\n";
            r += $"s中字符串c1出现的位置：{s.IndexOf("c1")}，数组c中包含的字符在s中首次出现的位置：{s.IndexOfAny(c)}\n";
            r += $"s中从第三个位置开始的子字符串：{s.Substring(2)}\n";
            r += $"s中从第三个位置开始的3个子字符串：{s.Substring(2, 3)}\n";
            r += $"在s的第三个位置处插入“中国”的结果：{s.Insert(2, "中国")}\n";
            r += $"移除s从第14个位置开始的字符串后的的结果：{s.Remove(13)}\n";
            r += $"s转换为大写：{s.ToUpper()}";
            label1.Text = r;
        }
    }
}
