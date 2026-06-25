namespace ClientWinFormsExamples.ch02
{
    partial class E0203Form
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
            buttonShow = new Button();
            buttonHide = new Button();
            SuspendLayout();
            // 
            // buttonShow
            // 
            buttonShow.Location = new Point(29, 68);
            buttonShow.Name = "buttonShow";
            buttonShow.Size = new Size(163, 23);
            buttonShow.TabIndex = 0;
            buttonShow.Text = "显示另一个窗体";
            buttonShow.UseVisualStyleBackColor = true;
            buttonShow.Click += buttonShow_Click;
            // 
            // buttonHide
            // 
            buttonHide.Location = new Point(29, 124);
            buttonHide.Name = "buttonHide";
            buttonHide.Size = new Size(163, 23);
            buttonHide.TabIndex = 0;
            buttonHide.Text = "隐藏另一个窗体";
            buttonHide.UseVisualStyleBackColor = true;
            buttonHide.Click += buttonHide_Click;
            // 
            // E0203Form
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(772, 202);
            Controls.Add(buttonHide);
            Controls.Add(buttonShow);
            Name = "E0203Form";
            Text = "E0203Form";
            FormClosing += E0203Form_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private Button buttonShow;
        private Button buttonHide;
    }
}