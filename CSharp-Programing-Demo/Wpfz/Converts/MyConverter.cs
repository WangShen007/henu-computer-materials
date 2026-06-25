using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Wpfz
{
    /// <summary>
    /// 常用转换器的静态引用
    /// 使用示例：Converter={x:Static local:MyConverter.TrueToFalseConverter}
    /// </summary>
    public sealed class MyConverter
    {
        public static BooleanToVisibilityConverter BooleanToVisibility { get; } = new BooleanToVisibilityConverter();
        public static TrueToFalseConverter TrueToFalse { get; } = new TrueToFalseConverter();
        public static ThicknessToDoubleConverter ThicknessToDouble { get; } = new ThicknessToDoubleConverter();
        public static BackgroundToForegroundConverter BackgroundToForeground { get; } = new BackgroundToForegroundConverter();
        public static TreeViewMarginConverter TreeViewMargin { get; } = new TreeViewMarginConverter();
        public static PercentToAngleConverter PercentToAngle { get; } = new PercentToAngleConverter();
        public static UriSourceToBitmapImageConverter UriSourceToBitmapImage { get; } = new UriSourceToBitmapImageConverter();
    }
}
