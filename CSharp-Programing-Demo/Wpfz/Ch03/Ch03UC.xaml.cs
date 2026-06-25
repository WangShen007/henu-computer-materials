using System.Windows;
using System.Windows.Controls;
namespace Wpfz.Ch03
{
    public partial class Ch03UC : UserControl
    {
        public string Title { get => tip.Text; set => tip.Text = value; }
        public Ch03UC()
        {
            InitializeComponent();
            Border1.Visibility = Visibility.Collapsed;
            BtnWpf.Click += delegate
            {
                if (Border1.Visibility == Visibility.Collapsed)
                {
                    Border1.Visibility = Visibility.Visible;
                }
                else
                {
                    Border1.Visibility = Visibility.Collapsed;
                }
            };
        }
    }
}
