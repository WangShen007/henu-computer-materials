using System.Net;
using System.Net.Sockets;
using System.Text;
using ClientWinFormsExamples.ch07.Common;

namespace ClientWinFormsExamples.ch07.E01
{
    public partial class E0701PlayingTable : Form
    {
        public enum DotColor
        {
            /// <summary>无棋子</summary>
            None = -1,
            /// <summary>黑色棋子</summary>
            Black = 0,
            /// <summary>白色棋子</summary>
            White = 1
        }
        #region 字段
        //棋盘，15*15的方格，用于消点时进行判断
        private readonly DotColor[,] grid = new DotColor[15, 15];
        /// <summary>用户所在的桌号，-1表示在游戏室</summary>
        private int tableIndex;
        //用户在房间内的状态（-1：未入座，0：黑方，1：白方）
        private int side = -1;
        /// <summary>保存服务器传送过来的游戏桌数</summary>
        private int maxPlayingTables = 0;
        private CheckBox[,] checkBoxGameTables = new CheckBox[20, 2];
        /// <summary>是否为从服务器接收的命令</summary>
        private bool isReceiveCommand = false;
        //是否正常退出接收线程
        private bool normalExit = false;
        private readonly Bitmap blackBitmap = Resource1.black;
        private readonly Bitmap whiteBitmap = Resource1.white;
        private string userName = string.Empty;
        private TcpClient? client;
        private StreamWriter? sw;
        private StreamReader? sr;
        private readonly string? localIPv4Address = null;
        #endregion

        public E0701PlayingTable(string userName)
        {
            InitializeComponent();
            textBoxUserName.Text = userName;
            localIPv4Address = E07Service.GetIpV4AddressString();
            if (localIPv4Address == null)
            {
                MessageBox.Show("获取IPv4失败");
                return;
            }
            textBoxServer.Text = localIPv4Address;
            //默认游戏级别为3级
            radioButton3.Checked = true;
            ResetGrid();
            this.panelPlaying.Visible = false;
            this.buttonStart.Click += (s, e) =>
            {
                //格式：Start，桌号，座位号
                SendToServer($"Start,{tableIndex},{side}");
                this.buttonStart.Enabled = false;
            };
            this.buttonLogout.Click += (s, e) =>  this.Close();
            this.buttonSend.Click += (s, e) =>
            {
                //格式：Talk,桌号,发言内容
                SendToServer($"Talk,{tableIndex},{textBoxSend.Text}");
            };
            this.buttonLogin.Click += ButtonLogin_Click;
            this.pictureBox1.Paint += PictureBox1_Paint;
            this.FormClosing += PlayingTable_FormClosing;
            this.radioButton1.CheckedChanged += RadioButton_CheckedChanged;
            this.radioButton2.CheckedChanged += RadioButton_CheckedChanged;
            this.radioButton3.CheckedChanged += RadioButton_CheckedChanged;
            this.radioButton4.CheckedChanged += RadioButton_CheckedChanged;
            this.radioButton5.CheckedChanged += RadioButton_CheckedChanged;
        }
        private void ButtonLogin_Click(object? sender, EventArgs e)
        {
            if (textBoxUserName.Text.Trim().Length == 0)
            {
                MessageBox.Show("用户名不能为空。", "警告");
                return;
            }
            this.userName = textBoxUserName.Text.Trim();
            client = new();
            if (localIPv4Address != null)
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
            }
            buttonLogin.Enabled = false;
            NetworkStream netStream = client.GetStream();
            sr = new StreamReader(netStream, Encoding.UTF8);
            sw = new StreamWriter(netStream, Encoding.UTF8);
            ThreadStart threadStart = new(ReceiveData);
            Thread threadReceive = new(threadStart)
            {
                IsBackground = true
            };
            threadReceive.Start();
            //登录服务器，获取服务器各桌信息。格式：Login,用户名
            SendToServer($"Login,{userName}");
        }

