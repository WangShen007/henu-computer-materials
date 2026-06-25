using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class Z02_Demo2 : Page
    {
        public Z02_Demo2()
        {
            InitializeComponent();
            Loaded += delegate
            {
                image1.Source = CreateTifImageFile();
            };
        }
        private BitmapSource CreateTifImageFile()
        {
            int width = 200;
            int height = width;
            int stride = width / 8;
            byte[] pixels = new byte[height * stride];
            Random value = new Random();
            value.NextBytes(pixels);
            List<System.Windows.Media.Color> colors = new List<System.Windows.Media.Color>
            {
                System.Windows.Media.Colors.Red,
                System.Windows.Media.Colors.Blue,
                System.Windows.Media.Colors.Green
            };
            BitmapPalette myPalette = new BitmapPalette(colors);
            BitmapSource image = BitmapSource.Create(width, height,
                96,  //DpiX
                96,  //DpiY
                PixelFormats.Indexed1, myPalette, pixels, stride);
            using (FileStream stream = new FileStream("empty.tif", FileMode.Create))
            {
                TiffBitmapEncoder encoder = new TiffBitmapEncoder();
                textBlock1.Text += "\r\n编码器：" + encoder.CodecInfo.FriendlyName;
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(stream);
            }
            return image;
        }
    }
}
