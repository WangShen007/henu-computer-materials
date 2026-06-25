namespace ClientWinFormsExamples.ch08.E04
{
    partial class E0804Meeting
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
            buttonSend = new Button();
            textBoxMessage = new TextBox();
            label2 = new Label();
            groupBox2 = new GroupBox();
            listBoxAddress = new ListBox();
            groupBox1 = new GroupBox();
            listBoxMessage = new ListBox();
            buttonLogout = new Button();
            buttonLogin = new Button();
            label1 = new Label();
            labelUserName = new Label();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // buttonSend
            // 
            buttonSend.Location = new Point(503, 182);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(75, 23);
            buttonSend.TabIndex = 17;
            buttonSend.Text = "发送";
            buttonSend.UseVisualStyleBackColor = true;
            // 
            // textBoxMessage
            // 
            textBoxMessage.Location = new Point(94, 180);
            textBoxMessage.Name = "textBoxMessage";
            textBoxMessage.Size = new Size(397, 23);
            textBoxMessage.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 180);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 15;
            label2.Text = "发言：";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(listBoxAddress);
            groupBox2.Location = new Point(551, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(156, 152);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "会议室成员";
            // 
            // listBoxAddress
            // 
            listBoxAddress.Dock = DockStyle.Fill;
            listBoxAddress.FormattingEnabled = true;
            listBoxAddress.ItemHeight = 17;
            listBoxAddress.Location = new Point(3, 19);
            listBoxAddress.Name = "listBoxAddress";
            listBoxAddress.Size = new Size(150, 130);
            listBoxAddress.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listBoxMessage);
            groupBox1.Location = new Point(218, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(306, 158);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "会议室消息";
            // 
            // listBoxMessage
            // 
            listBoxMessage.Dock = DockStyle.Fill;
            listBoxMessage.FormattingEnabled = true;
            listBoxMessage.ItemHeight = 17;
            listBoxMessage.Location = new Point(3, 19);
            listBoxMessage.Name = "listBoxMessage";
            listBoxMessage.Size = new Size(300, 136);
            listBoxMessage.TabIndex = 0;
            // 
            // buttonLogout
            // 
            buttonLogout.Location = new Point(51, 110);
            buttonLogout.Name = "buttonLogout";
            buttonLogout.Size = new Size(88, 23);
            buttonLogout.TabIndex = 12;
            buttonLogout.Text = "离开会议室";
            buttonLogout.UseVisualStyleBackColor = true;
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(47, 67);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(88, 23);
            buttonLogin.TabIndex = 11;
            buttonLogin.Text = "进入会议室";
            buttonLogin.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 9);
            label1.Name = "label1";
            label1.Size = new Size(99, 17);
            label1.TabIndex = 9;
            label1.Text = "用户名(本机IP)：";
            // 
            // labelUserName
            // 
            labelUserName.AutoSize = true;
            labelUserName.Location = new Point(104, 9);
            labelUserName.Name = "labelUserName";
            labelUserName.Size = new Size(0, 17);
            labelUserName.TabIndex = 18;
            // 
            // E0804Meeting
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(726, 215);
            Controls.Add(labelUserName);
            Controls.Add(buttonSend);
            Controls.Add(textBoxMessage);
            Controls.Add(label2);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(buttonLogout);
            Controls.Add(buttonLogin);
            Controls.Add(label1);
            Name = "E0804Meeting";
            Text = "E0804Meeting";
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonSend;
        private TextBox textBoxMessage;
        private Label label2;
        private GroupBox groupBox2;
        private ListBox listBoxAddress;
        private GroupBox groupBox1;
        private ListBox listBoxMessage;
        private Button buttonLogout;
        private Button buttonLogin;
        private Label label1;
        private Label labelUserName;
    }
}