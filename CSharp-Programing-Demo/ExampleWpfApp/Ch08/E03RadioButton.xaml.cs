using System.Windows;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch08
{
    public partial class E03RadioButton : Page
    {
        public E03RadioButton()
        {
            InitializeComponent();
        }
        string s1, s2;
        private void Group1_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton r = e.Source as RadioButton;
            if (r.IsChecked == true) s1 = r.Content.ToString();
            ShowResult();
        }
        private void Group2_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton r = e.Source as RadioButton;
            s2 = r.Content.ToString();
            ShowResult();
        }
        private void ShowResult()
        {
            resultTextBlock.Text = $"选择的结果：{s1}：{s2}";
        }
    }
}
