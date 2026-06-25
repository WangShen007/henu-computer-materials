namespace ServerConsoleExamples.ch07.Common
{
    internal abstract class GameTable
    {
        /// <summary>无棋子</summary>
        protected const int None = -1;

        /// <summary>黑色棋子</summary>
        protected const int Black = 0;

        /// <summary>白色棋子</summary>
        protected const int White = 1;

        /// <summary>保存同一桌的两个玩家信息</summary>
        public Player[] Player { get; set; } = new Player[2];

        /// <summary>15*15的方格</summary>
        protected readonly int[,] grid = new int[15, 15];

        /// <summary>下一步应该产生的棋子颜色（0：黑色，1：白色）</summary>
        public int NextDotColor { get; set; } = 0;

        public System.Timers.Timer Timer1 { get; set; } = new(1200);

        public GameTable()
        {
            Player[0] = new Player();
            Player[1] = new Player();
            ResetGrid();
        }

        /// <summary>重置棋盘</summary>
        public void ResetGrid()
        {
            for (int i = 0; i <= grid.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= grid.GetUpperBound(1); j++)
                {
                    grid[i, j] = None;
                }
            }
        }

        /// <summary>发送产生的棋子信息（i：行号，j：列号，dotColor：棋子颜色）</summary>
        public abstract void SetDot(int i, int j, int dotColor);


        public void ShowWin(int color)
        {
            Player[0].Started = false;
            Player[1].Started = false;
            Timer1.Stop();
            ResetGrid();
            //发送格式：Win,胜方棋子颜色
            Service.SendToBoth(this, $"Win,{color}");
        }


        /// <summary>消去棋子的信息(i：行号,j：列号)</summary>
        public void UnsetDot(int i, int j)
        {
            //向两个用户发送消去棋子的信息（格式：UnsetDot,行,列）
            grid[i, j] = None;
            string str = $"UnsetDot,{i},{j}";
            Service.SendToBoth(this, str);
        }
    }
}
