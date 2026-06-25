namespace ClientWinFormsExamples.ch04
{
    public partial class E0406Event : Form
    {
        public E0406Event()
        {
            InitializeComponent();
            var d = new EventDemo();
            label1.Text = d.Result;
        }
    }
    public class EventDemo
    {
        private int count;
        MyItem m = new MyItem();
        public string? Result { get; set; }
        public EventDemo()
        {
            m.Handler += ItemChanged; //注册事件
            for (int i = 0; i < 5; i++)
            {
                m.OnItemChanged();    //引发事件【Handler!=null,执行ItemChanged】
            }
            m.Handler -= ItemChanged; //取消事件
        }

        //事件处理程序
        void ItemChanged()
        {
            count++;
            Result += $"{count}  ";
        }
        private class MyItem
        {
            public delegate void MyHandlerDelegate();
            public event MyHandlerDelegate? Handler;
            public void OnItemChanged()
            {
                Handler?.Invoke();
            }
        }
    }
}
