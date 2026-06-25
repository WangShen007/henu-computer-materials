using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
namespace ExampleWpfApp.Ch04
{
    public partial class E09WpfEvent : Page
    {
        public E09WpfEvent()
        {
            InitializeComponent();

            Uri[] uri = {
                new Uri("/Resources/Images/apple.jpg", UriKind.Relative),
                new Uri("/Resources/Images/bananas.jpg", UriKind.Relative),
            };
            img.MouseEnter += (s, e) =>
            {
                img.Source = new BitmapImage(uri[1]);
            };
            img.MouseLeave += (s, e) =>
            {
                img.Source = new BitmapImage(uri[0]);
            };
        }
    }
}
