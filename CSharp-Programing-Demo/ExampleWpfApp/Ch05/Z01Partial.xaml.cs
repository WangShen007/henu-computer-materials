using System.Windows.Controls;
namespace ExampleWpfApp.Ch05
{
    public partial class Z01Ppartial : Page
    {
        public Z01Ppartial()
        {
            InitializeComponent();
            Loaded += delegate
            {
                ZE01_Student student = new ZE01_Student();
                student.Append1();
                student.Append2();
                uc.Result.Text = student.GetResult();
            };
        }
    }
}
