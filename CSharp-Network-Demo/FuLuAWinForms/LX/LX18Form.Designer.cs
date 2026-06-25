namespace FuLuAWinForms
{
    partial class LX18Form
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
            textBoxIP = new TextBox();
            buttonStart = new Button();
            buttonStop = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            textBoxPort = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 39);
            label1.Name = "label1";
            label1.Size = new Size(139, 17);
            label1.TabIndex = 0;
            label1.Text = "请设置要连接的ip地址：";
            // 
            // textBoxIP
            // 
            textBoxIP.Location = new Point(178, 36);
            textBoxIP.Name = "textBoxIP";
            textBoxIP.Size = new Size(156, 23);
            textBoxIP.TabIndex = 1;
            textBoxIP.Text = "51888";
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(186, 82);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(75, 23);
            buttonStart.TabIndex = 2;
            buttonStart.Text = "启动监听";
            buttonStart.UseVisualStyleBackColor = true;
            // 
            // buttonStop
            // 
            buttonStop.Location = new Point(288, 82);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(75, 23);
            buttonStop.TabIndex = 3;
            buttonStop.Text = "关闭监听";
            buttonStop.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(46, 121);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(477, 201);
            textBox1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(352, 39);
            label2.Name = "label2";
            label2.Size = new Size(56, 17);
            label2.TabIndex = 0;
            label2.Text = "端口号：";
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new Point(409, 36);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new Size(84, 23);
            textBoxPort.TabIndex = 1;
            textBoxPort.Text = "51888";
            // 
            // LX18Form
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(594, 344);
            Controls.Add(textBox1);
            Controls.Add(buttonStop);
            Controls.Add(buttonStart);
            Controls.Add(textBoxPort);
            Controls.Add(label2);
            Controls.Add(textBoxIP);
            Controls.Add(label1);
            Name = "LX18Form";
            Text = "LX18Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxIP;
        private Button buttonStart;
        private Button buttonStop;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBoxPort;
    }
}