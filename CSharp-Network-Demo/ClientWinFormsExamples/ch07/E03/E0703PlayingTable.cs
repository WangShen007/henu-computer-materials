using System.Net.Sockets;
using System.Text;
using System.Media;
using ClientWinFormsExamples.ch07.Common;

namespace ClientWinFormsExamples.ch07.E03
{
    public partial class E0703PlayingTable : Form
    {
        public enum DotColor
        {
            None = -1,  //无棋子
            Black = 0,  //黑色棋子
            White = 1   //白色棋子
        }
        #region 字段
        //棋盘，15*15的方格，用于消点时进行判断
        private DotColor[,] grid = new DotColor[15, 15];
        /// <summary>用户所在的桌号，-1表示在游戏室</summary>
        private int tableIndex = -1;
        /// <summary>用户在游戏桌的状态（-1：未入座，0：黑方，1：白方）</summary>
        private int side = -1;

        /// <summary>保存服务器传送过来的开出房间数（每房间一个游戏桌）</summary>
        private int maxPlayingTables = 0;
        private CheckBox[,] checkBoxGameTables = new CheckBox[20, 2];

        /// <summary>是否为从服务器接收的命令</summary>
        private bool isReceiveCommand = false;
        //是否正常退出接收线程
        private bool normalExit = false;
        //该谁落子（0：黑方，1：白方）
        private int downIndex = 0;
        private readonly Bitmap blackBitmap = Resource1.black;
        private readonly Bitmap whiteBitmap = Resource1.white;
        private string userName = string.Empty;
        private TcpClient? client;
        private StreamWriter? sw;
        private StreamReader? sr;

        private readonly string localIPv4Address;

        private readonly SoundPlayer chessSound = new(Resource1.sound);
        private readonly SoundPlayer music = new(Resource1.music);
        #endregion

        public E0703PlayingTable(string userName)
        {
            InitializeComponent();

            textBoxUserName.Text = userName;
            localIPv4Address = E07Service.GetIpV4AddressString();
            textBoxServerIP.Text = localIPv4Address;

            ResetGrid();
            this.panelPlaying.Visible = false;
            labelGo.Text = "";
            this.buttonStart.Click += (s, e) =>
            {
                //格式：Start，桌号，座位号
                SendToServer($"Start,{tableIndex},{side}");
                this.buttonStart.Enabled = false;
            };
            this.buttonSend.Click += (s, e) =>
            {
                //格式：Talk,桌号,发言内容
                SendToServer($"Talk,{tableIndex},{textBoxSend.Text}");
            };
            this.buttonLogin.Click += ButtonLogin_Click;
            this.pictureBox1.Paint += PictureBox1_Paint;
            this.pictureBox1.MouseDown += PictureBox1_MouseDown;
            this.FormClosing += PlayingTable_FormClosing;
            this.checkBoxMusic.Click += (s, e) =>
            {
                if (checkBoxMusic.Checked == true)
                {
                    music.PlayLooping();
                }
                else
                {
                    music.Stop();
                }
            };
        }

        private void ButtonLogin_Click(object? sender, EventArgs e)
        {
            if (textBoxUserName.Text.Trim().Length == 0)
            {
                MessageBox.Show("用户名不能为空。", "警告");
                return;
            }
            this.userName = textBoxUserName.Text.Trim();
            ConnectToServerAsync();
        }

        private async void ConnectToServerAsync()
        {
            if (localIPv4Address == null)
            {
                return;
            }
            client = new();
            //try
            //{
            //    //client.Connect(localIPv4Address, 51888);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "与服务器连接失败");
            //    return;
            //}
            await Task.Run(() =>
            {
                try
                {
                    client.Connect(localIPv4Address, 51888);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "与服务器连接失败");
                    return;
                }
            });

            buttonLogin.Enabled = false;
            NetworkStream netStream = client.GetStream();
            sr = new StreamReader(netStream, Encoding.UTF8);
            sw = new StreamWriter(netStream, Encoding.UTF8);

            //登录服务器，获取服务器各桌信息。格式：Login,用户名
            SendToServer($"Login,{userName}");

            //ThreadStart threadStart = new(ReceiveData);
            //Thread threadReceive = new(threadStart)
            //{
            //    IsBackground = true
            //};
            //threadReceive.Start();
            await Task.Run(() => ReceiveDataAsync());
        }