        /// <summary>单击登录按钮后线程执行的方法</summary>
        private void ReceiveData()
        {
            bool exitWhile = false;
            while (exitWhile == false)
            {
                string? receiveStr = null;
                try
                {
                    receiveStr = sr?.ReadLine();
                }
                catch (Exception ex)
                {
                    AddItemToListBox($"接收数据失败：{ex.Message}");
                }
                if (receiveStr == null)
                {
                    if (normalExit == false)
                        MessageBox.Show("与服务器失去联系，游戏无法继续！");
                    side = -1;
                    normalExit = true;  //结束线程
                    break;
                }

                //调试用。如果希望在listBox1中看到接收到的信息，可取消该行注释
                //AddItemToListBox("收到：" + receiveString);

                string[] splitString = receiveStr.Split(',');
                string command = splitString[0].ToLower();
                switch (command)
                {
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
                                        UpdateCheckBox(checkBoxGameTables[i, j], false);
                                    else
                                        UpdateCheckBox(checkBoxGameTables[i, j], true);
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
                    case "getup":
                        //自己或者对方离座(格式：GetUp,桌号,座位号,用户名)
                        if (side == int.Parse(splitString[1])) //自己离座
                            side = -1;
                        else  //对方离座
                        {
                            SetTableSideText(splitString[1], splitString[2], splitString[3]);
                            MessageBox.Show("敌人逃跑了，我方胜利了", "",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Restart();
                        }
                        break;
                    case "lost":  //对家与服务器失去联系(格式：Lost,座位号,用户名)
                        SetTableSideText(tableIndex.ToString(), splitString[1], splitString[2]);
                        MessageBox.Show("对家与服务器失去联系，游戏无法继续", "",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Restart();
                        break;
                    case "talk":  //格式：Talk,说话者,对话内容
                        ShowTalk(splitString[1],
                            receiveStr.Remove(0, splitString[0].Length + splitString[1].Length));
                        break;
                    case "message":   //格式：Message,内容
                        ShowMessage(splitString[1]);
                        break;
                    case "level": //设置难度级别(格式：Level,桌号,难度级别)
                        SetLevel(splitString[2]);
                        break;
                    case "setdot": //产生的棋子位置信息(格式：Setdot,行,列,颜色)
                        SetDot(
                            int.Parse(splitString[1]),
                            int.Parse(splitString[2]),
                            (DotColor)int.Parse(splitString[3]));
                        break;
                    case "unsetdot": //消去棋子的信息(格式：UnsetDot,行,列)
                        int x = 20 * (int.Parse(splitString[1]) + 1);
                        int y = 20 * (int.Parse(splitString[2]) + 1);
                        UnsetDot(x, y);
                        break;
                    case "win":  //格式：Win,相邻棋子的颜色
                        string winner;
                        if ((DotColor)int.Parse(splitString[1]) == DotColor.Black)
                            winner = "黑方出现相邻点，白方胜利！";
                        else
                            winner = "白方出现相邻点，黑方胜利！";
                        AddItemToListBox(winner);
                        MessageBox.Show(winner, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Restart();
                        break;
                }
            }
        }
        private void RadioButton_CheckedChanged(object? sender, EventArgs e)
        {
            //isReceiveCommand为true表明是接收服务器设置的难度级别触发的此事件
            //就不需要再向服务器发送
            if (isReceiveCommand == false)
            {
                RadioButton? radiobutton = sender as RadioButton;
                if (radiobutton?.Checked == true)
                {
                    //设置难度级别
                    //radiobutton.Name[^1]}表示倒数第1个字符
                    SendToServer($"Level,{tableIndex},{radiobutton.Name[^1]}");
                }
            }
        }

        private void PlayingTable_FormClosing(object? sender, FormClosingEventArgs e)
        {
            //服务器停止服务时,normalExited为true，其他情况为false
            if (normalExit == false)
            {
                //通知服务器，用户从游戏室退出
                SendToServer("Logout");
                normalExit = true;
            }
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

        /// <summary>在pictureBox1中按下鼠标触发的事件</summary>
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int x = e.X / 20;
            int y = e.Y / 20;
            if (!(x < 1 || x > 15 || y < 1 || y > 15))
            {
                if (grid[x - 1, y - 1] != DotColor.None)
                {
                    int color = (int)grid[x - 1, y - 1];
                    //发送格式：UnsetDot,桌号,座位号,行,列,颜色
                    SendToServer($"UnsetDot,{tableIndex},{side},{x - 1},{y - 1},{color}");
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
            if (s[2 * i + j] == '1')   //1表示有人
            {
                checkBoxGameTables[i, j].Checked = true;
                checkBoxGameTables[i, j].Enabled = false;
            }
            else  //0表示无人
            {
                checkBoxGameTables[i, j].Checked = false;
                checkBoxGameTables[i, j].Enabled = true;
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
        public void SetLabel(Label label, string str)
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

        /// <summary>设置radioButton选择状态</summary>
        private void SetRadioButton(RadioButton radioButton, bool isChecked)
        {
            if (radioButton.InvokeRequired)
            {
                radioButton.Invoke(SetRadioButton, radioButton, isChecked);
            }
            else
            {
                radioButton.Checked = isChecked;
            }
        }

        /// <summary>设置棋子状态（i：行号，j：列号，dotColor：棋子颜色）</summary>
        public void SetDot(int i, int j, DotColor dotColor)
        {
            grid[i, j] = dotColor;
            pictureBox1.Invalidate();
        }

        /// <summary>取消棋子（x：x坐标，y：y坐标）</summary>
        public void UnsetDot(int x, int y)
        {
            grid[x / 20 - 1, y / 20 - 1] = DotColor.None;
            pictureBox1.Invalidate();
        }

        /// <summary>重新开始新游戏</summary>
        public void Restart()
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

        /// <summary>设置游戏难度级别（levelString：难度级别）</summary>
        public void SetLevel(string levelString)
        {
            isReceiveCommand = true;
            switch (levelString)
            {
                case "1": SetRadioButton(radioButton1, true); break;
                case "2": SetRadioButton(radioButton2, true); break;
                case "3": SetRadioButton(radioButton3, true); break;
                case "4": SetRadioButton(radioButton4, true); break;
                case "5": SetRadioButton(radioButton5, true); break;
            }
            isReceiveCommand = false;
        }


        /// <summary>显示发言信息（talkMan：发言人，str：发言信息）</summary>
        public void ShowTalk(string talkMan, string str)
        {
            AddItemToListBox(string.Format("{0}说：{1}", talkMan, str));
        }

        /// <summary>显示消息（str：消息字符串）</summary>
        public void ShowMessage(string str)
        {
            AddItemToListBox(str);
        }

        /// <summary>向服务器发送数据</summary>
        public void SendToServer(string str)
        {
            if (sw != null)
            {
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
        }

        /// <summary>在listbox中追加str信息<</summary>
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

    }
}
