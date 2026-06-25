namespace Wpfz.Ch03
{
    public class C14do_while
    {
        const int n = 4;
        public string GetResult()
        {
            //求n的阶乘
            int x = n;
            double result = 1;
            do
            {
                result *= x--;  //即result=result*x;x=x-1;
            } while (x > 1);
            return string.Format("{0}的阶乘为：{1}", n, result);
        }
    }
}
