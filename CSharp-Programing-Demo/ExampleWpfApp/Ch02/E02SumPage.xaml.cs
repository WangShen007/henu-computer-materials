using System.Windows.Controls;
namespace ExampleWpfApp.Ch02
{
    public partial class E02SumPage : Page
    {
        public E02SumPage()
        {
            InitializeComponent();
            Loaded += delegate
            {
                App.ExecConsoleApp("ExampleConsoleApp.Ch02.E02Sum");
            };
        }
    }
}
