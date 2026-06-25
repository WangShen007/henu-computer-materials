using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
namespace Wpfz
{
    public class Model1 : ModelsBase
    {
        /// <summary>
        /// 创建自定义模型1
        /// </summary>
        protected override MeshGeometry3D CreateMeshGeometry3D()
        {
            return this.MeshGeometryBulider("Model1.xaml");
        }
    }
}