using System.Windows.Controls;
using System.Windows.Media;
namespace ExampleWpfApp.Ch05
{
    public partial class E05abstract : Page
    {
        public E05abstract()
        {
            InitializeComponent();
            Loaded += delegate
            {
                E05A v = new E05B();
                v.Draw();
                uc.Result.Text = v.Result;
            };
        }
    }
    public abstract class E05A
    {
        public string Result { get; set; }
        protected Pen pen = new Pen(Brushes.Red, 1.0);
        public E05A()
        {
            Result = $"ARGB={pen.Brush}\n";
        }
        public abstract void Draw();
    }
    public class E05B : E05A
    {
        public override void Draw()
        {
            Result += "B.Draw";
        }
    }
}
