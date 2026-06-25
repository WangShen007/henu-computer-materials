namespace FuLuAWinForms
{
    partial class SY08Form
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
            textBox1 = new TextBox();
            buttonStop = new Button();
            buttonStart = new Button();
            textBoxPort = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(35, 74);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(477, 231);
            textBox1.TabIndex = 9;
            // 
            // buttonStop
            // 
            buttonStop.Location = new Point(461, 19);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(75, 23);
            buttonStop.TabIndex = 8;
            buttonStop.Text = "关闭监听";
            buttonStop.UseVisualStyleBackColor = true;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(359, 19);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(75, 23);
            buttonStart.TabIndex = 7;
            buttonStart.Text = "启动监听";
            buttonStart.UseVisualStyleBackColor = true;
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new Point(223, 19);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new Size(100, 23);
            textBoxPort.TabIndex = 6;
            textBoxPort.Text = "51888";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 22);
            label1.Name = "label1";
            label1.Size = new Size(195, 17);
            label1.TabIndex = 5;
            label1.Text = "请设置要监听的端口号(1-65535)：";
            // 
            // SY08Form
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(565, 330);
            Controls.Add(textBox1);
            Controls.Add(buttonStop);
            Controls.Add(buttonStart);
            Controls.Add(textBoxPort);
            Controls.Add(label1);
            Name = "SY08Form";
            Text = "SY08Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button buttonStop;
        private Button buttonStart;
        private TextBox textBoxPort;
        private Label label1;
    }
}