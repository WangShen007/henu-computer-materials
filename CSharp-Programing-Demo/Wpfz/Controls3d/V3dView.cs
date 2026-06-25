using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Media3D;
namespace Wpfz
{
    public class V3dView : ContentControl, INotifyPropertyChanged
    {
        private PerspectiveCamera pCamera;  //用于修改当前相机参数
        private PerspectiveCamera defaultCamera;//保存相机的初始状态
        private Viewport3D viewport;
        private Point lastPoint;

        /// <summary>
        /// 必须提供的静态构造函数，否则在Generic.xaml中定义的样式将不起作用
        /// </summary>
        static V3dView()
        {
            //该句是为了确保在Generic.xaml中定义的V3dView的样式能被正确引用
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(V3dView), new FrameworkPropertyMetadata(typeof(V3dView)));

            //该句是为了确保不指定背景色时鼠标操作是对V3dView操作，而不是对它所包含的Viewport3D对象操作
            BackgroundProperty.OverrideMetadata(
                typeof(V3dView),
                new FrameworkPropertyMetadata(System.Windows.Media.Brushes.Black));
        }

        public V3dView()
        {
           this.Loaded += V3dController_Loaded;
           this.Unloaded += V3dController_Unloaded;
        }

        void V3dController_Loaded(object sender, RoutedEventArgs e)
        {
            if (viewport != null)
            {
                if (viewport.Camera.IsFrozen)
                {
                    PerspectiveCamera c = viewport.Camera as PerspectiveCamera;
                    //下面的语句是为了将其IsFrozen改为false，否则缩放会出错
                    viewport.Camera = new PerspectiveCamera();
                    CameraHelper.Copy(c, (PerspectiveCamera)viewport.Camera);
                }
                if (this.defaultCamera == null)
                {
                    this.defaultCamera = viewport.Camera.Clone() as PerspectiveCamera;
                }
                pCamera = (PerspectiveCamera)viewport.Camera;
                this.UpdateCameraInfo();

                pCamera.Changed += pCamera_Changed;
                this.MouseWheel += V3dController_MouseWheel;
                this.MouseDoubleClick += V3dView_MouseDoubleClick;
                this.MouseMove += V3dController_MouseMove;
            }
        }

        void V3dView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Right)
            {
                CameraHelper.Copy(defaultCamera, (PerspectiveCamera)viewport.Camera);
                pCamera = (PerspectiveCamera)viewport.Camera;
            }
        }

        void pCamera_Changed(object sender, EventArgs e)
        {
            this.UpdateCameraInfo();
        }

        void V3dController_Unloaded(object sender, RoutedEventArgs e)
        {
            if (viewport != null)
            {
                pCamera.Changed -= pCamera_Changed;
                this.MouseWheel -= V3dController_MouseWheel;
                this.MouseMove -= V3dController_MouseMove;
            }
        }

        void V3dController_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            double zoomDelta = 1 - e.Delta * 0.001;
            this.pCamera.Position = new Point3D(
                pCamera.Position.X * zoomDelta,
                pCamera.Position.Y * zoomDelta,
                pCamera.Position.Z * zoomDelta);
            this.pCamera.LookDirection = this.pCamera.LookDirection * zoomDelta;
        }

        void V3dController_MouseMove(object sender, MouseEventArgs e)
        {
            Point currentPoint = e.GetPosition(this);
            if (e.RightButton == MouseButtonState.Pressed)
            {
                Vector delta = (currentPoint - this.lastPoint);
                if (delta.LengthSquared > 0.2) CameraHelper.RotateCamera(ref pCamera, delta);
            }
            this.lastPoint = currentPoint;
        }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);
            if (newContent == null)
            {
                return;
            }
            if (newContent.GetType() != typeof(Viewport3D))
            {
                throw new Exception("V3dView的子元素必须是Viewport3D");
            }
            viewport = (Viewport3D)newContent;
            viewport.ClipToBounds = true;
        }

        private bool showHelp = true;
        /// <summary>
        /// 是否显示鼠标操作帮助信息（默认true）
        /// </summary>
        public bool ShowHelp
        {
            get { return showHelp; }
            set { showHelp = value; NotifyPropertyChanged("ShowHelp"); }
        }

        private bool showCameraInfo = false;
        /// <summary>
        /// 是否显示相机信息（默认false）
        /// </summary>
        public bool ShowCameraInfo
        {
            get { return showCameraInfo; }
            set{ showCameraInfo = value; NotifyPropertyChanged("ShowCameraInfo"); }
        }

        private void UpdateCameraInfo()
        {
            if (ShowCameraInfo == true)
            {
                if (viewport != null)
                {
                    CameraInfo = CameraHelper.GetInfo((PerspectiveCamera)this.viewport.Camera);
                }
            }
            else
            {
                CameraInfo = string.Empty;
            }
        }

        private string cameraInfo;
        /// <summary>
        /// 样式模板绑定时要使用它
        /// </summary>
        public string CameraInfo
        {
            get { return cameraInfo; }
            set { cameraInfo = value; NotifyPropertyChanged("CameraInfo"); }
        }


        #region INotifyPropertyChanged（必须实现的接口）
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}
