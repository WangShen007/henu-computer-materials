using System;
namespace Wpfz.Ch03
{
    public class C05Array2
    {
        /// <summary>对整型数组排序并返回结果</summary>
        public string ArrayDemo2(int[] a)
        {
            int[] b = new int[a.Length];
            //将数组a的值全部复制到数组b中
            Array.Copy(a, b, a.Length);
            var s = $"原始整数数组：{string.Join(",", a)}\n";
            //反转数组a的值，结果仍保存到a中
            Array.Reverse(a);
            s += $"反转后的值：{string.Join(",", a)}\n";
            //将数组b升序排序，排序结果仍保存到b中
            Array.Sort(b);
            s += $"升序排序后的值：{string.Join(",", b)}\n";
            //反转排序后的值，得到降序结果仍保存到b中
            Array.Reverse(b);
            s += $"降序排序后的值：{string.Join(",", b)}\n";
            return s;
        }
        /// <summary>对字符串数组排序</summary>
        public string ArrayDemo2(string[] a)
        {
            var s = $"原始数组：{string.Join(",", a)}\n";
            Array.Sort(a);
            s += $"升序排序后的值：{string.Join(",", a)}\n";
            return s;
        }
    }
}
