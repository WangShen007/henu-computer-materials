namespace _2210050000_name_lab04
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataStudent = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ageDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            gradeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            studentBindingSource = new BindingSource(components);
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            txtName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtAge = new TextBox();
            label3 = new Label();
            txtGrade = new TextBox();
            ((System.ComponentModel.ISupportInitialize)DataStudent).BeginInit();
            ((System.ComponentModel.ISupportInitialize)studentBindingSource).BeginInit();
            SuspendLayout();
            // 
            // DataStudent
            // 
            DataStudent.AllowUserToOrderColumns = true;
            DataStudent.AutoGenerateColumns = false;
            DataStudent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataStudent.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, ageDataGridViewTextBoxColumn, gradeDataGridViewTextBoxColumn });
            DataStudent.DataSource = studentBindingSource;
            DataStudent.Location = new Point(12, 12);
            DataStudent.Name = "DataStudent";
            DataStudent.RowHeadersWidth = 62;
            DataStudent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataStudent.Size = new Size(776, 225);
            DataStudent.TabIndex = 0;
            DataStudent.SelectionChanged += DataStudent_SelectionChanged;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 8;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.Visible = false;
            idDataGridViewTextBoxColumn.Width = 150;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            dataGridViewCellStyle7.BackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle7.ForeColor = Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = Color.Blue;
            dataGridViewCellStyle7.SelectionForeColor = Color.White;
            nameDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            nameDataGridViewTextBoxColumn.HeaderText = "名字";
            nameDataGridViewTextBoxColumn.MinimumWidth = 8;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.Width = 150;
            // 
            // ageDataGridViewTextBoxColumn
            // 
            ageDataGridViewTextBoxColumn.DataPropertyName = "Age";
            dataGridViewCellStyle8.BackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = Color.Blue;
            ageDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            ageDataGridViewTextBoxColumn.HeaderText = "年龄";
            ageDataGridViewTextBoxColumn.MinimumWidth = 8;
            ageDataGridViewTextBoxColumn.Name = "ageDataGridViewTextBoxColumn";
            ageDataGridViewTextBoxColumn.Width = 150;
            // 
            // gradeDataGridViewTextBoxColumn
            // 
            gradeDataGridViewTextBoxColumn.DataPropertyName = "Grade";
            dataGridViewCellStyle9.BackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle9.ForeColor = Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = Color.Blue;
            gradeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            gradeDataGridViewTextBoxColumn.HeaderText = "成绩";
            gradeDataGridViewTextBoxColumn.MinimumWidth = 8;
            gradeDataGridViewTextBoxColumn.Name = "gradeDataGridViewTextBoxColumn";
            gradeDataGridViewTextBoxColumn.Width = 150;
            // 
            // studentBindingSource
            // 
            studentBindingSource.DataSource = typeof(Models.Student);
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(29, 386);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "增加";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(189, 386);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 34);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "更改";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(345, 386);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "删除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(78, 267);
            txtName.Name = "txtName";
            txtName.Size = new Size(150, 30);
            txtName.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 273);
            label1.Name = "label1";
            label1.Size = new Size(46, 24);
            label1.TabIndex = 5;
            label1.Text = "姓名";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(293, 273);
            label2.Name = "label2";
            label2.Size = new Size(46, 24);
            label2.TabIndex = 7;
            label2.Text = "年龄";
            // 
            // txtAge
            // 
            txtAge.Location = new Point(345, 267);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(150, 30);
            txtAge.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(558, 273);
            label3.Name = "label3";
            label3.Size = new Size(46, 24);
            label3.TabIndex = 9;
            label3.Text = "成绩";
            // 
            // txtGrade
            // 
            txtGrade.Location = new Point(610, 267);
            txtGrade.Name = "txtGrade";
            txtGrade.Size = new Size(150, 30);
            txtGrade.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(txtGrade);
            Controls.Add(label2);
            Controls.Add(txtAge);
            Controls.Add(label1);
            Controls.Add(txtName);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(DataStudent);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)DataStudent).EndInit();
            ((System.ComponentModel.ISupportInitialize)studentBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DataStudent;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private TextBox txtName;
        private Label label1;
        private Label label2;
        private TextBox txtAge;
        private Label label3;
        private TextBox txtGrade;
        private BindingSource studentBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn gradeDataGridViewTextBoxColumn;
    }
}
