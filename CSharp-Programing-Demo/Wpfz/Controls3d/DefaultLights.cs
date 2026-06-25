using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
namespace Wpfz
{
    public class DefaultLights : ModelVisual3D
    {
        private readonly Model3DGroup lightGroup = new Model3DGroup();
        private readonly ModelVisual3D lightsVisual = new ModelVisual3D();
        public DefaultLights()
        {
            this.Content = this.lightGroup;
            this.Children.Add(this.lightsVisual);
            this.OnSetupChanged();
        }
        protected static void SetupChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DefaultLights)d).OnSetupChanged();
        }
        protected void OnSetupChanged()
        {
            this.lightGroup.Children.Clear();

            // 外部直射光（主光源）
            this.lightGroup.Children.Add(new DirectionalLight(Colors.LightGray, new Vector3D(-1, -1, -1)));

            // 内部直射光（填充-从右向左，偏离0.1）
            this.lightGroup.Children.Add(new DirectionalLight(Colors.Gray, new Vector3D(1, -0.1, -1)));

            // 背面直射光（弱光-从原点向左上）
            this.lightGroup.Children.Add(new DirectionalLight(Colors.DarkGray, new Vector3D(0.1, -1, 1)));

            // 底部直射光（弱光--从下向上）
            this.lightGroup.Children.Add(new DirectionalLight(Color.FromRgb(0x32, 0x32, 0x32), new Vector3D(0.1, 1, 0.1)));

            this.lightGroup.Children.Add(new AmbientLight(Color.FromRgb(30, 30, 30)));
        }
    }
}