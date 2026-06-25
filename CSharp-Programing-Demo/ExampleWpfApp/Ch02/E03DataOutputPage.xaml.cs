using System.Windows.Controls;
namespace ExampleWpfApp.Ch02
{
    public partial class E03DataOutputPage : Page
    {
        public E03DataOutputPage()
        {
            InitializeComponent();
            Loaded += delegate
            {
                App.ExecConsoleApp("ExampleConsoleApp.Ch02.E03DataOutput");
            };
        }
    }
}
