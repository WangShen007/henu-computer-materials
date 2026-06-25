using System;
namespace Wpfz.Ch03
{
    public class C15try_catch
    {
        public string GetResult( string n1, string n2)
        {
            string s = "";
            try
            {
                double x = double.Parse(n1);
                double y = double.Parse(n2);
                s =string.Format("{0}", Divide(x, y));
                return s;
            }
            catch (Exception err)
            {
                s = $"出错了：{err.Message}";
                return s;
            }
            finally
            {
                s += "\n再见";
            }
        }
        private double Divide(double x, double y)
        {
            if (y == 0) throw new Exception("除数不能为零！");
            return Math.Round(x / y, 2, MidpointRounding.AwayFromZero);
        }
    }
}
