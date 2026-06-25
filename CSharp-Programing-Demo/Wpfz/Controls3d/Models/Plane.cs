using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
namespace Wpfz
{
    public class Plane : ModelsBase
    {
        /// <summary>
        /// 创建平面模型
        /// </summary>
        protected override MeshGeometry3D CreateMeshGeometry3D()
        {
            return this.MeshGeometryBulider("Plane.xaml");
        }
    }
}