using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace ExampleWpfApp.Ch11
{
    public partial class E07TextToGeometry : Page
    {
        public E07TextToGeometry()
        {
            InitializeComponent();
            path1.Data = BuildMyGeometry("隶书空心字", "隶书", 80);
            path1.Stroke = Brushes.Green;
            path2.Data = BuildMyGeometry("楷体纯色填充", "楷体", 80);
            path2.Stroke = Brushes.Black;
            path2.Fill = Brushes.Yellow;
            path3.Data = BuildMyGeometry("宋体渐变填充", "宋体", 80);
            path3.Stroke = Brushes.Blue;
            path3.Fill = this.FindResource("RGBrushKey") as Brush;
        }
        // 创建指定字体和大小的格式化字符串图形
        private Geometry BuildMyGeometry(string text, string fontName, double fontSize)
        {
            Typeface typeface = new Typeface(
                new FontFamily(fontName),
                FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);
            FormattedText ft = new FormattedText(text,
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                typeface, fontSize, Brushes.Black);
            Geometry g = ft.BuildGeometry(new Point(0, 0));
            return g;
        }
    }
}
