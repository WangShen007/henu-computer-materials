using System.Diagnostics;
using System.Runtime.Serialization;

namespace ClientWinFormsExamples.ch07.E05
{
    public enum UserState
    {
    };

    //封装绘图共用的属性和方法（CommonClass）
    internal class MyCC
    {
        /// <summary>绘图画板</summary>
        public static MyUC UC1 { get; set; } = new();

        /// <summary>绘制对象的唯一标识</summary>
        public static int ID { get; private set; } = 1;

        /// <summary>用于判断焦点的形状（是否为句柄）</summary>
        public static bool IsToolPoint { get; set; }

        public static void SetNewID()
        {
            ID++;
        }

        /// <summary>找对应对象的id,如果找不到，返回-1，否则返回该对象的序号</summary>
        public static int FindObjectIndex(int ID)
        {
            int index = -1;
            for (int i = 0; i < UC1.Graphics.Count; i++)
            {
                if (UC1.Graphics[i]!.ID == ID)  //【!】表示不对其进行null检查
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        /// <summary>将矩形框变为从左上角到右下角</summary>
        public static Rectangle GetNormalizedRectangle(int x1, int y1, int x2, int y2)
        {
            if (x2 < x1)
            {
                //下面的交换x1和x2是用元组来实现的，它相当于：int tmp = x2; x2 = x1; x1 = tmp;
                (x1, x2) = (x2, x1);
            }

            if (y2 < y1)
            {
                (y1, y2) = (y2, y1);
            }
            return new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }

        /// <summary>将矩形框变为从左上角到右下角</summary>
        public static Rectangle GetNormalizedRectangle(Point p1, Point p2)
        {
            return GetNormalizedRectangle(p1.X, p1.Y, p2.X, p2.Y);
        }
    }
}
