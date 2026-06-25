using System.Linq;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch10
{
    public partial class E04DataContext : Page
    {
        public E04DataContext()
        {
            InitializeComponent();
            Loaded += (s, e) => {
                using (var c = new MyDb1Entities())
                {
                    var q = (from t in c.Student select t).ToList();
                    dataGrid1.ItemsSource = q;
                    dataGrid1.SelectedIndex = q.Count() > 0 ? 0 : -1;
                }
            };
        }
    }
}
