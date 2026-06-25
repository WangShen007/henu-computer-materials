namespace ClientWinFormsExamples.ch08.E01
{
    partial class E0801UdpChat
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
            groupBox2 = new GroupBox();
            listBoxStatus = new ListBox();
            groupBox1 = new GroupBox();
            listBoxReceive = new ListBox();
            buttonSend = new Button();
            textBoxSend = new TextBox();
            textBoxRemoteIP = new TextBox();
            label3 = new Label();
            label2 = new Label();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(listBoxStatus);
            groupBox2.Location = new Point(12, 177);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(563, 118);
            groupBox2.TabIndex = 22;
            groupBox2.TabStop = false;
            groupBox2.Text = "状态信息";
            // 
            // listBoxStatus
            // 
            listBoxStatus.FormattingEnabled = true;
            listBoxStatus.ItemHeight = 17;
            listBoxStatus.Location = new Point(11, 20);
            listBoxStatus.Name = "listBoxStatus";
            listBoxStatus.Size = new Size(539, 89);
            listBoxStatus.TabIndex = 7;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listBoxReceive);
            groupBox1.Location = new Point(12, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(563, 121);
            groupBox1.TabIndex = 21;
            groupBox1.TabStop = false;
            groupBox1.Text = "接收的信息";
            // 
            // listBoxReceive
            // 
            listBoxReceive.FormattingEnabled = true;
            listBoxReceive.ItemHeight = 17;
            listBoxReceive.Location = new Point(11, 22);
            listBoxReceive.Name = "listBoxReceive";
            listBoxReceive.Size = new Size(539, 89);
            listBoxReceive.TabIndex = 7;
            // 
            // buttonSend
            // 
            buttonSend.Location = new Point(479, 137);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(72, 23);
            buttonSend.TabIndex = 20;
            buttonSend.Text = "发送";
            buttonSend.UseVisualStyleBackColor = true;
            // 
            // textBoxSend
            // 
            textBoxSend.Location = new Point(302, 137);
            textBoxSend.Name = "textBoxSend";
            textBoxSend.Size = new Size(151, 23);
            textBoxSend.TabIndex = 19;
            // 
            // textBoxRemoteIP
            // 
            textBoxRemoteIP.Location = new Point(74, 136);
            textBoxRemoteIP.Name = "textBoxRemoteIP";
            textBoxRemoteIP.Size = new Size(143, 23);
            textBoxRemoteIP.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(231, 139);
            label3.Name = "label3";
            label3.Size = new Size(68, 17);
            label3.TabIndex = 17;
            label3.Text = "发送信息：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 140);
            label2.Name = "label2";
            label2.Size = new Size(55, 17);
            label2.TabIndex = 16;
            label2.Text = "远程IP：";
            // 
            // E0801UdpChat
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 306);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(buttonSend);
            Controls.Add(textBoxSend);
            Controls.Add(textBoxRemoteIP);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "E0801UdpChat";
            Text = "E0801UdpChat";
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox2;
        private ListBox listBoxStatus;
        private GroupBox groupBox1;
        private ListBox listBoxReceive;
        private Button buttonSend;
        private TextBox textBoxSend;
        private TextBox textBoxRemoteIP;
        private Label label3;
        private Label label2;
    }
}