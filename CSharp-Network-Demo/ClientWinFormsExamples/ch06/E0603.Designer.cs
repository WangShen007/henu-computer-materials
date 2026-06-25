namespace ClientWinFormsExamples.ch06
{
    partial class E0603
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
            listBox1 = new ListBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 17;
            listBox1.Location = new Point(25, 17);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(752, 208);
            listBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(349, 239);
            button1.Name = "button1";
            button1.Size = new Size(146, 23);
            button1.TabIndex = 1;
            button1.Text = "开始自动随机取款";
            button1.UseVisualStyleBackColor = true;
            // 
            // E0603
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 272);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Name = "E0603";
            Text = "E0603";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private Button button1;
    }
}