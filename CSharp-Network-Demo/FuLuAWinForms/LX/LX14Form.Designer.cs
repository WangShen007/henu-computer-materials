namespace FuLuAWinForms
{
    partial class LX14Form
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
            txtId = new TextBox();
            label2 = new Label();
            txtName = new TextBox();
            label3 = new Label();
            txtAge = new TextBox();
            btnShowInfo = new Button();
            labelInfo = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(83, 32);
            label1.Name = "label1";
            label1.Size = new Size(32, 17);
            label1.TabIndex = 0;
            label1.Text = "学号";
            // 
            // txtId
            // 
            txtId.Location = new Point(140, 29);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(83, 75);
            label2.Name = "label2";
            label2.Size = new Size(32, 17);
            label2.TabIndex = 0;
            label2.Text = "姓名";
            // 
            // txtName
            // 
            txtName.Location = new Point(140, 72);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(83, 120);
            label3.Name = "label3";
            label3.Size = new Size(32, 17);
            label3.TabIndex = 0;
            label3.Text = "成绩";
            // 
            // txtAge
            // 
            txtAge.Location = new Point(140, 117);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(100, 23);
            txtAge.TabIndex = 2;
            // 
            // btnShowInfo
            // 
            btnShowInfo.Location = new Point(120, 160);
            btnShowInfo.Name = "btnShowInfo";
            btnShowInfo.Size = new Size(75, 23);
            btnShowInfo.TabIndex = 3;
            btnShowInfo.Text = "确定";
            btnShowInfo.UseVisualStyleBackColor = true;
            // 
            // labelInfo
            // 
            labelInfo.BorderStyle = BorderStyle.FixedSingle;
            labelInfo.Location = new Point(12, 199);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(299, 23);
            labelInfo.TabIndex = 4;
            labelInfo.Text = "labelInfo";
            // 
            // LX14Form
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(323, 234);
            Controls.Add(labelInfo);
            Controls.Add(btnShowInfo);
            Controls.Add(txtAge);
            Controls.Add(label3);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(txtId);
            Controls.Add(label1);
            Name = "LX14Form";
            Text = "LX14Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtId;
        private Label label2;
        private TextBox txtName;
        private Label label3;
        private TextBox txtAge;
        private Button btnShowInfo;
        private Label labelInfo;
    }
}