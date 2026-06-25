using System.Windows;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch07.OtherDemos.LinqToObjects
{
    public partial class DemoPage : Page
    {
        public DemoPage()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Demos d = new Demos();
            string s = (e.Source as Button).Tag.ToString();
            switch (s)
            {
                case "1": textBlockResult.Text = d.Demo1_from(); break;
                case "2": textBlockResult.Text = d.Demo2_select(); break;
                case "3": textBlockResult.Text = d.Demo3_where(); break;
                case "4": textBlockResult.Text = d.Demo4_orderby(); break;
                case "5": textBlockResult.Text = d.Demo5_group(); break;
            }
        }
    }
}

