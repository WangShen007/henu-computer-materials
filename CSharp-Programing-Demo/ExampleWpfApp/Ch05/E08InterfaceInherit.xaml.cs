using System;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch05
{
    public partial class E08InterfaceInherit : Page
    {
        public E08InterfaceInherit()
        {
            InitializeComponent();
            Loaded += delegate {
                string s = "";
                var v1 = new InterfaceInheritDemo(DrawType.矩形);
                s += v1.Result;
                var v2 = new InterfaceInheritDemo(DrawType.曲线);
                s += v2.Result;
                result.Text = s;
            };
        }
    }
    /// <summary>接口1</summary>
    interface IDrawDemo1
    {
        void DrawRectangle();
        void DrawEclipse();
    }
    /// <summary>接口2</summary>
    interface IDrawDemo2
    {
        void DrawSin();
        void DrawCos();
    }
    /// <summary>接口继承</summary>
    interface IDraw : IDrawDemo1, IDrawDemo2
    {
        void DrawCircle();
        void DrawCurve();
    }
    /// <summary>用单独的类实现接口，以方便复用</summary>
    public class InterfaceInheritDemo : IDraw
    {
        public string Result { get; set; }
        public InterfaceInheritDemo(DrawType drawType)
        {
            Result += $"绘图类型：{drawType}\n";
            switch (drawType)
            {
                case DrawType.矩形: DrawRectangle(); break;
                case DrawType.圆: DrawCircle(); break;
                case DrawType.椭圆: DrawEclipse(); break;
                case DrawType.曲线: DrawCurve(); break;
                case DrawType.正弦曲线: DrawSin(); break;
                case DrawType.余弦曲线: DrawCos(); break;
            }
        }
        #region 实现接口
        public void DrawRectangle() { Result += "绘制Rectangle\n"; }
        public void DrawEclipse() { Result += "绘制Eclipse\n"; }
        public void DrawSin() { Result += "绘制Sin\n"; }
        public void DrawCos() { Result += "绘制Cos\n"; }
        public void DrawCircle() { Result += "绘制Circle\n"; }
        public void DrawCurve() { Result += "绘制Curve\n"; }
        #endregion
    }
    /// <summary>用枚举声明IDraw接口提供的所有绘图类型</summary>
    public enum DrawType { 矩形, 圆, 椭圆, 曲线, 正弦曲线, 余弦曲线 }
}
