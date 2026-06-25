using System.Text;
using System.Windows;
using System.Windows.Media.Media3D;
namespace Wpfz
{
    /// <summary>
    /// 相机控制帮助器
    /// </summary>
    public static class CameraHelper
    {
        /// <summary>
        /// 复制源（source）远景相机的属性到目标（dest）透视相机，不改变dest的数据绑定和动画等其他属性
        /// </summary>
        public static void Copy(PerspectiveCamera source, PerspectiveCamera dest)
        {
            if (source == null || dest == null) return;
            dest.LookDirection = source.LookDirection;
            dest.Position = source.Position;
            dest.UpDirection = source.UpDirection;
            dest.NearPlaneDistance = source.NearPlaneDistance;
            dest.FarPlaneDistance = source.FarPlaneDistance;
            dest.FieldOfView = source.FieldOfView;
        }

        /// <summary>
        /// 初始化或复位透视相机
        /// </summary>
        public static void Reset(PerspectiveCamera camera)
        {
            if (camera == null)
            {
                return;
            }
            camera.Position = new Point3D(6, 6, 6);
            camera.LookDirection = new Vector3D(-6, -6, -6);
            camera.UpDirection = new Vector3D(0, 1, 0);
            camera.FieldOfView = 45;
            camera.NearPlaneDistance = 0.125;
            camera.FarPlaneDistance = 100000;
        }

        /// <summary>
        /// 创建具有默认参数的透视相机
        /// </summary>
        public static PerspectiveCamera CreateDefaultCamera()
        {
            var camera = new PerspectiveCamera();
            Reset(camera);
            return camera;
        }

        /// <summary>
        /// 绕原点旋转指定的相机
        /// </summary>
        public static void RotateCamera(ref PerspectiveCamera pCamera, Vector delta)
        {
            Vector3D up = pCamera.UpDirection; //模型的UpDirection应该设置为与该值相同
            Vector3D dir = pCamera.LookDirection;
            dir.Normalize();
            Vector3D right = Vector3D.CrossProduct(dir, pCamera.UpDirection);
            right.Normalize();
            double d = -0.5;
            var q1 = new Quaternion(up, d * delta.X);
            var q2 = new Quaternion(right, d * delta.Y);
            Quaternion q = q1 * q2;
            var m = new Matrix3D();
            m.Rotate(q);

            Point3D p = new Point3D(0, 0, 0);//绕原点旋转
            Vector3D relativeTarget = p - (pCamera.Position + pCamera.LookDirection);
            Vector3D relativePosition = p - pCamera.Position;
            Vector3D newRelativeTarget = m.Transform(relativeTarget);
            Vector3D newRelativePosition = m.Transform(relativePosition);
            Point3D newTarget = p - newRelativeTarget;
            Point3D newPosition = p - newRelativePosition;
            pCamera.LookDirection = newTarget - newPosition;
            pCamera.Position = newPosition;
            //Vector3D newUpDirection = m.Transform(pCamera.UpDirection);
            //pCamera.UpDirection = newUpDirection;
        }

        public static string GetInfo(Camera camera)
        {
            if (camera == null)
            {
                return string.Empty;
            }
            var pCamera = camera as PerspectiveCamera;
            var sb = new StringBuilder();
            sb.AppendLine("相机类型："+camera.GetType().Name);
            if (pCamera != null)
            {
                string s = "{0,5:f2}, {1,5:f2}, {2,5:f2}";
                sb.AppendLine(string.Format(
                    "Position:\t" + s,
                    pCamera.Position.X, pCamera.Position.Y, pCamera.Position.Z));
                sb.AppendLine(string.Format(
                    "LookDirection:\t" + s,
                    pCamera.LookDirection.X, pCamera.LookDirection.Y, pCamera.LookDirection.Z));
                sb.AppendLine(string.Format(
                    "UpDirection:\t" + s,
                    pCamera.UpDirection.X, pCamera.UpDirection.Y, pCamera.UpDirection.Z));
                var target = pCamera.Position + pCamera.LookDirection;
                sb.AppendLine(string.Format(
                    "Target:\t\t" + s,
                    target.X, target.Y, target.Z));
                sb.AppendLine(string.Format("NearPlaneDist:\t{0}", pCamera.NearPlaneDistance));
                sb.AppendLine(string.Format("FarPlaneDist:\t{0}", pCamera.FarPlaneDistance));
                sb.AppendLine(string.Format("FieldOfView:\t{0:0.#}°", pCamera.FieldOfView));
            }
            return sb.ToString();
        }

    }
}