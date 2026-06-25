using System.Drawing;
using System.Runtime.Serialization;

namespace ServerConsoleExamples.ch07.E06
{
    [DataContract(Namespace = "http://V4B2Server/ch07")]
    class DrawArrowCurve : DrawCurveHandle
    {
        public DrawArrowCurve(List<Point> myPointList, Color color, int penWidth, int id)
        {
            for (int i = 0; i < myPointList.Count; i++)
            {
                PointList.Add(myPointList[i]);
            }
            PenColor = color;
            PenWidth = penWidth;
            ID = id;
        }
    }
}
