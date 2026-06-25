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
    public partial class Z02_Demo1 : Page
    {
        public Z02_Demo1()
        {
            InitializeComponent();
            Loaded += delegate
            {
                image1.Source = CreateBitmapSource();
            };
        }
        private BitmapSource CreateBitmapSource()
        {
            // 定义BitmapSource使用的参数
            PixelFormat pf = PixelFormats.Bgr32;
            int width = 200;
            int height = 200;
            int rawStride = (width * pf.BitsPerPixel + 7) / 8;
            byte[] rawImage = new byte[rawStride * height];
            // 初始化图象数据
            Random value = new Random();
            value.NextBytes(rawImage);
            // 创建BitmapSource
            BitmapSource bitmap = BitmapSource.Create(width, height,
                96, 96, pf, null, rawImage, rawStride);
            return bitmap;
        }
    }
}
