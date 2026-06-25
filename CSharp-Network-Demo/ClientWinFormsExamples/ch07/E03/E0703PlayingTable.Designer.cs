namespace ClientWinFormsExamples.ch07.E03
{
    partial class E0703PlayingTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelWhiteSide = new Label();
            labelBlackSide = new Label();
            labelTableIndex = new Label();
            buttonLogin = new Button();
            groupBox2 = new GroupBox();
            panelTables = new Panel();
            panelPlaying = new Panel();
            labelGo = new Label();
            buttonSend = new Button();
            groupBox1 = new GroupBox();
            checkBoxSound = new CheckBox();
            checkBoxMusic = new CheckBox();
            textBoxSend = new TextBox();
            label1 = new Label();
            buttonStart = new Button();
            pictureBox1 = new PictureBox();
            listBox1 = new ListBox();
            textBoxServerIP = new TextBox();
            textBoxUserName = new TextBox();
            label5 = new Label();
            label3 = new Label();
            groupBox2.SuspendLayout();
            panelPlaying.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelWhiteSide
            // 
            labelWhiteSide.AutoSize = true;
            labelWhiteSide.Location = new Point(10, 76);
            labelWhiteSide.Name = "labelWhiteSide";
            labelWhiteSide.Size = new Size(44, 17);
            labelWhiteSide.TabIndex = 52;
            labelWhiteSide.Text = "白方：";
            // 
            // labelBlackSide
            // 
            labelBlackSide.AutoSize = true;
            labelBlackSide.Location = new Point(10, 45);
            labelBlackSide.Name = "labelBlackSide";
            labelBlackSide.Size = new Size(44, 17);
            labelBlackSide.TabIndex = 53;
            labelBlackSide.Text = "黑方：";
            // 
            // labelTableIndex
            // 
            labelTableIndex.AutoSize = true;
            labelTableIndex.Location = new Point(10, 11);
            labelTableIndex.Name = "labelTableIndex";
            labelTableIndex.Size = new Size(44, 17);
            labelTableIndex.TabIndex = 54;
            labelTableIndex.Text = "桌号：";
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(468, 5);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(75, 23);
            buttonLogin.TabIndex = 51;
            buttonLogin.Text = "登录";
            buttonLogin.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(panelTables);
            groupBox2.Location = new Point(12, 39);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(329, 162);
            groupBox2.TabIndex = 49;
            groupBox2.TabStop = false;
            groupBox2.Text = "游戏桌";
            // 
            // panelTables
            // 
            panelTables.AutoScroll = true;
            panelTables.BorderStyle = BorderStyle.FixedSingle;
            panelTables.Dock = DockStyle.Fill;
            panelTables.Location = new Point(3, 19);
            panelTables.Margin = new Padding(4);
            panelTables.Name = "panelTables";
            panelTables.Size = new Size(323, 140);
            panelTables.TabIndex = 17;
            // 
            // panelPlaying
            // 
            panelPlaying.Controls.Add(labelGo);
            panelPlaying.Controls.Add(buttonSend);
            panelPlaying.Controls.Add(labelWhiteSide);
            panelPlaying.Controls.Add(groupBox1);
            panelPlaying.Controls.Add(labelBlackSide);
            panelPlaying.Controls.Add(labelTableIndex);
            panelPlaying.Controls.Add(textBoxSend);
            panelPlaying.Controls.Add(label1);
            panelPlaying.Controls.Add(buttonStart);
            panelPlaying.Controls.Add(pictureBox1);
            panelPlaying.Location = new Point(351, 39);
            panelPlaying.Name = "panelPlaying";
            panelPlaying.Size = new Size(498, 406);
            panelPlaying.TabIndex = 48;
            // 
            // labelGo
            // 
            labelGo.BackColor = SystemColors.Control;
            labelGo.BorderStyle = BorderStyle.FixedSingle;
            labelGo.ForeColor = Color.Red;
            labelGo.Location = new Point(11, 106);
            labelGo.Name = "labelGo";
            labelGo.Size = new Size(117, 23);
            labelGo.TabIndex = 55;
            labelGo.Text = "现在该黑方走棋(labelGo)";
            labelGo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonSend
            // 
            buttonSend.Location = new Point(414, 365);
            buttonSend.Margin = new Padding(4);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(72, 23);
            buttonSend.TabIndex = 38;
            buttonSend.Text = "发送";
            buttonSend.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBoxSound);
            groupBox1.Controls.Add(checkBoxMusic);
            groupBox1.Location = new Point(10, 151);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(116, 132);
            groupBox1.TabIndex = 24;
            groupBox1.TabStop = false;
            groupBox1.Text = "音乐和声音";
            // 
            // checkBoxSound
            // 
            checkBoxSound.AutoSize = true;
            checkBoxSound.Checked = true;
            checkBoxSound.CheckState = CheckState.Checked;
            checkBoxSound.Location = new Point(22, 84);
            checkBoxSound.Name = "checkBoxSound";
            checkBoxSound.Size = new Size(75, 21);
            checkBoxSound.TabIndex = 1;
            checkBoxSound.Text = "落子有声";
            checkBoxSound.UseVisualStyleBackColor = true;
            // 
            // checkBoxMusic
            // 
            checkBoxMusic.AutoSize = true;
            checkBoxMusic.Location = new Point(22, 44);
            checkBoxMusic.Name = "checkBoxMusic";
            checkBoxMusic.Size = new Size(75, 21);
            checkBoxMusic.TabIndex = 2;
            checkBoxMusic.Text = "背景音乐";
            checkBoxMusic.UseVisualStyleBackColor = true;
            // 
            // textBoxSend
            // 
            textBoxSend.Location = new Point(62, 365);
            textBoxSend.Margin = new Padding(4);
            textBoxSend.Name = "textBoxSend";
            textBoxSend.Size = new Size(344, 23);
            textBoxSend.TabIndex = 36;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 371);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(44, 17);
            label1.TabIndex = 37;
            label1.Text = "发言：";
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(29, 303);
            buttonStart.Margin = new Padding(4);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(78, 33);
            buttonStart.TabIndex = 27;
            buttonStart.Text = "开始";
            buttonStart.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Resource1.grid;
            pictureBox1.Location = new Point(143, 10);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(343, 343);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 25;
            pictureBox1.TabStop = false;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.HorizontalScrollbar = true;
            listBox1.ItemHeight = 17;
            listBox1.Location = new Point(12, 220);
            listBox1.Margin = new Padding(4);
            listBox1.Name = "listBox1";
            listBox1.ScrollAlwaysVisible = true;
            listBox1.Size = new Size(329, 225);
            listBox1.TabIndex = 44;
            // 
            // textBoxServerIP
            // 
            textBoxServerIP.Location = new Point(87, 5);
            textBoxServerIP.Name = "textBoxServerIP";
            textBoxServerIP.Size = new Size(158, 23);
            textBoxServerIP.TabIndex = 56;
            // 
            // textBoxUserName
            // 
            textBoxUserName.Location = new Point(322, 5);
            textBoxUserName.Name = "textBoxUserName";
            textBoxUserName.Size = new Size(108, 23);
            textBoxUserName.TabIndex = 57;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 8);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(56, 17);
            label5.TabIndex = 54;
            label5.Text = "服务器：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(269, 8);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(56, 17);
            label3.TabIndex = 55;
            label3.Text = "用户名：";
            // 
            // E0703PlayingTable
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(864, 462);
            Controls.Add(textBoxServerIP);
            Controls.Add(textBoxUserName);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(buttonLogin);
            Controls.Add(groupBox2);
            Controls.Add(panelPlaying);
            Controls.Add(listBox1);
            Name = "E0703PlayingTable";
            Text = "网络对战五子棋";
            groupBox2.ResumeLayout(false);
            panelPlaying.ResumeLayout(false);
            panelPlaying.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelWhiteSide;
        private Label labelBlackSide;
        private Label labelTableIndex;
        private Button buttonLogin;
        private GroupBox groupBox2;
        private Panel panelTables;
        private Panel panelPlaying;
        private Button buttonSend;
        private GroupBox groupBox1;
        private TextBox textBoxSend;
        private Label label1;
        private Button buttonStart;
        private PictureBox pictureBox1;
        private ListBox listBox1;
        private CheckBox checkBoxSound;
        private CheckBox checkBoxMusic;
        private Label labelGo;
        private TextBox textBoxServerIP;
        private TextBox textBoxUserName;
        private Label label5;
        private Label label3;
    }
}