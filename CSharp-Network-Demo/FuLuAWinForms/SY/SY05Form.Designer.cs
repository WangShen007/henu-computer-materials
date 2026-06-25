namespace FuLuAWinForms
{
    partial class SY05Form
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
            groupBox1 = new GroupBox();
            panel1 = new Panel();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            textBoxMax = new TextBox();
            label2 = new Label();
            textBoxInterval = new TextBox();
            label3 = new Label();
            textBoxMin = new TextBox();
            label1 = new Label();
            btnStart = new Button();
            btnStop = new Button();
            groupBox2 = new GroupBox();
            labelResult = new Label();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.Control;
            groupBox1.Controls.Add(panel1);
            groupBox1.Controls.Add(textBoxMax);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBoxInterval);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBoxMin);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(23, 27);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(598, 144);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "参数";
            // 
            // panel1
            // 
            panel1.Controls.Add(radioButton2);
            panel1.Controls.Add(radioButton1);
            panel1.Location = new Point(380, 29);
            panel1.Name = "panel1";
            panel1.Size = new Size(166, 87);
            panel1.TabIndex = 3;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(28, 52);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(98, 21);
            radioButton2.TabIndex = 1;
            radioButton2.Text = "随机生成实数";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(28, 17);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(98, 21);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "随机生成整数";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // textBoxMax
            // 
            textBoxMax.Location = new Point(253, 26);
            textBoxMax.Name = "textBoxMax";
            textBoxMax.Size = new Size(65, 23);
            textBoxMax.TabIndex = 1;
            textBoxMax.Text = "100";
            textBoxMax.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(203, 29);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 0;
            label2.Text = "最大：";
            // 
            // textBoxInterval
            // 
            textBoxInterval.Location = new Point(177, 82);
            textBoxInterval.Name = "textBoxInterval";
            textBoxInterval.Size = new Size(141, 23);
            textBoxInterval.TabIndex = 2;
            textBoxInterval.Text = "100";
            textBoxInterval.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 85);
            label3.Name = "label3";
            label3.Size = new Size(128, 17);
            label3.TabIndex = 0;
            label3.Text = "定时器间隔（毫秒）：";
            // 
            // textBoxMin
            // 
            textBoxMin.Location = new Point(93, 26);
            textBoxMin.Name = "textBoxMin";
            textBoxMin.Size = new Size(65, 23);
            textBoxMin.TabIndex = 0;
            textBoxMin.Text = "0";
            textBoxMin.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(43, 29);
            label1.Name = "label1";
            label1.Size = new Size(44, 17);
            label1.TabIndex = 0;
            label1.Text = "最小：";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(193, 195);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 0;
            btnStart.Text = "开始";
            btnStart.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(322, 195);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 1;
            btnStop.Text = "停止";
            btnStop.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(labelResult);
            groupBox2.Location = new Point(23, 242);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(593, 76);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "结果";
            // 
            // labelResult
            // 
            labelResult.Dock = DockStyle.Fill;
            labelResult.ForeColor = Color.Red;
            labelResult.Location = new Point(3, 19);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(587, 54);
            labelResult.TabIndex = 0;
            labelResult.Text = "产生的随机数";
            labelResult.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SY05Form
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(646, 348);
            Controls.Add(groupBox2);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(groupBox1);
            Name = "SY05Form";
            Text = "SY05Form";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Button btnStart;
        private Button btnStop;
        private GroupBox groupBox2;
        private Panel panel1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private TextBox textBoxMax;
        private Label label2;
        private TextBox textBoxInterval;
        private Label label3;
        private TextBox textBoxMin;
        private Label labelResult;
    }
}