namespace _2210050000_name_lab05
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
            lstResults = new ListBox();
            label2 = new Label();
            txtPrefix = new TextBox();
            nudStart = new NumericUpDown();
            nudEnd = new NumericUpDown();
            label3 = new Label();
            label4 = new Label();
            btnScanSingle = new Button();
            btnScanMulti = new Button();
            lblError = new Label();
            lblStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)nudStart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudEnd).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(152, 24);
            label1.TabIndex = 0;
            label1.Text = "扫描的IP地址范围";
            // 
            // lstResults
            // 
            lstResults.FormattingEnabled = true;
            lstResults.ItemHeight = 24;
            lstResults.Location = new Point(12, 232);
            lstResults.Name = "lstResults";
            lstResults.Size = new Size(776, 196);
            lstResults.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 49);
            label2.Name = "label2";
            label2.Size = new Size(82, 24);
            label2.TabIndex = 2;
            label2.Text = "地址前缀";
            // 
            // txtPrefix
            // 
            txtPrefix.Location = new Point(106, 49);
            txtPrefix.Name = "txtPrefix";
            txtPrefix.Size = new Size(150, 30);
            txtPrefix.TabIndex = 3;
            txtPrefix.Text = "192.168.1";
            // 
            // nudStart
            // 
            nudStart.Location = new Point(375, 47);
            nudStart.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            nudStart.Name = "nudStart";
            nudStart.Size = new Size(108, 30);
            nudStart.TabIndex = 4;
            nudStart.Value = new decimal(new int[] { 102, 0, 0, 0 });
            // 
            // nudEnd
            // 
            nudEnd.Location = new Point(604, 47);
            nudEnd.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            nudEnd.Name = "nudEnd";
            nudEnd.Size = new Size(108, 30);
            nudEnd.TabIndex = 5;
            nudEnd.Value = new decimal(new int[] { 105, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(296, 49);
            label3.Name = "label3";
            label3.Size = new Size(64, 24);
            label3.TabIndex = 6;
            label3.Text = "起始值";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(534, 49);
            label4.Name = "label4";
            label4.Size = new Size(64, 24);
            label4.TabIndex = 7;
            label4.Text = "终止值";
            // 
            // btnScanSingle
            // 
            btnScanSingle.Location = new Point(641, 107);
            btnScanSingle.Name = "btnScanSingle";
            btnScanSingle.Size = new Size(112, 34);
            btnScanSingle.TabIndex = 8;
            btnScanSingle.Text = "单线程扫描";
            btnScanSingle.UseVisualStyleBackColor = true;
            btnScanSingle.Click += btnScanSingle_Click;
            // 
            // btnScanMulti
            // 
            btnScanMulti.Location = new Point(641, 162);
            btnScanMulti.Name = "btnScanMulti";
            btnScanMulti.Size = new Size(112, 34);
            btnScanMulti.TabIndex = 9;
            btnScanMulti.Text = "多线程扫描";
            btnScanMulti.UseVisualStyleBackColor = true;
            btnScanMulti.Click += btnScanMulti_Click;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.BackColor = Color.Red;
            lblError.ForeColor = Color.White;
            lblError.Location = new Point(12, 162);
            lblError.Name = "lblError";
            lblError.Size = new Size(63, 24);
            lblError.TabIndex = 10;
            lblError.Text = "label5";
            lblError.Visible = false;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(18, 107);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(63, 24);
            lblStatus.TabIndex = 11;
            lblStatus.Text = "label5";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblStatus);
            Controls.Add(lblError);
            Controls.Add(btnScanMulti);
            Controls.Add(btnScanSingle);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(nudEnd);
            Controls.Add(nudStart);
            Controls.Add(txtPrefix);
            Controls.Add(label2);
            Controls.Add(lstResults);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)nudStart).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudEnd).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox lstResults;
        private Label label2;
        private TextBox txtPrefix;
        private NumericUpDown nudStart;
        private NumericUpDown nudEnd;
        private Label label3;
        private Label label4;
        private Button btnScanSingle;
        private Button btnScanMulti;
        private Label lblError;
        private Label lblStatus;
    }
}
