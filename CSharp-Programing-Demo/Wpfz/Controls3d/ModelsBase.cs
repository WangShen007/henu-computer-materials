using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace Wpfz
{
    public abstract class ModelsBase : ModelVisual3D, INotifyPropertyChanged 
    {
        public ModelsBase()
        {
            this.Content = new GeometryModel3D();
            this.Model.Geometry = this.CreateMeshGeometry3D();
            
            this.PropertyChanged += MeshGeometryBase_PropertyChanged;

            this.Material = CreateMaterial(Brushes.Blue);
            this.BackMaterial = CreateMaterial(Brushes.LightBlue);
        }

        /// <summary>
        /// 创建漫反射材料和高光反射材料
        /// </summary>
        private Material CreateMaterial(Brush brush)
        {
            var mg = new MaterialGroup();
            mg.Children.Add(new DiffuseMaterial(brush));
            double specularPower = 100;
            mg.Children.Add(new SpecularMaterial(Brushes.White, specularPower));
            return mg;
        }


        void MeshGeometryBase_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
             this.OnTransformChanged();
        }

        /// <summary>获取或设置模型的背面材料</summary>
        public Material BackMaterial
        {
            get { return this.Model.BackMaterial; }
            set { this.Model.BackMaterial = value; }
        }

        /// <summary>获取或设置模型的正面材料</summary>
        public Material Material
        {
            get { return this.Model.Material; }
            set { this.Model.Material = value; }
        }

        protected virtual void OnMaterialChanged()
        {
            this.Model.Material = this.Material;
            this.Model.BackMaterial = this.BackMaterial;
        }


        private bool visible = true;
        /// <summary>
        /// 获取或设置该元素是否可见（默认true）
        /// </summary>
        public bool Visible
        {
            get { return visible; }
            set { visible = value; NotifyPropertyChanged("Visible"); }
        }

        /// <summary>获取模型</summary>
        public GeometryModel3D Model
        {
            get { return this.Content as GeometryModel3D; }
        }

        /// <summary>
        /// 构造由三维网格构成的曲面几何图形（MeshGeometry3D），扩充类必须重写该方法
        /// </summary>
        protected abstract MeshGeometry3D CreateMeshGeometry3D();

        #region INotifyPropertyChanged（必须实现的接口）
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
        #endregion

        private Transform3DGroup g = new Transform3DGroup();
        private void OnTransformChanged()
        {
            //平移
            Vector3D offset = new Vector3D(this.Position.X, this.Position.Y, this.Position.Z);
            TranslateTransform3D translateTransform3D = new TranslateTransform3D(offset);
            g.Children.Clear();
            //缩放
            ScaleTransform3D scaleTransform3D = new ScaleTransform3D(Scale,Position);
            //旋转
            AxisAngleRotation3D axisAngleRotation3D = new AxisAngleRotation3D(RotateAxis, RotateAngle);
            RotateTransform3D = new RotateTransform3D(axisAngleRotation3D,Position);

            switch (Transform3dMode)
            {
                case Transform3DTransMode.RotateBySelf: //绕自身旋转
                    g.Children.Add(translateTransform3D);
                    g.Children.Add(scaleTransform3D);
                    g.Children.Add(RotateTransform3D);
                    break;
                case Transform3DTransMode.RotateAroundCenter: //绕指定的中心点旋转
                    g.Children.Add(translateTransform3D);
                    scaleTransform3D.CenterX = 0;
                    scaleTransform3D.CenterY = 0;
                    scaleTransform3D.CenterZ = 0;
                    g.Children.Add(scaleTransform3D);
                    RotateTransform3D.CenterX = RotateCenter.X;
                    RotateTransform3D.CenterY = RotateCenter.Y;
                    RotateTransform3D.CenterZ = RotateCenter.Z;
                    g.Children.Add(RotateTransform3D);
                    break;
            }
            this.Transform = g;
        }

        protected MeshGeometry3D MeshGeometryBulider(string xamlFileName)
        {
            ResourceDictionary d = new ResourceDictionary()
            {
                Source = new Uri("/Wpfz;component/Controls3d/Models/" + xamlFileName, UriKind.Relative)
            };
            MeshGeometry3D mesh = d[System.IO.Path.GetFileNameWithoutExtension(xamlFileName)] as MeshGeometry3D;
            mesh.Freeze();
            return mesh;
        }


        public Transform3DGroup Transform3dGroup
        {
            get { return (Transform3DGroup)this.GetValue(Transform3dGroupProperty); }
            set { this.SetValue(Transform3dGroupProperty, value); }
        }
        public static DependencyProperty Transform3dGroupProperty = DependencyProperty.Register(
            "Transform3dGroup", typeof(Transform3DGroup), typeof(ModelsBase),
            new UIPropertyMetadata(new Transform3DGroup(), TransformChanged));

        protected static void TransformChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ModelsBase)d).OnTransformChanged();
        }

        public RotateTransform3D RotateTransform3D
        {
            get { return (RotateTransform3D)this.GetValue(rotateTransform3DProperty); }
            set { this.SetValue(rotateTransform3DProperty, value); }
        }
        public static DependencyProperty rotateTransform3DProperty = DependencyProperty.Register(
            "RotateTransform3D", typeof(RotateTransform3D), typeof(ModelsBase),
            new PropertyMetadata(null));

        /// <summary>平移到的顶点</summary>
        public Point3D Position
        {
            get { return (Point3D)this.GetValue(PositionProperty); }
            set { this.SetValue(PositionProperty, value); }
        }
        public static DependencyProperty PositionProperty = DependencyProperty.Register(
            "Position", typeof(Point3D), typeof(ModelsBase),
            new PropertyMetadata(new Point3D(0, 0, 0), TransformChanged));

        /// <summary>旋转坐标轴</summary>
        public Vector3D RotateAxis
        {
            get { return (Vector3D)this.GetValue(RotateAxisProperty); }
            set { this.SetValue(RotateAxisProperty, value); }
        }
        public static DependencyProperty RotateAxisProperty = DependencyProperty.Register(
            "RotateAxis", typeof(Vector3D), typeof(ModelsBase),
            new PropertyMetadata(new Vector3D(0, 1, 0), TransformChanged));

        /// <summary>旋转角度 </summary>
        public double RotateAngle
        {
            get { return (double)this.GetValue(RotateAngleProperty); }
            set { this.SetValue(RotateAngleProperty, value); }
        }
        public static DependencyProperty RotateAngleProperty = DependencyProperty.Register(
            "RotateAngle", typeof(double), typeof(ModelsBase),
            new PropertyMetadata(0.0, TransformChanged));

        /// <summary>旋转中心点</summary>
        public Point3D RotateCenter
        {
            get { return (Point3D)this.GetValue(RotateCenterProperty); }
            set { this.SetValue(RotateCenterProperty, value); }
        }
        public static DependencyProperty RotateCenterProperty = DependencyProperty.Register(
            "RotateCenter", typeof(Point3D), typeof(ModelsBase),
            new PropertyMetadata(new Point3D(0,0,0), TransformChanged));

        /// <summary>缩放向量</summary>
        public Vector3D Scale
        {
            get { return (Vector3D)this.GetValue(ScaleProperty); }
            set { this.SetValue(ScaleProperty, value); }
        }
        public static DependencyProperty ScaleProperty = DependencyProperty.Register(
            "Scale", typeof(Vector3D), typeof(ModelsBase),
            new PropertyMetadata(new Vector3D(1, 1, 1), TransformChanged));

        private Transform3DTransMode transform3dMode = Transform3DTransMode.RotateBySelf;
        public Transform3DTransMode Transform3dMode
        {
            get { return transform3dMode; }
            set { transform3dMode = value; NotifyPropertyChanged("Transform3dMode"); }
        }
    }

    /// <summary>
    /// 3D变换顺序模式
    /// </summary>
    public enum Transform3DTransMode
    {
        /// <summary>
        /// (默认)绕自身旋转
        /// </summary>
        RotateBySelf,

        /// <summary>
        /// 绕指定的中心点旋转
        /// </summary>
        RotateAroundCenter,
    }
}