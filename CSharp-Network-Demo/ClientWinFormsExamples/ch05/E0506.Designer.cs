using ClientWinFormsExamples.ch05.Models;

namespace ClientWinFormsExamples.ch05
{
    partial class E0506
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            xueHaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            xingMingDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            xingBieDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            chuShengRiQiDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            zhaoPianDataGridViewImageColumn = new DataGridViewImageColumn();
            jBXXBindingSource = new BindingSource(components);
            btnAdd = new Button();
            btnModify = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            btnRemovePhoto = new Button();
            dateTimePicker1 = new DateTimePicker();
            btnImportPhoto = new Button();
            label4 = new Label();
            textBoxGender = new TextBox();
            label3 = new Label();
            textBoxName = new TextBox();
            label2 = new Label();
            textBoxId = new TextBox();
            label1 = new Label();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)jBXXBindingSource).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { xueHaoDataGridViewTextBoxColumn, xingMingDataGridViewTextBoxColumn, xingBieDataGridViewTextBoxColumn, chuShengRiQiDataGridViewTextBoxColumn, zhaoPianDataGridViewImageColumn });
            dataGridView1.DataSource = jBXXBindingSource;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(715, 165);
            dataGridView1.TabIndex = 0;
            // 
            // xueHaoDataGridViewTextBoxColumn
            // 
            xueHaoDataGridViewTextBoxColumn.DataPropertyName = "XueHao";
            xueHaoDataGridViewTextBoxColumn.HeaderText = "学号";
            xueHaoDataGridViewTextBoxColumn.MinimumWidth = 50;
            xueHaoDataGridViewTextBoxColumn.Name = "xueHaoDataGridViewTextBoxColumn";
            xueHaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // xingMingDataGridViewTextBoxColumn
            // 
            xingMingDataGridViewTextBoxColumn.DataPropertyName = "XingMing";
            xingMingDataGridViewTextBoxColumn.HeaderText = "姓名";
            xingMingDataGridViewTextBoxColumn.Name = "xingMingDataGridViewTextBoxColumn";
            xingMingDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // xingBieDataGridViewTextBoxColumn
            // 
            xingBieDataGridViewTextBoxColumn.DataPropertyName = "XingBie";
            xingBieDataGridViewTextBoxColumn.HeaderText = "性别";
            xingBieDataGridViewTextBoxColumn.Name = "xingBieDataGridViewTextBoxColumn";
            xingBieDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // chuShengRiQiDataGridViewTextBoxColumn
            // 
            chuShengRiQiDataGridViewTextBoxColumn.DataPropertyName = "ChuShengRiQi";
            dataGridViewCellStyle1.Format = "yyyy-MM-dd";
            dataGridViewCellStyle1.NullValue = null;
            chuShengRiQiDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            chuShengRiQiDataGridViewTextBoxColumn.HeaderText = "出生日期";
            chuShengRiQiDataGridViewTextBoxColumn.Name = "chuShengRiQiDataGridViewTextBoxColumn";
            chuShengRiQiDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // zhaoPianDataGridViewImageColumn
            // 
            zhaoPianDataGridViewImageColumn.DataPropertyName = "ZhaoPian";
            zhaoPianDataGridViewImageColumn.HeaderText = "照片";
            zhaoPianDataGridViewImageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            zhaoPianDataGridViewImageColumn.MinimumWidth = 50;
            zhaoPianDataGridViewImageColumn.Name = "zhaoPianDataGridViewImageColumn";
            zhaoPianDataGridViewImageColumn.ReadOnly = true;
            // 
            // jBXXBindingSource
            // 
            jBXXBindingSource.DataSource = typeof(JBXX);
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(49, 211);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "添加";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnModify
            // 
            btnModify.Location = new Point(49, 255);
            btnModify.Name = "btnModify";
            btnModify.Size = new Size(75, 23);
            btnModify.TabIndex = 1;
            btnModify.Text = "修改";
            btnModify.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btnRemovePhoto);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(btnImportPhoto);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBoxGender);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBoxName);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBoxId);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(141, 188);
            panel1.Name = "panel1";
            panel1.Size = new Size(510, 173);
            panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(225, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 150);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // btnRemovePhoto
            // 
            btnRemovePhoto.Location = new Point(405, 108);
            btnRemovePhoto.Name = "btnRemovePhoto";
            btnRemovePhoto.Size = new Size(75, 23);
            btnRemovePhoto.TabIndex = 1;
            btnRemovePhoto.Text = "移除照片";
            btnRemovePhoto.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(80, 132);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(121, 23);
            dateTimePicker1.TabIndex = 2;
            dateTimePicker1.Value = new DateTime(2005, 10, 15, 0, 0, 0, 0);
            // 
            // btnImportPhoto
            // 
            btnImportPhoto.Location = new Point(405, 46);
            btnImportPhoto.Name = "btnImportPhoto";
            btnImportPhoto.Size = new Size(75, 23);
            btnImportPhoto.TabIndex = 1;
            btnImportPhoto.Text = "导入照片";
            btnImportPhoto.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 138);
            label4.Name = "label4";
            label4.Size = new Size(68, 17);
            label4.TabIndex = 0;
            label4.Text = "出生日期：";
            // 
            // textBoxGender
            // 
            textBoxGender.Location = new Point(80, 93);
            textBoxGender.Name = "textBoxGender";
            textBoxGender.Size = new Size(121, 23);
            textBoxGender.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 95);
            label3.Name = "label3";
            label3.Size = new Size(44, 17);
            label3.TabIndex = 0;
            label3.Text = "性别：";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(80, 50);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(121, 23);
            textBoxName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 52);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 0;
            label2.Text = "姓名：";
            // 
            // textBoxId
            // 
            textBoxId.Location = new Point(80, 12);
            textBoxId.Name = "textBoxId";
            textBoxId.Size = new Size(121, 23);
            textBoxId.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 14);
            label1.Name = "label1";
            label1.Size = new Size(44, 17);
            label1.TabIndex = 0;
            label1.Text = "学号：";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(49, 298);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "删除";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // E0506
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(739, 367);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(btnModify);
            Name = "E0506";
            Text = "【例5-6】综合示例";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)jBXXBindingSource).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnAdd;
        private Button btnModify;
        private Panel panel1;
        private Label label4;
        private TextBox textBoxGender;
        private Label label3;
        private TextBox textBoxName;
        private Label label2;
        private TextBox textBoxId;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private Button btnDelete;
        private Button btnRemovePhoto;
        private Button btnImportPhoto;
        private PictureBox pictureBox1;
        private BindingSource jBXXBindingSource;
        private DataGridViewTextBoxColumn xueHaoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn xingMingDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn xingBieDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn chuShengRiQiDataGridViewTextBoxColumn;
        private DataGridViewImageColumn zhaoPianDataGridViewImageColumn;
    }
}