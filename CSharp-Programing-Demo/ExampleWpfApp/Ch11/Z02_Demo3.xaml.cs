using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExampleWpfApp.Ch11
{
    public partial class Z02_Demo3 : Page
    {
        public Z02_Demo3()
        {
            InitializeComponent();
            Loaded += delegate
            {
                image1.Source = CreateBitmapImage();
            };
        }
        private BitmapImage CreateBitmapImage()
        {
            BitmapImage bi = new BitmapImage();
            // 注意BitmapImage.UriSource必须在BeginInit/EndInit块内
            bi.BeginInit();
            bi.UriSource = new Uri("/Resources/Images/img1.jpg", UriKind.Relative);
            bi.EndInit();
            return bi;
        }
    }
}
