using System.Linq;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch07.LinqToEntities
{
    public partial class E02SqlQuery : Page
    {
        public E02SqlQuery()
        {
            InitializeComponent();
            btn1.Click += delegate
            {
                using (var c = new MyDb1Entities())
                {
                    if (r1.IsChecked == true)
                    {
                        var v = c.Database.SqlQuery<Student>("select * from student");
                        dataGrid1.ItemsSource = v.ToList();
                    }
                    if (r2.IsChecked == true)
                    {
                        var v = c.Database.SqlQuery<Student>("select * from student where XingMing like {0}", "张%");
                        dataGrid1.ItemsSource = v.ToList();
                    }
                    if (r3.IsChecked == true)
                    {
                        var v = c.Database.SqlQuery<Student>("select * from student where XingBie = {0}", "男");
                        dataGrid1.ItemsSource = v.ToList();
                    }
                }
            };
        }
    }
}
