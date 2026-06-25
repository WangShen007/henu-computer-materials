using System;
using System.Windows;
using System.Windows.Controls;
using Wpfz;
namespace ExampleWpfApp.Ch08
{
    public partial class E08ButtonButtonz : Page
    {
        public E08ButtonButtonz()
        {
            InitializeComponent();
            ShowButtonz();
        }
        private void ShowButtonz()
        {
            string[] s = Enum.GetNames(typeof(IconzEnum));
            txtTite.Text = $"Iconz图标及编码（共{s.Length}个）";
            for (int i = 0; i < s.Length; i++)
            {
                string s1 = s[i].Substring(0, 4);
                string s2 = s[i];
                int c = int.Parse(s1, System.Globalization.NumberStyles.AllowHexSpecifier);
                Buttonz btn = new Buttonz()
                {
                    Iconz = $"{(char)c}",
                    IconzSize = 20,
                    Content = s2,
                    Width = 200,
                    Padding = new Thickness(5, 0, 0, 0),
                    HorizontalContentAlignment = HorizontalAlignment.Left,
                    Margin = new Thickness(2, 2, 2, 2)
                };
                WrapPanel1.Children.Add(btn);
            }
        }
    }
}
