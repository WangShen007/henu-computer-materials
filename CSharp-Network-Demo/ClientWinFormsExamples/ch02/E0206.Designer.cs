namespace ClientWinFormsExamples.ch02
{
    partial class E0206
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
            buttonDelete = new Button();
            buttonDeleteAll = new Button();
            comboBox1 = new ComboBox();
            buttonAdd = new Button();
            groupBox2 = new GroupBox();
            groupBox1 = new GroupBox();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 17;
            listBox1.Location = new Point(16, 30);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(337, 140);
            listBox1.TabIndex = 1;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(386, 57);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(209, 23);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "删除选中的课程";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonDeleteAll
            // 
            buttonDeleteAll.Location = new Point(386, 109);
            buttonDeleteAll.Name = "buttonDeleteAll";
            buttonDeleteAll.Size = new Size(209, 23);
            buttonDeleteAll.TabIndex = 2;
            buttonDeleteAll.Text = "删除全部课程";
            buttonDeleteAll.UseVisualStyleBackColor = true;
            buttonDeleteAll.Click += buttonDeleteAll_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(24, 22);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(335, 25);
            comboBox1.TabIndex = 3;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(431, 22);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(87, 23);
            buttonAdd.TabIndex = 2;
            buttonAdd.Text = "添加";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Controls.Add(buttonAdd);
            groupBox2.Location = new Point(34, 200);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(672, 66);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "添加新课程";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listBox1);
            groupBox1.Controls.Add(buttonDelete);
            groupBox1.Controls.Add(buttonDeleteAll);
            groupBox1.Location = new Point(34, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(672, 182);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "已选修的课程";
            // 
            // E0206
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 269);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "E0206";
            Text = "FormE0206";
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ListBox listBox1;
        private Button buttonDelete;
        private Button buttonDeleteAll;
        private ComboBox comboBox1;
        private Button buttonAdd;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
    }
}