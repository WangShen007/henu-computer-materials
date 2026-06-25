namespace _2210050000_name
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            Username = new TextBox();
            password = new TextBox();
            Login = new Button();
            label3 = new Label();
            passwordshow = new TextBox();
            exit = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(87, 140);
            label1.Name = "label1";
            label1.Size = new Size(68, 24);
            label1.TabIndex = 0;
            label1.Text = "用户名:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(87, 223);
            label2.Name = "label2";
            label2.Size = new Size(50, 24);
            label2.TabIndex = 0;
            label2.Text = "密码:";
            // 
            // Username
            // 
            Username.Location = new Point(217, 137);
            Username.Name = "Username";
            Username.Size = new Size(150, 30);
            Username.TabIndex = 1;
            // 
            // password
            // 
            password.Location = new Point(217, 223);
            password.Name = "password";
            password.Size = new Size(150, 30);
            password.TabIndex = 1;
            password.TextChanged += password_TextChanged;
            // 
            // Login
            // 
            Login.Location = new Point(217, 298);
            Login.Name = "Login";
            Login.Size = new Size(112, 34);
            Login.TabIndex = 2;
            Login.Text = "登录";
            Login.UseVisualStyleBackColor = true;
            Login.Click += Login_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(64, 382);
            label3.Name = "label3";
            label3.Size = new Size(140, 24);
            label3.TabIndex = 0;
            label3.Text = "你输入的密码是:";
            // 
            // passwordshow
            // 
            passwordshow.Location = new Point(217, 379);
            passwordshow.Name = "passwordshow";
            passwordshow.Size = new Size(150, 30);
            passwordshow.TabIndex = 3;
            // 
            // exit
            // 
            exit.Location = new Point(415, 298);
            exit.Name = "exit";
            exit.Size = new Size(112, 34);
            exit.TabIndex = 4;
            exit.Text = "退出";
            exit.UseVisualStyleBackColor = true;
            exit.Click += exit_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 20F);
            label4.Location = new Point(399, 157);
            label4.Name = "label4";
            label4.Size = new Size(285, 52);
            label4.TabIndex = 0;
            label4.Text = "密码是:sonder";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(800, 450);
            Controls.Add(exit);
            Controls.Add(passwordshow);
            Controls.Add(Login);
            Controls.Add(password);
            Controls.Add(Username);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox Username;
        private TextBox password;
        private Button Login;
        private Label label3;
        private TextBox passwordshow;
        private Button exit;
        private Label label4;
    }
}
