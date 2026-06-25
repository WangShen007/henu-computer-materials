using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace _2210050000_name_lab06_TCP
{
    partial class Form1 : Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnStartTwoClients;
        private System.Windows.Forms.Button btnStartOneClient;

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
            this.btnStartTwoClients = new System.Windows.Forms.Button();
            this.btnStartOneClient = new System.Windows.Forms.Button();
            this.btnStartTwoClients.Location = new System.Drawing.Point(50, 30);
            this.btnStartTwoClients.Name = "btnStartTwoClients";
            this.btnStartTwoClients.Size = new System.Drawing.Size(200, 30);
            this.btnStartTwoClients.TabIndex = 0;
            this.btnStartTwoClients.Text = "同时启动2个客户端 (测试用)";
            this.btnStartTwoClients.UseVisualStyleBackColor = true;
            this.btnStartTwoClients.Click += new System.EventHandler(this.btnStartTwoClients_Click);
            this.btnStartOneClient.Location = new System.Drawing.Point(50, 80);
            this.btnStartOneClient.Name = "btnStartOneClient";
            this.btnStartOneClient.Size = new System.Drawing.Size(200, 30);
            this.btnStartOneClient.TabIndex = 1;
            this.btnStartOneClient.Text = "只启动1个客户端 (实际情况)";
            this.btnStartOneClient.UseVisualStyleBackColor = true;
            this.btnStartOneClient.Click += new System.EventHandler(this.btnStartOneClient_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Controls.Add(this.btnStartOneClient);
            this.Controls.Add(this.btnStartTwoClients);
            this.Name = "Form1"; this.Text = "主界面";
            this.ResumeLayout(false);
        }
    }
}