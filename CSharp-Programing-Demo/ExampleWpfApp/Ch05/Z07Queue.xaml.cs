using System.Collections.Generic;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch05
{
    public partial class Z07Queue : Page
    {
        public Z07Queue()
        {
            InitializeComponent();
            var v = new QueueDemo();
            uc.Result.Text = v.Result;
        }
    }
    public class QueueDemo
    {
        public string Result { get; set; } = "";
        public QueueDemo()
        {
            Queue<string> myQueue = new Queue<string>();
            //添加对象到队列结尾
            myQueue.Enqueue("one");
            myQueue.Enqueue("two");
            myQueue.Enqueue("three");

            //移除队列开始处的对象
            myQueue.Dequeue();

            //输出队列中的所有元素
            foreach (var v in myQueue)
            {
                Result += $"{v}\n";
            }
        }
    }
}
