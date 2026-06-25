namespace ClientWinFormsExamples.ch04
{
    partial class E0410Stopwatch
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
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            label3 = new Label();
            buttonStart = new Button();
            buttonStop = new Button();
            groupBox1 = new GroupBox();
            label4 = new Label();
            label2 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(188, 28);
            label1.Name = "label1";
            label1.Size = new Size(43, 17);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 28);
            label3.Name = "label3";
            label3.Size = new Size(118, 17);
            label3.TabIndex = 2;
            label3.Text = "定时时间（秒）：80";
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(138, 100);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(75, 23);
            buttonStart.TabIndex = 4;
            buttonStart.Text = "开始计时";
            buttonStart.UseVisualStyleBackColor = true;
            // 
            // buttonStop
            // 
            buttonStop.Location = new Point(272, 100);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(75, 23);
            buttonStop.TabIndex = 5;
            buttonStop.Text = "停止计时";
            buttonStop.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(buttonStop);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(buttonStart);
            groupBox1.Location = new Point(26, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(577, 145);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "计时器、秒表、随机数基本用法";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(188, 60);
            label4.Name = "label4";
            label4.Size = new Size(43, 17);
            label4.TabIndex = 7;
            label4.Text = "label4";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 60);
            label2.Name = "label2";
            label2.Size = new Size(123, 17);
            label2.TabIndex = 6;
            label2.Text = "每5秒产生一个随机数";
            // 
            // E0410Stopwatch
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 175);
            Controls.Add(groupBox1);
            Name = "E0410Stopwatch";
            Text = "FormE0410Stopwatch";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Label label1;
        private Label label3;
        private Button buttonStart;
        private Button buttonStop;
        private GroupBox groupBox1;
        private Label label4;
        private Label label2;
    }
}