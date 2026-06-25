namespace _2210050000_name_lab04_2
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
            listViewProcesses = new ListView();
            PID = new ColumnHeader();
            PName = new ColumnHeader();
            Pmemory = new ColumnHeader();
            btnCloseProcess = new Button();
            btnOpenProcess = new Button();
            openFileDialog = new OpenFileDialog();
            btnRefresh = new Button();
            SuspendLayout();
            // 
            // listViewProcesses
            // 
            listViewProcesses.Columns.AddRange(new ColumnHeader[] { PID, PName, Pmemory });
            listViewProcesses.FullRowSelect = true;
            listViewProcesses.Location = new Point(12, 12);
            listViewProcesses.Name = "listViewProcesses";
            listViewProcesses.Size = new Size(776, 333);
            listViewProcesses.TabIndex = 0;
            listViewProcesses.UseCompatibleStateImageBehavior = false;
            listViewProcesses.View = View.Details;
            listViewProcesses.SelectedIndexChanged += listViewProcesses_SelectedIndexChanged;
            // 
            // PID
            // 
            PID.Text = "进程ID";
            // 
            // PName
            // 
            PName.Text = "进程名字";
            // 
            // Pmemory
            // 
            Pmemory.Text = "内存占用(MB)";
            // 
            // btnCloseProcess
            // 
            btnCloseProcess.Location = new Point(37, 372);
            btnCloseProcess.Name = "btnCloseProcess";
            btnCloseProcess.Size = new Size(112, 34);
            btnCloseProcess.TabIndex = 1;
            btnCloseProcess.Text = "关闭进程";
            btnCloseProcess.UseVisualStyleBackColor = true;
            btnCloseProcess.Click += btnCloseProcess_Click;
            // 
            // btnOpenProcess
            // 
            btnOpenProcess.Location = new Point(203, 372);
            btnOpenProcess.Name = "btnOpenProcess";
            btnOpenProcess.Size = new Size(112, 34);
            btnOpenProcess.TabIndex = 2;
            btnOpenProcess.Text = "启动进程";
            btnOpenProcess.UseVisualStyleBackColor = true;
            btnOpenProcess.Click += btnOpenProcess_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(370, 372);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(392, 34);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "刷新进程(打开新的进程后请点击这个)";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRefresh);
            Controls.Add(btnOpenProcess);
            Controls.Add(btnCloseProcess);
            Controls.Add(listViewProcesses);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private ListView listViewProcesses;
        private Button btnCloseProcess;
        private Button btnOpenProcess;
        private OpenFileDialog openFileDialog;
        private ColumnHeader PID;
        private ColumnHeader PName;
        private ColumnHeader Pmemory;
        private Button btnRefresh;
    }
}