        private async Task ReceiveDataAsync()
        {
            bool exitWhile = false;
            while (exitWhile == false)
            {
                string? receiveStr = null;
                //try
                //{
                //    receiveStr = MyReader?.ReadLine();
                //}
                //catch (Exception ex)
                //{
                //    AddItemToListBox($"接收数据失败：{ex.Message}");
                //}
                await Task.Run(() =>
                {
                    try
                    {
                        receiveStr = sr?.ReadLine();
                    }
                    catch
                    {
                        exitWhile = true;
                    }
                });
                if (exitWhile)
                {
                    break;
                }
                else if (receiveStr == null)
                {
                    if (normalExit == false)
                    {
                        MessageBox.Show("与服务器失去联系，游戏无法继续！");
                    }
                    exitWhile = true;
                    break;
                }

                //----------此句仅用于观察接收的信息，需要观察时可以去掉注释----------//
                //AddItemToListBox("收到：" + receiveStr);
                //--------------------------------------------------------------------//

                string[] splitString = receiveStr.Split(',');
                string command = splitString[0].ToLower();
                switch (command)
                {
                    case "login":  //该用户进入游戏室(格式：Login,用户名)
                        AddItemToListBox($"[{splitString[1]}]进入游戏室。");
                        break;
                    case "logout":  //用户退出游戏室(格式：Logout,用户名)
                        if (splitString[1] == userName)
                        {
                            exitWhile = true;
                        }
                        else
                        {
                            AddItemToListBox("[{splitString[1]}]退出游戏室。");
                        }
                        break;
                    case "sorry":
                        MessageBox.Show("游戏室人员已满，请等会再进入。");
                        exitWhile = true;
                        break;
                    case "tables":
                        //字符串格式：Tables,各桌是否有人的字符串
                        //其中每位表示一个座位，1表示有人，0表示无人
                        string s = splitString[1];
                        //如果maxPlayingTables为0，说明尚未创建checkBoxGameTables
                        if (maxPlayingTables == 0)
                        {
                            //计算所开桌数
                            maxPlayingTables = s.Length / 2;
                            checkBoxGameTables = new CheckBox[maxPlayingTables, 2];
                            isReceiveCommand = true;
                            //将CheckBox对象添加到数组中，以便管理
                            for (int i = 0; i < maxPlayingTables; i++)
                            {
                                AddCheckBoxToPanel(s, i);
                            }
                            isReceiveCommand = false;
                        }
                        else
                        {
                            isReceiveCommand = true;
                            for (int i = 0; i < maxPlayingTables; i++)
                            {
                                for (int j = 0; j < 2; j++)
                                {
                                    if (s[2 * i + j] == '0')
                                    {
                                        UpdateCheckBox(checkBoxGameTables[i, j], false);
                                    }
                                    else
                                    {
                                        UpdateCheckBox(checkBoxGameTables[i, j], true);
                                    }
                                }
                            }
                            isReceiveCommand = false;
                        }
                        break;
                    case "sitdown":  //格式：SitDown,桌号,座位号,用户名
                        var tableIndexStr = splitString[1];
                        var sideStr = splitString[2];
                        var userNameStr = splitString[3];
                        SetTableSideText(tableIndexStr, sideStr, userNameStr);
                        SetPanelPlayingVisible(true);
                        break;
                    case "getup":   //自己或者对方离座（格式：GetUp,座位号,用户名）

                        if (side == int.Parse(splitString[1]))
                        {
                            side = -1;   //自己离座
                        }
                        else  //对方离座
                        {
                            SetTableSideText(splitString[1], splitString[2], splitString[3]);
                            Restart("敌人逃跑了，我方胜利了");
                        }
                        break;
                    case "lost":  //对家与服务器失去联系(格式：Lost,座位号,用户名)
                        SetTableSideText(tableIndex.ToString(), splitString[1], splitString[2]);
                        Restart("对家与服务器失去联系，游戏无法继续");
                        break;
                    case "start":
                        //格式：Start
                        goto case "nextchess";
                    case "restart":
                        //格式：Restart
                        Restart("");
                        goto case "nextchess";
                    case "nextchess":
                        //格式：NextChess,颜色
                        if (splitString[1] == "0")
                        {
                            SetLabelGo("现在该黑方放棋子", 0);
                        }
                        else
                        {
                            SetLabelGo("现在该白方放棋子", 1);
                        }
                        break;
                    case "setdot":
                        // 放置的棋子位置信息(格式：SetDot,行,列,颜色)
                        SetDot(
                            int.Parse(splitString[1]),
                            int.Parse(splitString[2]),
                            (DotColor)int.Parse(splitString[3]));
                        break;
                    case "win":
                        //格式：Win,胜方棋子的颜色(0：黑色，1：白色)
                        string winner;
                        if (int.Parse(splitString[1]) == 0)
                            winner = "黑方胜利！";
                        else
                            winner = "白方胜利！";
                        AddItemToListBox(winner);
                        MessageBox.Show(winner, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Restart(winner);
                        break;
                    case "talk":
                        //格式：Talk,说话者,对话内容
                        ShowTalk(splitString[1],
                            receiveStr.Remove(0, splitString[0].Length + splitString[1].Length));
                        break;
                }
            }
        }

        private void PlayingTable_FormClosing(object? sender, FormClosingEventArgs e)
        {
            //服务器停止服务时,normalExited为true，其他情况为false
            if (normalExit == false)
            {
                music.Stop();
                normalExit = true;
                //通知服务器，用户从游戏室退出
                SendToServer("Logout");
            }
            //非正常退出时，通过关闭TcpClient对象，使服务器接收字符串为null
            //服务器结束接收线程后,本程序的接收线程接收字符串也为null
            //从而实现退出程序功能
            sr?.Close();
            sw?.Close();
            client?.Close();
        }

        private void PictureBox1_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i <= grid.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= grid.GetUpperBound(1); j++)
                {
                    if (grid[i, j] != DotColor.None)
                    {
                        if (grid[i, j] == DotColor.Black)
                        {
                            g.DrawImage(blackBitmap, (i + 1) * 20, (j + 1) * 20);
                        }
                        else
                        {
                            g.DrawImage(whiteBitmap, (i + 1) * 20, (j + 1) * 20);
                        }
                    }
                }
            }
        }

        private void PictureBox1_MouseDown(object? sender, MouseEventArgs e)
        {
            int x = e.X / 20;
            int y = e.Y / 20;
            if (!(x < 1 || x > 15 || y < 1 || y > 15))
            {
                if (grid[x - 1, y - 1] == DotColor.None && downIndex == side)
                {
                    //int color = (int)grid[x - 1, y - 1];
                    //发送格式：SetChess,桌号,座位号,行,列
                    SendToServer($"SetChess,{tableIndex},{side},{x - 1},{y - 1}");
                    if (checkBoxSound.Checked)
                    {
                        chessSound.Play();
                    }
                }
            }
        }

        /// <summary>添加一个游戏桌（s：表示各桌是否有人的字符串，i：桌号）</summary>
        private void AddCheckBoxToPanel(string s, int i)
        {
            if (panelTables.InvokeRequired)
            {
                panelTables.Invoke(AddCheckBoxToPanel, s, i);
            }
            else
            {
                Label label = new()
                {
                    Location = new Point(10, 15 + i * 30),
                    Text = $"第{i + 1}桌：",
                    Width = 70
                };
                this.panelTables.Controls.Add(label);
                CreateCheckBox(i, 0, s, "黑方");
                CreateCheckBox(i, 1, s, "白方");
            }
        }
        private void SetPanelPlayingVisible(bool isVisible)
        {
            if (panelPlaying.InvokeRequired)
            {
                panelPlaying.Invoke(SetPanelPlayingVisible, isVisible);
            }
            else
            {
                panelPlaying.Visible = isVisible;
            }
        }

        /// <summary>修改各桌入座状态</summary>
        private void UpdateCheckBox(CheckBox checkbox, bool isChecked)
        {
            if (checkbox.InvokeRequired)
            {
                checkbox.Invoke(UpdateCheckBox, checkbox, isChecked);
            }
            else
            {
                if (side == -1)
                {
                    checkbox.Enabled = !isChecked;
                }
                else
                {
                    //已经坐到某游戏桌上，不允许再选其他桌
                    checkbox.Enabled = false;
                }
                //注意改变Checked属性会触发checked_Changed事件
                checkbox.Checked = isChecked;
            }
        }

        /// <summary>添加游戏桌座位选项（i：桌号，j：座位号，s：各桌是否有人的字符串，text：说明信息）</summary>
        private void CreateCheckBox(int i, int j, string s, string text)
        {
            int x = j == 0 ? 100 : 200;
            checkBoxGameTables[i, j] = new CheckBox
            {
                Name = $"checkBox{i:00}{j:00}",
                Width = 60,
                Location = new Point(x, 10 + i * 30),
                Text = text,
                TextAlign = ContentAlignment.MiddleLeft
            };
            if (s[2 * i + j] == '1')  //1表示有人
            {
                checkBoxGameTables[i, j].Enabled = false;
                checkBoxGameTables[i, j].Checked = true;
            }
            else  //0表示无人
            {
                checkBoxGameTables[i, j].Enabled = true;
                checkBoxGameTables[i, j].Checked = false;
            }
            this.panelTables.Controls.Add(checkBoxGameTables[i, j]);
            //添加CheckedChanged事件
            checkBoxGameTables[i, j].CheckedChanged += (sender, e) =>
            {
                //是否为接收的来自服务器的更新各桌信息
                if (isReceiveCommand == true)
                {
                    return;
                }
                CheckBox? checkbox = sender as CheckBox;
                //Checked为true表示玩家坐到第i桌第j位上
                if (checkbox?.Checked == true)
                {
                    int i = int.Parse(checkbox.Name.Substring(8, 2));
                    int j = int.Parse(checkbox.Name.Substring(10, 2));
                    tableIndex = i;
                    side = j;
                    //字符串格式：SitDown,桌号,座位号
                    SendToServer($"SitDown,{i},{j}");
                }
            };
        }
        /// <summary>设置玩家入座信息</summary>
        public void SetTableSideText(string tableIndexStr, string sideStr, string userNameStr)
        {
            int n = int.Parse(tableIndexStr) + 1;
            SetLabel(labelTableIndex, $"桌号：{n}");
            var messageStr = "";
            if (sideStr == "0")
            {
                SetLabel(labelBlackSide, $"黑方：{userNameStr}");
                messageStr = $"{userNameStr}在第{n}桌黑方入座";
            }
            else if (sideStr == "1")
            {
                SetLabel(labelWhiteSide, $"白方：{userNameStr}");
                messageStr = $"{userNameStr}在第{n}桌白方入座";
            }
            AddItemToListBox(messageStr);
        }

        /// <summary>设置Label控件显示的文本信息</summary>
        private void SetLabel(Label label, string str)
        {
            if (label.InvokeRequired)
            {
                label.Invoke(SetLabel, label, str);
            }
            else
            {
                label.Text = str;
            }
        }

        /// <summary>设置应该谁落子的提示信息</summary>
        public void SetLabelGo(string str, int downIndex)
        {
            SetLabel(labelGo, str);
            this.downIndex = downIndex;
        }

        /// <summary>设置button是否可用</summary>
        private void SetButton(Button button, bool isEnable)
        {
            if (button.InvokeRequired)
            {
                button.Invoke(SetButton, button, isEnable);
            }
            else
            {
                button.Enabled = isEnable;
            }
        }

        /// <summary>设置棋子状态（i：行号，j：列号，dotColor：棋子颜色）</summary>
        public void SetDot(int i, int j, DotColor dotColor)
        {
            grid[i, j] = dotColor;
            pictureBox1.Invalidate();
        }

        public void Restart(string str)
        {
            ResetGrid();
            pictureBox1.Invalidate();
            SetButton(buttonStart, true);
        }

        /// <summary>重置棋盘</summary>
        private void ResetGrid()
        {
            for (int i = 0; i <= grid.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= grid.GetUpperBound(1); j++)
                {
                    grid[i, j] = DotColor.None;
                }
            }
        }

        /// <summary>显示发言信息（talkMan：发言人，str：发言信息）</summary>
        public void ShowTalk(string talkMan, string str)
        {
            AddItemToListBox($"{talkMan}说：{str}");
        }

        #region 向服务器发送信息

        /// <summary>向服务器发送数据</summary>
        public void SendToServer(string str)
        {
            if (sw == null) return;
            try
            {
                sw.WriteLine(str);
                sw.Flush();
            }
            catch (Exception ex)
            {
                AddItemToListBox($"发送数据失败：{ex.Message}");
            }
        }

        /// <summary>向listbox中追加str<</summary>
        public void AddItemToListBox(string str)
        {
            if (listBox1.InvokeRequired)
            {
                try
                {
                    listBox1.Invoke(AddItemToListBox, str);
                }
                catch
                {
                    //do nothing
                }
            }
            else
            {
                listBox1.Items.Add(str);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                listBox1.ClearSelected();
            }
        }
        #endregion

    }
}
