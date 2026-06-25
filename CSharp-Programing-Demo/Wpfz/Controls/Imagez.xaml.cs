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

namespace Wpfz
{
    /// <summary>
    /// Imagez.xaml 的交互逻辑
    /// </summary>
    public partial class Imagez : UserControl
    {
        public Imagez()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 资源设置，支持Iconz图标，例如：&#xe64e;
        /// </summary>
        public string Source
        {
            get { return (string)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(
            "Source", typeof(string), typeof(Imagez), new PropertyMetadata(OnSourcePropertyChanged));
        /// <summary>属性更改处理事件</summary>
        private static void OnSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            if (!(sender is Imagez myimg)) return;
            if (!myimg.IsLoaded) return;
            BindSource(myimg);
        }

        public TextBlock Iconz { get { return this.textBlockIconz; } }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            this.Loaded += delegate { BindSource(this); };
        }


        private static void BindSource(Imagez sourceImg)
        {
            sourceImg.Iconz.Text = sourceImg.Source;
        }
    }
}
