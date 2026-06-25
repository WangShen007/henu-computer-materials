namespace FuLuAWinForms
{
    partial class SY06Form
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
            labelCount = new Label();
            textBoxCount = new TextBox();
            groupBox1 = new GroupBox();
            textBox4 = new TextBox();
            label4 = new Label();
            textBox3 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            btnStart = new Button();
            btnOK = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // labelCount
            // 
            labelCount.AutoSize = true;
            labelCount.Location = new Point(120, 28);
            labelCount.Name = "labelCount";
            labelCount.Size = new Size(104, 17);
            labelCount.TabIndex = 0;
            labelCount.Text = "剩余时间（秒）：";
            // 
            // textBoxCount
            // 
            textBoxCount.Location = new Point(230, 25);
            textBoxCount.Name = "textBoxCount";
            textBoxCount.ReadOnly = true;
            textBoxCount.Size = new Size(62, 23);
            textBoxCount.TabIndex = 1;
            textBoxCount.TabStop = false;
            textBoxCount.Text = "25";
            textBoxCount.TextAlign = HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(78, 67);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(256, 207);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(130, 161);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(66, 23);
            textBox4.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 164);
            label4.Name = "label4";
            label4.Size = new Size(83, 17);
            label4.TabIndex = 0;
            label4.Text = "【4】8 / 4 = ";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(130, 121);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(66, 23);
            textBox3.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 124);
            label3.Name = "label3";
            label3.Size = new Size(84, 17);
            label3.TabIndex = 0;
            label3.Text = "【3】9 x 7 = ";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(130, 81);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(66, 23);
            textBox2.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 84);
            label2.Name = "label2";
            label2.Size = new Size(97, 17);
            label2.TabIndex = 0;
            label2.Text = "【2】97 - 18 = ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(130, 41);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(66, 23);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 44);
            label1.Name = "label1";
            label1.Size = new Size(101, 17);
            label1.TabIndex = 0;
            label1.Text = "【1】11 + 22 = ";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(112, 287);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 0;
            btnStart.Text = "开始计时";
            btnStart.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(217, 287);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 1;
            btnOK.Text = "提交结果";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // SY06Form
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(432, 336);
            Controls.Add(btnOK);
            Controls.Add(btnStart);
            Controls.Add(groupBox1);
            Controls.Add(textBoxCount);
            Controls.Add(labelCount);
            Name = "SY06Form";
            Text = "SY06Form";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelCount;
        private TextBox textBoxCount;
        private GroupBox groupBox1;
        private TextBox textBox4;
        private Label label4;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox1;
        private Label label1;
        private Button btnStart;
        private Button btnOK;
    }
}