using System.Text;
namespace Wpfz.Ch03
{
    public class C03string
    {
        private StringBuilder sb = new StringBuilder();
        public C03string()
        {
            string s = "123abc123abc中国ing";
            char[] c = { 'a', 'b', '5', '8' };
            sb.AppendLine($"字符串s为：{s}");
            sb.AppendLine($"s中是否包含abc：{s.Contains("abc")}");
            sb.AppendLine($"{s.StartsWith("abc")}，{s.EndsWith("ing")}");
            sb.AppendLine($"{s.IndexOf("c1")}，{s.IndexOfAny(c)}");
            sb.AppendLine($"{s.Substring(2)}，{s.Substring(2, 3)}");
            sb.AppendLine(s.Insert(2, "中国"));
            sb.AppendLine(s.Remove(13));
            sb.AppendLine(s.ToUpper());
        }
        public string GetResult()
        {
            return sb.ToString();
        }
    }
}
