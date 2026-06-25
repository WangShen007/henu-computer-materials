namespace ClientWinFormsExamples.ch07.E06
{
    partial class TextDialog
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            buttonOK = new Button();
            buttonTextColor = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // buttonOK
            // 
            buttonOK.DialogResult = DialogResult.OK;
            buttonOK.Location = new Point(68, 96);
            buttonOK.Margin = new Padding(4);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(76, 30);
            buttonOK.TabIndex = 9;
            buttonOK.Text = "确定";
            buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonTextColor
            // 
            buttonTextColor.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonTextColor.Location = new Point(218, 26);
            buttonTextColor.Margin = new Padding(4);
            buttonTextColor.Name = "buttonTextColor";
            buttonTextColor.Size = new Size(97, 33);
            buttonTextColor.TabIndex = 8;
            buttonTextColor.Text = "文字颜色";
            buttonTextColor.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonTextColor.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(62, 28);
            textBox1.Margin = new Padding(4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(142, 23);
            textBox1.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 35);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(35, 17);
            label1.TabIndex = 6;
            label1.Text = "文字:";
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = DialogResult.OK;
            buttonCancel.Location = new Point(184, 96);
            buttonCancel.Margin = new Padding(4);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(76, 30);
            buttonCancel.TabIndex = 9;
            buttonCancel.Text = "取消";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // TextDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(331, 147);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(buttonTextColor);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Margin = new Padding(4);
            Name = "TextDialog";
            Text = "文字信息";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonOK;
        private Button buttonTextColor;
        private TextBox textBox1;
        private Label label1;
        private Button buttonCancel;
    }
}