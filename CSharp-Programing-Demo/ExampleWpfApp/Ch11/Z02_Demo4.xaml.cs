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
    public partial class Z02_Demo4 : Page
    {
        public Z02_Demo4()
        {
            InitializeComponent();
            JpegDecode();
        }
        private void JpegDecode()
        {
            //相对于当前可执行文件的图像文件路径,注意Resources前不要加斜杠
            string filePath = "Resources/ContentImages/m1.jpg";
            //解码
            JpegBitmapDecoder decoder = new JpegBitmapDecoder(
                File.OpenRead(filePath),
                BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            BitmapFrame bf = decoder.Frames[0];
            //显示原始大小的图像
            image1.Source = bf;
            //获取原始图像信息
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("右侧是原始图像：");
            sb.AppendLine(string.Format("宽度：{0}，高度：{1}", bf.Width, bf.Height));
            sb.AppendLine(string.Format("宽度（像素数）：{0}", bf.PixelWidth));
            sb.AppendLine(string.Format("高度（像素数）：{0}", bf.PixelHeight));
            sb.AppendLine(string.Format("每像素位数：{0}", bf.Format.BitsPerPixel));
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("下面是该图的缩略图：");
            textBlock1.Text = sb.ToString();
        }
    }
}
