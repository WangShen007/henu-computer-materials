namespace ClientWinFormsExamples.ch08.E03
{
    partial class E0803Broadcast
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
            textBox1 = new TextBox();
            buttonSend = new Button();
            label2 = new Label();
            label1 = new Label();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(309, 59);
            textBox1.Margin = new Padding(4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(251, 23);
            textBox1.TabIndex = 11;
            // 
            // buttonSend
            // 
            buttonSend.Location = new Point(371, 102);
            buttonSend.Margin = new Padding(4);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(112, 33);
            buttonSend.TabIndex = 10;
            buttonSend.Text = "发送";
            buttonSend.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 9);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(92, 17);
            label2.TabIndex = 8;
            label2.Text = "接收的广播信息";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(309, 38);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(116, 17);
            label1.TabIndex = 9;
            label1.Text = "输入发送的广播信息";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 17;
            listBox1.Location = new Point(10, 38);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(269, 123);
            listBox1.TabIndex = 12;
            // 
            // E0803Broadcast
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 177);
            Controls.Add(listBox1);
            Controls.Add(textBox1);
            Controls.Add(buttonSend);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "E0803Broadcast";
            Text = "E0803Broadcast";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private Button buttonSend;
        private Label label2;
        private Label label1;
        private ListBox listBox1;
    }
}