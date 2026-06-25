namespace Wpfz.Ch03
{
    public class C12foreach
    {
        public string BaseUsage()
        {
            string[] a = new string[10];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = string.Format("{0,2}", i + 1);
            }
            string s = "";
            foreach (var v in a)
            {
                s += v + " ";
            }
            return s;
        }
    }
}
