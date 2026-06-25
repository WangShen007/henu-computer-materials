using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace _2210050000_name_lab06_TCP
{
    partial class ClientChatWindow : Form
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblOnlineUsers;
        private System.Windows.Forms.ListBox lstOnlineUsers;
        private System.Windows.Forms.Label lblChatMessages;
        private System.Windows.Forms.RichTextBox rtbChatMessages;
        private System.Windows.Forms.Label lblMessagePrompt;
        private System.Windows.Forms.TextBox txtMessageInput;
        private System.Windows.Forms.Button btnSend;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblOnlineUsers = new System.Windows.Forms.Label();
            this.lstOnlineUsers = new System.Windows.Forms.ListBox();
            this.lblChatMessages = new System.Windows.Forms.Label();
            this.rtbChatMessages = new System.Windows.Forms.RichTextBox();
            this.lblMessagePrompt = new System.Windows.Forms.Label();
            this.txtMessageInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(12, 15);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(47, 13);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "用户名:";
            this.txtUsername.Location = new System.Drawing.Point(65, 12);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(120, 20);
            this.txtUsername.TabIndex = 1;
            this.btnLogin.Location = new System.Drawing.Point(191, 10);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.lblOnlineUsers.AutoSize = true;
            this.lblOnlineUsers.Location = new System.Drawing.Point(12, 45);
            this.lblOnlineUsers.Name = "lblOnlineUsers";
            this.lblOnlineUsers.Size = new System.Drawing.Size(59, 13);
            this.lblOnlineUsers.TabIndex = 3;
            this.lblOnlineUsers.Text = "在线用户";
            this.lstOnlineUsers.FormattingEnabled = true;
            this.lstOnlineUsers.Location = new System.Drawing.Point(15, 61);
            this.lstOnlineUsers.Name = "lstOnlineUsers";
            this.lstOnlineUsers.Size = new System.Drawing.Size(120, 199);
            this.lstOnlineUsers.TabIndex = 4;
            this.lblChatMessages.AutoSize = true;
            this.lblChatMessages.Location = new System.Drawing.Point(148, 45);
            this.lblChatMessages.Name = "lblChatMessages";
            this.lblChatMessages.Size = new System.Drawing.Size(59, 13);
            this.lblChatMessages.TabIndex = 5;
            this.lblChatMessages.Text = "对话信息";
            this.rtbChatMessages.Location = new System.Drawing.Point(151, 61);
            this.rtbChatMessages.Name = "rtbChatMessages";
            this.rtbChatMessages.ReadOnly = true;
            this.rtbChatMessages.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbChatMessages.Size = new System.Drawing.Size(270, 199);
            this.rtbChatMessages.TabIndex = 6;
            this.rtbChatMessages.Text = "";
            this.lblMessagePrompt.AutoSize = true;
            this.lblMessagePrompt.Location = new System.Drawing.Point(12, 273);
            this.lblMessagePrompt.Name = "lblMessagePrompt";
            this.lblMessagePrompt.Size = new System.Drawing.Size(35, 13);
            this.lblMessagePrompt.TabIndex = 7;
            this.lblMessagePrompt.Text = "发言:";
            this.txtMessageInput.Location = new System.Drawing.Point(53, 270);
            this.txtMessageInput.Name = "txtMessageInput";
            this.txtMessageInput.Size = new System.Drawing.Size(287, 20);
            this.txtMessageInput.TabIndex = 8;
            this.btnSend.Location = new System.Drawing.Point(346, 268);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 301);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessageInput);
            this.Controls.Add(this.lblMessagePrompt);
            this.Controls.Add(this.rtbChatMessages);
            this.Controls.Add(this.lblChatMessages);
            this.Controls.Add(this.lstOnlineUsers);
            this.Controls.Add(this.lblOnlineUsers);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblUsername);
            this.Name = "ClientChatWindow"; this.Text = "群聊客户端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientChatWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}