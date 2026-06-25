namespace ClientWinFormsExamples.ch02
{
    partial class E0205
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
            labelMessage = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            checkBoxAll = new CheckBox();
            panel1 = new Panel();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            groupBox1 = new GroupBox();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            groupBox2.SuspendLayout();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // labelMessage
            // 
            labelMessage.BorderStyle = BorderStyle.FixedSingle;
            labelMessage.Location = new Point(85, 222);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(456, 23);
            labelMessage.TabIndex = 7;
            labelMessage.Text = "labelMessage";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(195, 18);
            label1.Name = "label1";
            label1.Size = new Size(200, 17);
            label1.TabIndex = 6;
            label1.Text = "每个参赛人员可以参加多个比赛项目";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(checkBoxAll);
            groupBox2.Controls.Add(panel1);
            groupBox2.Location = new Point(323, 48);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(286, 159);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "参赛项目";
            // 
            // checkBoxAll
            // 
            checkBoxAll.AutoSize = true;
            checkBoxAll.Enabled = false;
            checkBoxAll.Location = new Point(42, 78);
            checkBoxAll.Name = "checkBoxAll";
            checkBoxAll.Size = new Size(51, 21);
            checkBoxAll.TabIndex = 0;
            checkBoxAll.Text = "球类";
            checkBoxAll.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(checkBox2);
            panel1.Controls.Add(checkBox3);
            panel1.Location = new Point(131, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(116, 131);
            panel1.TabIndex = 2;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(13, 15);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(51, 21);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "足球";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox_CheckedChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(13, 54);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(51, 21);
            checkBox2.TabIndex = 0;
            checkBox2.Text = "排球";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox_CheckedChanged;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(13, 93);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(51, 21);
            checkBox3.TabIndex = 0;
            checkBox3.Text = "篮球";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.CheckedChanged += checkBox_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(47, 48);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 166);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "参赛人员";
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(28, 116);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(50, 21);
            radioButton3.TabIndex = 0;
            radioButton3.Text = "王五";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(28, 77);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(50, 21);
            radioButton2.TabIndex = 0;
            radioButton2.Text = "李四";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(28, 38);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(50, 21);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "张三";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton_CheckedChanged;
            // 
            // E0205
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 266);
            Controls.Add(labelMessage);
            Controls.Add(label1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "E0205";
            Text = "FormE0205";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelMessage;
        private Label label1;
        private GroupBox groupBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBoxAll;
        private CheckBox checkBox1;
        private GroupBox groupBox1;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Panel panel1;
    }
}