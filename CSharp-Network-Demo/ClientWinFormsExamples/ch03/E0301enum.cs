namespace ClientWinFormsExamples.ch03
{
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
    public partial class E0301enum : Form
    {
        public E0301enum()
        {
            InitializeComponent();

            this.Text = "例3-1 枚举基本用法";
            MyColor myColor = MyColor.Black;
            //获取枚举值
            var s = $"{myColor.ToString()}\n";
            //获取枚举类型中定义的所有符号名称
            string[] colorNames = System.Enum.GetNames(typeof(MyColor));
            label1.Text = $"{string.Join(",", colorNames)}";
        }
    }
}
