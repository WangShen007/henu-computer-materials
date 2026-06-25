namespace Wpfz.Ch03
{
    public class C13while
    {
        public string GetResult()
        {
            int x = 1;
            string s = "";
            while (x <= 20)
            {
                if (x % 3 == 0) s += x.ToString() + " ";
                x++;
            }
            return s;
        }
    }
}
