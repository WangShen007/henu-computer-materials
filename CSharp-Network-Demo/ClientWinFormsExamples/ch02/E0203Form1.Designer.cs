namespace ClientWinFormsExamples.ch02
{
    partial class E0203Form1
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
            buttonOK = new Button();
            textBoxPwd = new TextBox();
            textBoxUserName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // buttonOK
            // 
            buttonOK.Anchor = AnchorStyles.Bottom;
            buttonOK.Location = new Point(82, 117);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(81, 25);
            buttonOK.TabIndex = 10;
            buttonOK.Text = "确定";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // textBoxPwd
            // 
            textBoxPwd.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxPwd.Location = new Point(74, 74);
            textBoxPwd.Name = "textBoxPwd";
            textBoxPwd.PasswordChar = '*';
            textBoxPwd.Size = new Size(172, 23);
            textBoxPwd.TabIndex = 8;
            // 
            // textBoxUserName
            // 
            textBoxUserName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxUserName.Location = new Point(74, 31);
            textBoxUserName.Name = "textBoxUserName";
            textBoxUserName.Size = new Size(172, 23);
            textBoxUserName.TabIndex = 9;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(25, 77);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 6;
            label2.Text = "密码：";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(14, 31);
            label1.Name = "label1";
            label1.Size = new Size(56, 17);
            label1.TabIndex = 7;
            label1.Text = "用户名：";
            // 
            // E0203Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(265, 147);
            Controls.Add(buttonOK);
            Controls.Add(textBoxPwd);
            Controls.Add(textBoxUserName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "E0203Form1";
            Text = "E0203Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonOK;
        private TextBox textBoxPwd;
        private TextBox textBoxUserName;
        private Label label2;
        private Label label1;
    }
}