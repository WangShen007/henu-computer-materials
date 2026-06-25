namespace Wpfz.Ch03
{
    public class C11for
    {
        public string GetResult()
        {
            string s = "";
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    s += string.Format("{0}×{1}={2,2}{3,3}", j, i, i * j, ' ');
                }
                s += "\n";
            }
            return s;
        }
    }
}
