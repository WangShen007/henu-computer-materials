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
    public partial class Z02_Demo6 : Page
    {
        public Z02_Demo6()
        {
            InitializeComponent();
            Init();
        }
        private BitmapFrame bitmapFrame;
        private void Init()
        {
            //解码
            string filePath = "Resources/ContentImages/m1.jpg";
            var decoder = BitmapDecoder.Create(File.OpenRead(filePath), BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            bitmapFrame = decoder.Frames[0];
            bitmapFrame.Freeze();
            image1.Source = bitmapFrame.Clone();

            //旋转90度
            var rotate = new RotateTransform(90);
            var rotatedBitMap = new TransformedBitmap(bitmapFrame, rotate);
            bitmapFrame = BitmapFrame.Create(rotatedBitMap);
            bitmapFrame.Freeze();
            image2.Source = bitmapFrame.Clone();

            //裁剪
            CroppedBitmap chainedBitMap = new CroppedBitmap(bitmapFrame, new Int32Rect(0, 0, (int)bitmapFrame.Width, (int)bitmapFrame.Height / 2));
            bitmapFrame = BitmapFrame.Create(chainedBitMap);
            bitmapFrame.Freeze();
            image3.Source = bitmapFrame.Clone();

            //缩放
            var scare = new ScaleTransform(1.5, 2);
            var scaredBitMap = new TransformedBitmap(bitmapFrame, scare);
            bitmapFrame = BitmapFrame.Create(scaredBitMap);
            bitmapFrame.Freeze();
            image4.Source = bitmapFrame.Clone();

            //编码
            var encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapFrame));

            //显示
            image5.Source = encoder.Frames[0];

            //保存
            encoder.Save(new FileStream("New_m1.jpg", FileMode.Create, FileAccess.Write, FileShare.Write));
        }
    }
}
