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

namespace ExampleWpfApp
{
    /// <summary>
    /// DefaultPage.xaml 的交互逻辑
    /// </summary>
    public partial class DefaultPage : Page
    {
        public DefaultPage()
        {
            InitializeComponent();

            //var v = gradientBrush.GradientStops.Clone();
            //for (int i = 1; i < v.Count; i++)
            //{
            //    v[i].Offset += 1.0;
            //    gradientBrush.GradientStops.Add(v[i]);
            //}
            //CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        //void CompositionTarget_Rendering(object sender, EventArgs e)
        //{
        //    RenderingEventArgs args = e as RenderingEventArgs;

        //    //求余数后得到的只有小数部分
        //    double t = (0.25 * args.RenderingTime.TotalSeconds) % 1;

        //    for (int i = 0; i < gradientBrush.GradientStops.Count; i++)
        //    {
        //        gradientBrush.GradientStops[i].Offset = i / 7.0 - t;
        //    }
        //}
    }
}
