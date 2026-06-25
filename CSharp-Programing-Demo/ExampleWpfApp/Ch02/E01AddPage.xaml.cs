using System.Windows.Controls;
namespace ExampleWpfApp.Ch02
{
    public partial class E01AddPage : Page
    {
        public E01AddPage()
        {
            InitializeComponent();
            Loaded += delegate
            {
                App.ExecConsoleApp("ExampleConsoleApp.Ch02.E01Add");
            };
        }
    }
}
