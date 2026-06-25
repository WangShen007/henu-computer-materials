namespace FuLuAWinForms
{
    partial class LX15Form
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
            textBoxFilePath = new TextBox();
            btnBrower = new Button();
            btnRead = new Button();
            textBox1 = new TextBox();
            btnSave = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 18);
            label1.Name = "label1";
            label1.Size = new Size(68, 17);
            label1.TabIndex = 0;
            label1.Text = "文件路径：";
            // 
            // textBoxFilePath
            // 
            textBoxFilePath.Location = new Point(93, 15);
            textBoxFilePath.Name = "textBoxFilePath";
            textBoxFilePath.Size = new Size(320, 23);
            textBoxFilePath.TabIndex = 1;
            // 
            // btnBrower
            // 
            btnBrower.Location = new Point(434, 15);
            btnBrower.Name = "btnBrower";
            btnBrower.Size = new Size(75, 23);
            btnBrower.TabIndex = 2;
            btnBrower.Text = "浏览";
            btnBrower.UseVisualStyleBackColor = true;
            // 
            // btnRead
            // 
            btnRead.Location = new Point(523, 15);
            btnRead.Name = "btnRead";
            btnRead.Size = new Size(75, 23);
            btnRead.TabIndex = 3;
            btnRead.Text = "读取文件";
            btnRead.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(29, 51);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(552, 186);
            textBox1.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(275, 243);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 5;
            btnSave.Text = "保存文件";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // LX15Form
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 277);
            Controls.Add(btnSave);
            Controls.Add(textBox1);
            Controls.Add(btnRead);
            Controls.Add(btnBrower);
            Controls.Add(textBoxFilePath);
            Controls.Add(label1);
            Name = "LX15Form";
            Text = "LX15Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxFilePath;
        private Button btnBrower;
        private Button btnRead;
        private TextBox textBox1;
        private Button btnSave;
    }
}