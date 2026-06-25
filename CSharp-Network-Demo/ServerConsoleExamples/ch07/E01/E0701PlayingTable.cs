using ServerConsoleExamples.ch07.Common;

namespace ServerConsoleExamples.ch07.E01
{
    internal class E0701PlayingTable :GameTable
    {
        private readonly Random rnd = new();
        public E0701PlayingTable()
        {
            Timer1.Elapsed += Timer_Elapsed;
            Timer1.Enabled = false;
        }
        /// <summary>发送产生的棋子信息（i：行号，j：列号，dotColor：棋子颜色）</summary>
        public override void SetDot(int i, int j, int dotColor)
        {
            //向两个用户发送产生的棋子信息，并判断是否有相邻棋子
            //发送格式：SetDot,行,列,颜色
            grid[i, j] = dotColor;
            Service.SendToBoth(this, $"SetDot,{i},{j},{dotColor}");

            /*----------以下判断当前行是否有相邻点----------*/
            int k1, k2;   //k1:循环初值，k2:循环终值
            if (i == 0)
            {
                //如果是首行，只需要判断下边的点
                k1 = k2 = 1;
            }
            else if (i == grid.GetUpperBound(0))
            {
                //如果是最后一行，只需要判断上边的点
                k1 = k2 = grid.GetUpperBound(0) - 1;
            }
            else
            {
                //如果是中间的行，上下两边的点都要判断
                k1 = i - 1; k2 = i + 1;
            }
            for (int x = k1; x <= k2; x += 2)
            {
                if (grid[x, j] == dotColor)
                {
                    ShowWin(dotColor);
                }
            }
            /*-------------以下判断当前列是否有相邻点------------------*/
            if (j == 0)
            {
                k1 = k2 = 1;
            }
            else if (j == grid.GetUpperBound(1))
            {
                k1 = k2 = grid.GetUpperBound(1) - 1;
            }
            else
            {
                k1 = j - 1; k2 = j + 1;
            }
            for (int y = k1; y <= k2; y += 2)
            {
                if (grid[i, y] == dotColor)
                {
                    ShowWin(dotColor);
                }
            }
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            int x, y;
            //随机产生一个格内没有棋子的单元格位置
            do
            {
                x = rnd.Next(15);  //产生一个小于15的非负整数
                y = rnd.Next(15);
            } while (grid[x, y] != None);
            //放置棋子:x坐标,y坐标,颜色
            SetDot(x, y, NextDotColor);
            //设定下次分发的旗子颜色
            NextDotColor = (NextDotColor + 1) % 2;
        }
    }
}
