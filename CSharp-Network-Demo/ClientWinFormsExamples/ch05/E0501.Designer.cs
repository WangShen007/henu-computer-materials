namespace ClientWinFormsExamples.ch05
{
    partial class E0501
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
            textBox1 = new TextBox();
            buttonCreate = new Button();
            buttonOpen = new Button();
            buttonSave = new Button();
            textBox2 = new TextBox();
            labelTip = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 21);
            label1.Name = "label1";
            label1.Size = new Size(56, 17);
            label1.TabIndex = 0;
            label1.Text = "文件名：";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(96, 18);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            textBox1.Text = "D:\\D0501.txt";
            // 
            // buttonCreate
            // 
            buttonCreate.Location = new Point(222, 18);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(75, 23);
            buttonCreate.TabIndex = 2;
            buttonCreate.Text = "创建文件";
            buttonCreate.UseVisualStyleBackColor = true;
            // 
            // buttonOpen
            // 
            buttonOpen.Location = new Point(321, 18);
            buttonOpen.Name = "buttonOpen";
            buttonOpen.Size = new Size(75, 23);
            buttonOpen.TabIndex = 3;
            buttonOpen.Text = "打开文件";
            buttonOpen.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(426, 18);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "保存文件";
            buttonSave.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(34, 57);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(467, 137);
            textBox2.TabIndex = 5;
            // 
            // labelTip
            // 
            labelTip.AutoSize = true;
            labelTip.Location = new Point(89, 203);
            labelTip.Name = "labelTip";
            labelTip.Size = new Size(44, 17);
            labelTip.TabIndex = 6;
            labelTip.Text = "提示：";
            // 
            // E0501
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 239);
            Controls.Add(labelTip);
            Controls.Add(textBox2);
            Controls.Add(buttonSave);
            Controls.Add(buttonOpen);
            Controls.Add(buttonCreate);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "E0501";
            Text = "【例5-1】文本文件读写";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button buttonCreate;
        private Button buttonOpen;
        private Button buttonSave;
        private TextBox textBox2;
        private Label labelTip;
    }
}