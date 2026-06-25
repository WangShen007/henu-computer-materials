using System;
namespace Wpfz.Ch03
{
    public class C08TypeConvert
    {
        public string Result { get; set; } = string.Empty;
        public C08TypeConvert()
        {
            Result += "值类型之间的转换：\n";
            int i1 = 12345;
            long r1 = 123456789012L;
            Result += $"i1={i1}, r1={r1}\n";
            long r2 = i1;         //隐式转换
            int i2 = (int)r1;     //显式转换
            try
            {
                int i3 = Convert.ToInt32(r1); //利用Convert类实现转换
                Result += $"i3={i3}\n";
            }
            catch (Exception ex)
            {
                Result += ex.Message+"\n";
            }
            Result += "\n";

            Result += "引用类型之间的转换：\n";
            Class1 c1 = new Class1();
            Class2 c2 = new Class2();
            c1 = c2;              //隐式转换
            Result += $"c1是Class1吗:{((c1 is Class1) ? "是" : "否")}\n";
            Result += $"c1的类型是{c1.GetType()}\n";
            var c3 = (Class1)c2;  //显式转换
            Result += $"c3的类型是{c3.GetType()}\n";
            var c4 = c2 as Class1;
            var c5 = c1 as Class2;
            Result += $"c4={c4},c5={c5}\n";


            Result += "Parse、TryParse方法：\n";
            string s1 = "12"; int n1 = int.Parse(s1);
            Result += $"s1={s1}，n1={n1}\t";
            string s2 = "12.3"; double n2 = double.Parse(s2);
            Result += $"s2={s2}，n2={n2}\n\n";
            if (int.TryParse(s1, out int n3)) Result += $"n3={n3}\t";
            if (double.TryParse(s1, out double n4)) Result += $"n4={n4}\n\n";

            Result += "Jion、Split方法：\n";
            int[] a = { 11, 12, 13 };
            string str1 = string.Join(",", a);
            Result += $"a=[{str1}]\t";
            string s = "21,22,23";
            string[] b = s.Split(',');
            Result += $"b=[{s}]\n\n";

            Result += "char与int之间的转换：\n";
            char ch1 = 'A';
            int x1 = ch1;  //隐式转换
            Result += $"ch1={ch1}\tx1={x1}\n";
            int x2 = 49;
            char ch2 = (char)x2;  //显式转换
            Result += $"x2={x2}\tch2={ch2}\n\n";
        }
    }
    public class Class1 { }
    public class Class2 : Class1 { }
}
