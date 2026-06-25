using System.Collections.Generic;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch05
{
    public partial class Z09LinkedList : Page
    {
        public Z09LinkedList()
        {
            InitializeComponent();
            var v = new LinkedListDemo();
            uc.Result.Text = v.Result;
        }
    }
    public class LinkedListDemo
    {
        public string Result { get; set; } = "";
        public LinkedListDemo()
        {
            string[] words = { "a", "b", "c" };
            LinkedList<string> sentence = new LinkedList<string>(words);
            sentence.AddFirst("dog"); //结果为"dog","a","b","c"，
            LinkedListNode<string> mark1 = sentence.First;  //结果为"dog"
            sentence.RemoveFirst(); 	//结果为"a","b","c"
            sentence.AddLast(mark1);  	//"a","b","c","dog"
            LinkedListNode<string> current = sentence.Find("b");
            sentence.AddAfter(current, "lazy"); //结果为"a","b","lazy","c","dog"
            var m = sentence.First;
            while (m != null)
            {
                Result += $"{m.Value}\t";
                m = m.Next;
            }
        }
    }
}
