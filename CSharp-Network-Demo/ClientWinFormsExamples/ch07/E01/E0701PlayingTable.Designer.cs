namespace ClientWinFormsExamples.ch07.E01
{
    partial class E0701PlayingTable
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
            listBox1 = new ListBox();
            pictureBox1 = new PictureBox();
            buttonStart = new Button();
            label1 = new Label();
            labelTableIndex = new Label();
            textBoxSend = new TextBox();
            labelBlackSide = new Label();
            groupBox1 = new GroupBox();
            radioButton5 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            labelWhiteSide = new Label();
            buttonSend = new Button();
            panelPlaying = new Panel();
            buttonLogout = new Button();
            buttonLogin = new Button();
            panelTables = new Panel();
            groupBox2 = new GroupBox();
            textBoxServer = new TextBox();
            textBoxUserName = new TextBox();
            label5 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            panelPlaying.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.HorizontalScrollbar = true;
            listBox1.ItemHeight = 17;
            listBox1.Location = new Point(13, 220);
            listBox1.Margin = new Padding(4);
            listBox1.Name = "listBox1";
            listBox1.ScrollAlwaysVisible = true;
            listBox1.Size = new Size(329, 225);
            listBox1.TabIndex = 14;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Resource1.grid;
            pictureBox1.Location = new Point(143, 4);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(343, 343);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 25;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(32, 314);
            buttonStart.Margin = new Padding(4);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(78, 33);
            buttonStart.TabIndex = 27;
            buttonStart.Text = "开始";
            buttonStart.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 373);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(44, 17);
            label1.TabIndex = 37;
            label1.Text = "发言：";
            // 
            // labelTableIndex
            // 
            labelTableIndex.AutoSize = true;
            labelTableIndex.Location = new Point(10, 13);
            labelTableIndex.Name = "labelTableIndex";
            labelTableIndex.Size = new Size(44, 17);
            labelTableIndex.TabIndex = 42;
            labelTableIndex.Text = "桌号：";
            // 
            // textBoxSend
            // 
            textBoxSend.Location = new Point(62, 367);
            textBoxSend.Margin = new Padding(4);
            textBoxSend.Name = "textBoxSend";
            textBoxSend.Size = new Size(344, 23);
            textBoxSend.TabIndex = 36;
            // 
            // labelBlackSide
            // 
            labelBlackSide.AutoSize = true;
            labelBlackSide.Location = new Point(10, 45);
            labelBlackSide.Name = "labelBlackSide";
            labelBlackSide.Size = new Size(44, 17);
            labelBlackSide.TabIndex = 42;
            labelBlackSide.Text = "黑方：";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton5);
            groupBox1.Controls.Add(radioButton4);
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(10, 108);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(116, 184);
            groupBox1.TabIndex = 24;
            groupBox1.TabStop = false;
            groupBox1.Text = "难度级别";
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new Point(21, 153);
            radioButton5.Margin = new Padding(4);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(76, 21);
            radioButton5.TabIndex = 0;
            radioButton5.Text = "5级(0.4s)";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(21, 124);
            radioButton4.Margin = new Padding(4);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(76, 21);
            radioButton4.TabIndex = 0;
            radioButton4.Text = "4级(0.8s)";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(21, 95);
            radioButton3.Margin = new Padding(4);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(76, 21);
            radioButton3.TabIndex = 0;
            radioButton3.Text = "3级(1.2s)";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(22, 68);
            radioButton2.Margin = new Padding(4);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(76, 21);
            radioButton2.TabIndex = 0;
            radioButton2.Text = "2级(1.6s)";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(22, 39);
            radioButton1.Margin = new Padding(4);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(76, 21);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "1级(2.0s)";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // labelWhiteSide
            // 
            labelWhiteSide.AutoSize = true;
            labelWhiteSide.Location = new Point(10, 76);
            labelWhiteSide.Name = "labelWhiteSide";
            labelWhiteSide.Size = new Size(44, 17);
            labelWhiteSide.TabIndex = 42;
            labelWhiteSide.Text = "白方：";
            // 
            // buttonSend
            // 
            buttonSend.Location = new Point(414, 367);
            buttonSend.Margin = new Padding(4);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(72, 23);
            buttonSend.TabIndex = 38;
            buttonSend.Text = "发送";
            buttonSend.UseVisualStyleBackColor = true;
            // 
            // panelPlaying
            // 
            panelPlaying.Controls.Add(buttonSend);
            panelPlaying.Controls.Add(labelWhiteSide);
            panelPlaying.Controls.Add(groupBox1);
            panelPlaying.Controls.Add(labelBlackSide);
            panelPlaying.Controls.Add(textBoxSend);
            panelPlaying.Controls.Add(labelTableIndex);
            panelPlaying.Controls.Add(label1);
            panelPlaying.Controls.Add(buttonStart);
            panelPlaying.Controls.Add(pictureBox1);
            panelPlaying.Location = new Point(352, 39);
            panelPlaying.Name = "panelPlaying";
            panelPlaying.Size = new Size(498, 406);
            panelPlaying.TabIndex = 35;
            // 
            // buttonLogout
            // 
            buttonLogout.Location = new Point(545, 5);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(78, 24);
            buttonLogout.TabIndex = 26;
            buttonLogout.Text = "退出";
            buttonLogout.UseVisualStyleBackColor = true;
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(460, 5);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(75, 23);
            buttonLogin.TabIndex = 41;
            buttonLogin.Text = "登录";
            buttonLogin.UseVisualStyleBackColor = true;
            // 
            // panelTables
            // 
            panelTables.AutoScroll = true;
            panelTables.BorderStyle = BorderStyle.FixedSingle;
            panelTables.Dock = DockStyle.Fill;
            panelTables.Location = new Point(3, 19);
            panelTables.Margin = new Padding(4);
            panelTables.Name = "panelTables";
            panelTables.Size = new Size(323, 142);
            panelTables.TabIndex = 17;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(panelTables);
            groupBox2.Location = new Point(13, 43);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(329, 164);
            groupBox2.TabIndex = 36;
            groupBox2.TabStop = false;
            groupBox2.Text = "游戏桌";
            // 
            // textBoxServer
            // 
            textBoxServer.Location = new Point(79, 5);
            textBoxServer.Name = "textBoxServer";
            textBoxServer.Size = new Size(158, 23);
            textBoxServer.TabIndex = 60;
            // 
            // textBoxUserName
            // 
            textBoxUserName.Location = new Point(314, 5);
            textBoxUserName.Name = "textBoxUserName";
            textBoxUserName.Size = new Size(108, 23);
            textBoxUserName.TabIndex = 61;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 8);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(56, 17);
            label5.TabIndex = 58;
            label5.Text = "服务器：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(261, 8);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(56, 17);
            label3.TabIndex = 59;
            label3.Text = "用户名：";
            // 
            // E0701PlayingTable
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(862, 459);
            Controls.Add(textBoxServer);
            Controls.Add(textBoxUserName);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(buttonLogin);
            Controls.Add(groupBox2);
            Controls.Add(buttonLogout);
            Controls.Add(panelPlaying);
            Controls.Add(listBox1);
            Name = "E0701PlayingTable";
            Text = "棋子消消乐";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panelPlaying.ResumeLayout(false);
            panelPlaying.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox listBox1;
        private PictureBox pictureBox1;
        private Button buttonStart;
        private Label label1;
        private Label labelTableIndex;
        private TextBox textBoxSend;
        private Label labelBlackSide;
        private GroupBox groupBox1;
        private RadioButton radioButton5;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label labelWhiteSide;
        private Button buttonSend;
        private Panel panelPlaying;
        private Button buttonLogout;
        private Button buttonLogin;
        private Panel panelTables;
        private GroupBox groupBox2;
        private TextBox textBoxServer;
        private TextBox textBoxUserName;
        private Label label5;
        private Label label3;
    }
}