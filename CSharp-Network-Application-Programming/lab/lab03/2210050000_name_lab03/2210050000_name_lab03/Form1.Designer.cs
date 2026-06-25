namespace _2210050000_name_lab03
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
            openFileDialog = new OpenFileDialog();
            openFiletxt = new Button();
            openFileAll = new Button();
            showFile = new TextBox();
            SuspendLayout();
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            // 
            // openFiletxt
            // 
            openFiletxt.Location = new Point(12, 12);
            openFiletxt.Name = "openFiletxt";
            openFiletxt.Size = new Size(197, 34);
            openFiletxt.TabIndex = 0;
            openFiletxt.Text = "打开并拷贝文件(txt)";
            openFiletxt.UseVisualStyleBackColor = true;
            openFiletxt.Click += openFiletxt_Click;
            // 
            // openFileAll
            // 
            openFileAll.Location = new Point(286, 12);
            openFileAll.Name = "openFileAll";
            openFileAll.Size = new Size(197, 34);
            openFileAll.TabIndex = 0;
            openFileAll.Text = "拷贝文件(all)";
            openFileAll.UseVisualStyleBackColor = true;
            openFileAll.Click += openFileAll_Click;
            // 
            // showFile
            // 
            showFile.Location = new Point(12, 72);
            showFile.Multiline = true;
            showFile.Name = "showFile";
            showFile.Size = new Size(500, 274);
            showFile.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(showFile);
            Controls.Add(openFileAll);
            Controls.Add(openFiletxt);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog;
        private Button openFiletxt;
        private Button openFileAll;
        private TextBox showFile;
    }
}
