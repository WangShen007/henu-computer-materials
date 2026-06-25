namespace ClientWinFormsExamples.ch07.E02
{
    partial class ChatForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            groupBox3 = new GroupBox();
            listBoxOnline = new ListBox();
            textBoxSend = new TextBox();
            textBoxUserName = new TextBox();
            label1 = new Label();
            buttonSend = new Button();
            buttonConnect = new Button();
            label2 = new Label();
            listBoxStatus = new ListBox();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(listBoxOnline);
            groupBox3.Location = new Point(104, 13);
            groupBox3.Margin = new Padding(4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4);
            groupBox3.Size = new Size(222, 107);
            groupBox3.TabIndex = 20;
            groupBox3.TabStop = false;
            groupBox3.Text = "在线人员";
            // 
            // listBoxOnline
            // 
            listBoxOnline.FormattingEnabled = true;
            listBoxOnline.ItemHeight = 17;
            listBoxOnline.Location = new Point(13, 25);
            listBoxOnline.Name = "listBoxOnline";
            listBoxOnline.Size = new Size(196, 72);
            listBoxOnline.TabIndex = 23;
            // 
            // textBoxSend
            // 
            textBoxSend.Location = new Point(61, 257);
            textBoxSend.Margin = new Padding(4);
            textBoxSend.Multiline = true;
            textBoxSend.Name = "textBoxSend";
            textBoxSend.Size = new Size(182, 29);
            textBoxSend.TabIndex = 2;
            // 
            // textBoxUserName
            // 
            textBoxUserName.Location = new Point(13, 38);
            textBoxUserName.Margin = new Padding(4);
            textBoxUserName.Name = "textBoxUserName";
            textBoxUserName.Size = new Size(83, 23);
            textBoxUserName.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 17);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(56, 17);
            label1.TabIndex = 18;
            label1.Text = "用户名：";
            // 
            // buttonSend
            // 
            buttonSend.Location = new Point(251, 257);
            buttonSend.Margin = new Padding(4);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(62, 29);
            buttonSend.TabIndex = 1;
            buttonSend.Text = "发送";
            buttonSend.UseVisualStyleBackColor = true;
            // 
            // buttonConnect
            // 
            buttonConnect.Location = new Point(26, 69);
            buttonConnect.Margin = new Padding(4);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(56, 27);
            buttonConnect.TabIndex = 15;
            buttonConnect.Text = "登录";
            buttonConnect.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 263);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 18;
            label2.Text = "发言：";
            // 
            // listBoxStatus
            // 
            listBoxStatus.FormattingEnabled = true;
            listBoxStatus.ItemHeight = 17;
            listBoxStatus.Location = new Point(10, 127);
            listBoxStatus.Name = "listBoxStatus";
            listBoxStatus.Size = new Size(317, 123);
            listBoxStatus.TabIndex = 22;
            // 
            // TalkForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(336, 296);
            Controls.Add(listBoxStatus);
            Controls.Add(buttonSend);
            Controls.Add(textBoxSend);
            Controls.Add(groupBox3);
            Controls.Add(textBoxUserName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonConnect);
            Margin = new Padding(4);
            Name = "TalkForm";
            Text = "群聊";
            FormClosing += FormClient_FormClosing;
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox3;
        private TextBox textBoxSend;
        private TextBox textBoxUserName;
        private Label label1;
        private Button buttonSend;
        private Button buttonConnect;
        private Label label2;
        private ListBox listBoxStatus;
        private ListBox listBoxOnline;
    }
}

