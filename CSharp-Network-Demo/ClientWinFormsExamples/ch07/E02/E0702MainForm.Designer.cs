namespace ClientWinFormsExamples.ch07.E02
{
    partial class E0702MainForm
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
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            buttonOK = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(31, 25);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(336, 78);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            groupBox1.Text = "聊天方式";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Checked = true;
            radioButton2.Location = new Point(107, 40);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(194, 21);
            radioButton2.TabIndex = 0;
            radioButton2.TabStop = true;
            radioButton2.Text = "调试（同一人操作两个客户端）";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(17, 40);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(50, 21);
            radioButton1.TabIndex = 0;
            radioButton1.Text = "实聊";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(407, 53);
            buttonOK.Margin = new Padding(4);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(86, 33);
            buttonOK.TabIndex = 22;
            buttonOK.Text = "确定";
            buttonOK.UseVisualStyleBackColor = true;
            // 
            // E0702Main
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(555, 135);
            Controls.Add(groupBox1);
            Controls.Add(buttonOK);
            Name = "E0702Main";
            Text = "E0702Main";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button buttonOK;
    }
}