using System.Linq;
namespace Wpfz.Ch03
{
    public class C01
    {
        const double pi = 3.14;  //常量
        readonly int n = 15;     //变量
        public string Result { get; set; } = string.Empty;
        public C01()
        {
            var v = new { ID = "0001 ", Name = "张三" };
            Result += $"pi={pi}，n={n}，学号：{v.ID}，姓名：{v.Name}\n";
            int[] scores = { 97, 92, 81, 60 };

            //方式1-用LINQ实现
            var q = from t in scores where t > 80 select t;
            //方式2-用Lambda表达式实现
            //var q = scores.Where((score) => score > 80);

            Result += $"成绩大于80的有{q.Count()}个";
        }
    }
}
