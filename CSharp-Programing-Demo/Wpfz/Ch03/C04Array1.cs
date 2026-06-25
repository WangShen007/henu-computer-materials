using System.Linq;
using System.Text;
namespace Wpfz.Ch03
{
    public class C04Array1
    {
        public string ArrayDemo1(int[] a)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("初始值：{0}", string.Join(",", a)));
            sb.AppendLine(string.Format("平均值：{0}", a.Average()));
            sb.AppendLine(string.Format("和：{0}", a.Sum()));
            sb.AppendLine(string.Format("最大值：{0}", a.Max()));
            sb.AppendLine(string.Format("最小值：{0}", a.Min()));
            return sb.ToString();
        }
    }
}
