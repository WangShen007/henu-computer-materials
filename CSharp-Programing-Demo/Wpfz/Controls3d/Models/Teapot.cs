using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
namespace Wpfz
{
    public class Teapot : ModelsBase
    {
        /// <summary>
        /// 创建茶壶模型
        /// </summary>
        protected override MeshGeometry3D CreateMeshGeometry3D()
        {
            return this.MeshGeometryBulider("Teapot.xaml");
        }
    }
}