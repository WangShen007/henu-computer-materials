using System.Diagnostics;

namespace Readtxt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string txt = File.ReadAllText("1.txt");
            string[] ans = new string[3];
            int temp = 0;
            for(int i = 0;i < txt.Length; i++)
            {
                if (txt[i] == '\n' || txt[i] == '(' || txt[i] == ')')
                {
                    temp++;
                }
                else
                {
                    if (temp <= 2)
                    {
                        ans[temp] += txt[i];
                    }
                    else
                        break;
                }
            }
            Console.WriteLine(ans[1]+ans[2]);
        }
    }
}
