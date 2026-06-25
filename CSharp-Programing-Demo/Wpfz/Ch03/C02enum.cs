namespace Wpfz.Ch03
{
    public class C02enum
    {
        /// <summary>枚举用法示例</summary>
        /// <param name="myColor">MyColor枚举</param>
        /// <returns>用于输出结果的字符串</returns>
        public string GetResult(MyColor myColor)
        {
            //获取枚举值
            var s = $"{myColor.ToString()}\n";
            //获取枚举类型中定义的所有符号名称
            string[] colorNames = System.Enum.GetNames(typeof(MyColor));
            //获取所有枚举成员
            s += $"{string.Join(",", colorNames)}\n";
            return s;
        }
    }

    /// <summary>自定义颜色</summary>
    public enum MyColor
    {
        /// <summary>黑色</summary>
        Black,
        /// <summary>白色</summary>
        White,
        /// <summary>蓝色</summary>
        Blue
    };
}
