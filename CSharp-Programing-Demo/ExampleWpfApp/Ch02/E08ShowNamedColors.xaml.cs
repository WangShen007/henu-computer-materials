using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
namespace ExampleWpfApp.Ch02
{
    public partial class E08ShowNamedColors : Page
    {
        public E08ShowNamedColors()
        {
            InitializeComponent();
            IEnumerable<PropertyInfo> properties = typeof(Colors).GetTypeInfo().DeclaredProperties;
            foreach (PropertyInfo property in properties)
            {
                Color color = (Color)property.GetValue(null);
                var uc = new MyUserControl(property.Name, color);
                wrappanel1.Children.Add(uc);
            }
        }
    }
    public class MyUserControl : UserControl
    {
        /*
         * <UserControl ......>
         * <Border BorderBrush="Black" BorderThickness="1" Width="160" Margin="6">
         *      <StackPanel Orientation="Horizontal">
         *          <Rectangle Name="rectangle" Width="36" Height="36" Margin="6" />
         *          <StackPanel VerticalAlignment="Center">
         *              <TextBlock Name="textBlockName" FontSize="12" />
         *              <TextBlock Name="textBlockRgb" FontSize="12" />
         *          </StackPanel>
         *      </StackPanel>
         * </Border>
         * </UserControl>
         */
        public MyUserControl(string name, Color color)
        {
            var rectangle = new Rectangle
            {
                Width = 36,
                Height = 36,
                Margin = new Thickness(6),
                Fill = new SolidColorBrush(color),
            };
            var textBlockName = new TextBlock
            {
                FontSize = 10,
                Text = name
            };
            var textBlockRgb = new TextBlock
            {
                FontSize = 10,
                Text = string.Format("ARGB：{0:X2}-{1:X2}-{2:X2}-{3:X2}",
                       color.A, color.R, color.G, color.B)
            };
            var stackPanel2 = new StackPanel { VerticalAlignment = VerticalAlignment.Center };
            stackPanel2.Children.Add(textBlockName);
            stackPanel2.Children.Add(textBlockRgb);
            var stackPanel1 = new StackPanel { Orientation = Orientation.Horizontal };
            stackPanel1.Children.Add(rectangle);
            stackPanel1.Children.Add(stackPanel2);
            var border = new Border
            {
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1),
                Width = 160,
                Margin = new Thickness(6)
            };
            border.Child = stackPanel1;
            this.Content = border;
        }
    }
}
