namespace ClientWinFormsExamples.ch08.E02
{
    partial class E0802AsyncUdpChat
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
            groupBox2.Location = new Point(16, 194);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(594, 119);
            groupBox2.TabIndex = 23;
            groupBox2.TabStop = false;
            groupBox2.Text = "状态信息";
            // 
            // listBoxStatus
            // 
            listBoxStatus.FormattingEnabled = true;
            listBoxStatus.ItemHeight = 17;
            listBoxStatus.Location = new Point(6, 20);
            listBoxStatus.Name = "listBoxStatus";
            listBoxStatus.Size = new Size(581, 89);
            listBoxStatus.TabIndex = 7;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listBoxReceive);
            groupBox1.Location = new Point(12, 7);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(601, 144);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            groupBox1.Text = "接收信息";
            // 
            // listBoxReceive
            // 
            listBoxReceive.Dock = DockStyle.Fill;
            listBoxReceive.FormattingEnabled = true;
            listBoxReceive.HorizontalScrollbar = true;
            listBoxReceive.ItemHeight = 17;
            listBoxReceive.Location = new Point(3, 19);
            listBoxReceive.Name = "listBoxReceive";
            listBoxReceive.Size = new Size(595, 122);
            listBoxReceive.TabIndex = 7;
            // 
            // buttonSend
            // 
            buttonSend.Location = new Point(533, 163);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(72, 23);
            buttonSend.TabIndex = 21;
            buttonSend.Text = "发送";
            buttonSend.UseVisualStyleBackColor = true;
            // 
            // textBoxSend
            // 
            textBoxSend.Location = new Point(344, 165);
            textBoxSend.Name = "textBoxSend";
            textBoxSend.Size = new Size(171, 23);
            textBoxSend.TabIndex = 20;
            // 
            // textBoxRemoteIP
            // 
            textBoxRemoteIP.Location = new Point(87, 162);
            textBoxRemoteIP.Name = "textBoxRemoteIP";
            textBoxRemoteIP.Size = new Size(170, 23);
            textBoxRemoteIP.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(273, 168);
            label3.Name = "label3";
            label3.Size = new Size(68, 17);
            label3.TabIndex = 18;
            label3.Text = "发送信息：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 165);
            label2.Name = "label2";
            label2.Size = new Size(55, 17);
            label2.TabIndex = 17;
            label2.Text = "远程IP：";
            // 
            // E0802AsyncUdpChat
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 322);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(buttonSend);
            Controls.Add(textBoxSend);
            Controls.Add(textBoxRemoteIP);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "E0802AsyncUdpChat";
            Text = "E0802AsyncUdpChat";
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