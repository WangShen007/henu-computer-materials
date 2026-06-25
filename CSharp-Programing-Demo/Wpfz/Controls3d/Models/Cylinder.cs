using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
namespace Wpfz
{
    public class Cylinder : ModelsBase
    {
        /// <summary>
        /// 创建圆柱模型
        /// </summary>
        protected override MeshGeometry3D CreateMeshGeometry3D()
        {
            return this.MeshGeometryBulider("Cylinder.xaml");
        }
    }
}