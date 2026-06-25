using System.Windows;
using System.Windows.Controls;

namespace ExampleWpfApp.Ch08
{
    public partial class E04CheckBox : Page
    {
        public E04CheckBox()
        {
            InitializeComponent();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            string s = "已选择：";
            int checkedCount = 0;
            foreach (var v in wp1.Children)
            {
                CheckBox cb = v as CheckBox;
                if (cb.IsChecked == true)
                {
                    s += cb.Content.ToString() + "、";
                    checkedCount++;
                }
            }
            result.Content = s.TrimEnd('、');
            if (checkedCount == 3) checkBox1.IsChecked = true;
            else if (checkedCount == 0) checkBox1.IsChecked = false;
            else checkBox1.IsChecked = null;
        }
    }
}
