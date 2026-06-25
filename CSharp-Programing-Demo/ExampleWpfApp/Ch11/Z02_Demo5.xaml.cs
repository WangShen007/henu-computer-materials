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
    public partial class Z02_Demo5 : Page
    {
        public Z02_Demo5()
        {
            InitializeComponent();
        }

        void Btn_Click(object sender, RoutedEventArgs e)
        {
            string s = (e.Source as Button).Content.ToString();
            PixelFormat format = PixelFormats.Gray2;
            switch (s)
            {
                case "Gray2": format = PixelFormats.Gray2; break;
                case "Gray4": format = PixelFormats.Gray4; break;
                case "Gray8": format = PixelFormats.Gray8; break;
                case "Gray16": format = PixelFormats.Gray16; break;
                case "BlackWhite": format = PixelFormats.BlackWhite; break;
            }
            image2.Source = ConvertToGray(format);
        }

        private FormatConvertedBitmap ConvertToGray(PixelFormat format)
        {
            FormatConvertedBitmap fcb = new FormatConvertedBitmap();
            fcb.BeginInit();
            fcb.Source = (BitmapSource)image1.Source;
            fcb.DestinationFormat = format;
            fcb.EndInit();
            return fcb;
        }
    }
}
