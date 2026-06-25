namespace ClientWinFormsExamples.ch05
{
    partial class E0505
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
            dataGridView1 = new DataGridView();
            button1 = new Button();
            dataGridView2 = new DataGridView();
            textBox1 = new TextBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            labelSql = new Label();
            label1 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            radioButton5 = new RadioButton();
            radioButton4 = new RadioButton();
            radioButton6 = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 30);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(717, 140);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(783, 318);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "开始执行";
            button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(12, 207);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(717, 134);
            dataGridView2.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(34, 155);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(84, 23);
            textBox1.TabIndex = 7;
            textBox1.Text = "张三一";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(13, 57);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(146, 21);
            radioButton1.TabIndex = 8;
            radioButton1.Text = "查询记录（常规查询）";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(13, 93);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(146, 21);
            radioButton2.TabIndex = 9;
            radioButton2.Text = "查询记录（动态查询）";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(13, 198);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(74, 21);
            radioButton3.TabIndex = 10;
            radioButton3.Text = "插入记录";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // labelSql
            // 
            labelSql.AutoSize = true;
            labelSql.Location = new Point(34, 126);
            labelSql.Name = "labelSql";
            labelSql.Size = new Size(116, 17);
            labelSql.TabIndex = 11;
            labelSql.Text = "输入要查询的姓名：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(68, 17);
            label1.TabIndex = 11;
            label1.Text = "原始记录：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 183);
            label2.Name = "label2";
            label2.Size = new Size(68, 17);
            label2.TabIndex = 11;
            label2.Text = "执行结果：";
            // 
            // panel1
            // 
            panel1.Controls.Add(radioButton5);
            panel1.Controls.Add(radioButton4);
            panel1.Controls.Add(radioButton6);
            panel1.Controls.Add(radioButton1);
            panel1.Controls.Add(radioButton2);
            panel1.Controls.Add(radioButton3);
            panel1.Controls.Add(labelSql);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(740, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(160, 286);
            panel1.TabIndex = 12;
            // 
            // radioButton5
            // 
            radioButton5.AutoSize = true;
            radioButton5.Location = new Point(13, 259);
            radioButton5.Name = "radioButton5";
            radioButton5.Size = new Size(74, 21);
            radioButton5.TabIndex = 12;
            radioButton5.Text = "更新记录";
            radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(13, 227);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(74, 21);
            radioButton4.TabIndex = 12;
            radioButton4.Text = "删除记录";
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            radioButton6.AutoSize = true;
            radioButton6.Checked = true;
            radioButton6.Location = new Point(14, 16);
            radioButton6.Name = "radioButton6";
            radioButton6.Size = new Size(86, 21);
            radioButton6.TabIndex = 8;
            radioButton6.Text = "初始化数据";
            radioButton6.UseVisualStyleBackColor = true;
            // 
            // E0505
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 358);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(dataGridView2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "E0505";
            Text = "【例5-5】使用EF Core执行原始SQL命令";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private Button button1;
        private DataGridView dataGridView2;
        private TextBox textBox1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private Label labelSql;
        private Label label1;
        private Label label2;
        private Panel panel1;
        private RadioButton radioButton4;
        private RadioButton radioButton5;
        private RadioButton radioButton6;
    }
}