namespace ClientWinFormsExamples.ch07.E04
{
    partial class E0704MainForm
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
            panel1 = new Panel();
            listBox1 = new ListBox();
            btnClear = new Button();
            label1 = new Label();
            groupBox1 = new GroupBox();
            radioButtonEllipse = new RadioButton();
            radioButtonRectangle = new RadioButton();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(163, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(413, 246);
            panel1.TabIndex = 0;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 17;
            listBox1.Location = new Point(594, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(163, 208);
            listBox1.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(638, 235);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 2;
            btnClear.Text = "清除";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Location = new Point(12, 276);
            label1.Name = "label1";
            label1.Size = new Size(745, 23);
            label1.TabIndex = 3;
            label1.Text = "提示：先分别选择绘制类型，然后在Panel中按住鼠标左键拖动鼠标绘制。绘制完成后，在ListBox中单击不同对象观察绘制的是哪个对象。";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButtonEllipse);
            groupBox1.Controls.Add(radioButtonRectangle);
            groupBox1.Location = new Point(23, 55);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(120, 141);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "绘制类型";
            // 
            // radioButtonEllipse
            // 
            radioButtonEllipse.AutoSize = true;
            radioButtonEllipse.Location = new Point(26, 78);
            radioButtonEllipse.Name = "radioButtonEllipse";
            radioButtonEllipse.Size = new Size(50, 21);
            radioButtonEllipse.TabIndex = 6;
            radioButtonEllipse.Text = "椭圆";
            radioButtonEllipse.UseVisualStyleBackColor = true;
            // 
            // radioButtonRectangle
            // 
            radioButtonRectangle.AutoSize = true;
            radioButtonRectangle.Checked = true;
            radioButtonRectangle.Location = new Point(26, 39);
            radioButtonRectangle.Name = "radioButtonRectangle";
            radioButtonRectangle.Size = new Size(50, 21);
            radioButtonRectangle.TabIndex = 6;
            radioButtonRectangle.TabStop = true;
            radioButtonRectangle.Text = "矩形";
            radioButtonRectangle.UseVisualStyleBackColor = true;
            // 
            // E0901Main
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(786, 310);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(btnClear);
            Controls.Add(listBox1);
            Controls.Add(panel1);
            Name = "E0901Main";
            Text = "例9-1 （封装不彻底的例子。请思考：哪些地方需要进一步封装？）";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ListBox listBox1;
        private Button btnClear;
        private Label label1;
        private GroupBox groupBox1;
        private RadioButton radioButtonEllipse;
        private RadioButton radioButtonRectangle;
    }
}