using ServerConsoleExamples.ch07.Common;

namespace ServerConsoleExamples.ch07.E03
{
    internal class E0703PlayingTable : GameTable
    {
        public E0703PlayingTable()
        {

        }

        /// <summary>放置棋子</summary>
        public override void SetDot(int i, int j, int color)
        {
            //发送格式：SetDot,行,列,颜色
            grid[i, j] = color;
            NextDotColor = NextDotColor == 0 ? 1 : 0;
            Service.SendToBoth(this, $"SetDot,{i},{j},{color}");
            if (IsWin(i, j))
            {
                ShowWin(color);
            }
            else
            {
                Service.SendToBoth(this, "NextChess," + NextDotColor);
            }
        }

        /// <summary>获取棋子落下后是否获胜</summary>
        public bool IsWin(int i, int j)
        {
            //与方格的第i,j交叉点向四个方向的连子数，依次是水平，垂直，左上右下，左下右上
            int[] numbers = new int[4];
            numbers[0] = GetRowNumber(i, j);
            numbers[1] = GetColumnNumber(i, j);
            numbers[2] = GetBacklashNumber(i, j);
            numbers[3] = GetSlashNumber(i, j);
            //检查是否获胜
            for (int k = 0; k < numbers.Length; k++)
            {
                if (Math.Abs(numbers[k]) == 5)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>判断并返回横向相同颜色的棋子个数</summary>
        private int GetRowNumber(int i, int j)
        {
            int num = 1;    //连子个数
            int x = i + 1;  //向右检查
            while (x < 15)
            {
                //前方棋子与i,j点不同时跳出循环
                if (grid[x, j] == grid[i, j])
                {
                    num++;
                    x++;
                }
                else
                    break;
            }
            x = i - 1;  //向左检查
            while (x >= 0)
            {
                //前方棋子与i,j点不同时跳出循环
                if (grid[x, j] == grid[i, j])
                {
                    num++;
                    x--;
                }
                else
                    break;
            }
            return num;
        }

        /// <summary>判断并返回纵向相同颜色的棋子个数</summary>
        private int GetColumnNumber(int i, int j)
        {
            int num = 1;    //连子个数
            int y = j + 1;  //向下检查
            while (y < 15)
            {
                //前方的棋子与i,j点不同时跳出循环
                if (grid[i, y] == grid[i, j])
                {
                    num++;
                    y++;
                }
                else
                    break;
            }
            y = j - 1;  //向上检查
            while (y >= 0)
            {
                //前方的棋子与i,j点不同时跳出循环
                if (grid[i, y] == grid[i, j])
                {
                    num++;
                    y--;
                }
                else
                    break;
            }
            return num;
        }

        /// <summary>判断并返回左上到右下相同颜色的棋子个数</summary>
        private int GetBacklashNumber(int i, int j)
        {
            int num = 1;    //连子个数
            int x = i + 1;  //右下方向
            int y = j + 1;
            while (x < 15 && y < 15)
            {
                //前方的棋子与i,j点不同时跳出循环
                if (grid[x, y] == grid[i, j])
                {
                    num++;
                    x++;
                    y++;
                }
                else
                    break;
            }
            //左上方向(x-,y-)
            x = i - 1;
            y = j - 1;
            //不超出棋格
            while (x >= 0 && y >= 0)
            {
                //前方的棋子与i,j点不同时跳出循环
                if (grid[x, y] == grid[i, j])
                {
                    num++;
                    x--;
                    y--;
                }
                else
                    break;
            }
            return num;
        }

        /// <summary>判断并返回左下到右上相同颜色的棋子个数</summary>
        private int GetSlashNumber(int i, int j)
        {
            int num = 1;
            int x = i - 1;
            int y = j + 1;
            while (x >= 0 && y < 15)
            {
                if (grid[x, y] == grid[i, j])
                {
                    num++;
                    x--;
                    y++;
                }
                else
                    break;
            }
            x = i + 1;
            y = j - 1;
            while (x < 15 && y >= 0)
            {
                if (grid[x, y] == grid[i, j])
                {
                    num++;
                    x++;
                    y--;
                }
                else
                    break;
            }
            return num;
        }
    }
}
