namespace FuLuAWinForms
{
    partial class SY09Form
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
            label1 = new Label();
            textBoxRemoteIP = new TextBox();
            label2 = new Label();
            textBoxSendMessage = new TextBox();
            buttonSend = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 26);
            label1.Name = "label1";
            label1.Size = new Size(55, 17);
            label1.TabIndex = 0;
            label1.Text = "目标IP：";
            // 
            // textBoxRemoteIP
            // 
            textBoxRemoteIP.Location = new Point(165, 23);
            textBoxRemoteIP.Name = "textBoxRemoteIP";
            textBoxRemoteIP.Size = new Size(180, 23);
            textBoxRemoteIP.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(70, 69);
            label2.Name = "label2";
            label2.Size = new Size(68, 17);
            label2.TabIndex = 0;
            label2.Text = "呼叫信息：";
            // 
            // textBoxSendMessage
            // 
            textBoxSendMessage.Location = new Point(165, 66);
            textBoxSendMessage.Name = "textBoxSendMessage";
            textBoxSendMessage.Size = new Size(180, 23);
            textBoxSendMessage.TabIndex = 1;
            // 
            // buttonSend
            // 
            buttonSend.Location = new Point(146, 130);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(75, 23);
            buttonSend.TabIndex = 2;
            buttonSend.Text = "发送";
            buttonSend.UseVisualStyleBackColor = true;
            // 
            // SY09Form
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(437, 202);
            Controls.Add(buttonSend);
            Controls.Add(textBoxSendMessage);
            Controls.Add(label2);
            Controls.Add(textBoxRemoteIP);
            Controls.Add(label1);
            Name = "SY09Form";
            Text = "SY09Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxRemoteIP;
        private Label label2;
        private TextBox textBoxSendMessage;
        private Button buttonSend;
    }
}