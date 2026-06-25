using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace FuLuAWpfApp
{
    public partial class FuLuAMainWindow : Window
    {
        public FuLuAMainWindow()
        {
            InitializeComponent();
        }

        private Button lastButton;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lastButton != null)
            {
                lastButton.Foreground = Brushes.Blue;
            }
            Button btn = e.Source as Button;
            string content = btn.Content.ToString();
            switch (content)
            {
                case "个人信息": frame1.Source = new Uri("PersonPage.xaml", UriKind.Relative); return;
                case "全部展开": SetExpanded(true); return;
                case "全部折叠": SetExpanded(false); return;
            }
            btn.Foreground = Brushes.Red;
            Uri uri = new Uri(btn.Tag.ToString(), UriKind.Relative);
            object obj = null;
            try
            {
                obj = Application.LoadComponent(uri);
            }
            catch
            {
                MessageBox.Show("未找到 " + uri.OriginalString, "出错了");
                return;
            }
            frame1.Source = uri;
            if (lastButton == btn)
            {
                frame1.Refresh();
            }
            lastButton = btn;
        }
        private void SetExpanded(bool isExpanded)
        {
            foreach (var v in stackPanel1.Children)
            {
                if (v is Expander expander)
                {
                    expander.IsExpanded = isExpanded;
                }
            }
        }
    }
}
