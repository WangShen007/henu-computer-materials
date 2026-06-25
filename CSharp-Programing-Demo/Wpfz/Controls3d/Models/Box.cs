using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
namespace Wpfz
{
    public class Box : ModelsBase
    {
        /// <summary>
        /// 创建立方体模型
        /// </summary>
        protected override MeshGeometry3D CreateMeshGeometry3D()
        {
            return this.MeshGeometryBulider("Box.xaml");
        }
    }
}