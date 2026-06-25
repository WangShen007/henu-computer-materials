namespace Wpfz.Ch03
{
    public class C07Array4
    {
        public string PrintArray(string[][] a)
        {
            string s = "";
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    s += $"{a[i][j]}\t";
                }
                s += "\n";
            }
            return s;
        }
    }
}
