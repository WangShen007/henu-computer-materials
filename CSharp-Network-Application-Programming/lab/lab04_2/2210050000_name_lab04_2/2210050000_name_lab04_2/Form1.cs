using System.Diagnostics;

namespace _2210050000_name_lab04_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Loaded;//不知道为什么不能直接写+=Refresh
        }


        private void btnCloseProcess_Click(object sender, EventArgs e)
        {
            if (listViewProcesses.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择一个进程.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int pid = (int)listViewProcesses.SelectedItems[0].Tag;
                Process process = Process.GetProcessById(pid);
                process.Kill();
                MessageBox.Show("进程成功的被删除了.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshProcessList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"没有成功删除进程: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpenProcess_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = openFileDialog.FileName,
                        UseShellExecute = true
                    };
                    Process.Start(startInfo);
                    MessageBox.Show("启动成功.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshProcessList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"启动失败: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void listViewProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCloseProcess.Enabled = listViewProcesses.SelectedItems.Count > 0;
        }

        private void Loaded(object sender, EventArgs e)
        {
            RefreshProcessList();
        }

        private void RefreshProcessList()
        {
            listViewProcesses.Items.Clear();
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                try
                {
                    string processName = process.ProcessName;
                    string memoryInfo = (process.WorkingSet64 / 1024 / 1024).ToString("N0");

                    ListViewItem item = new ListViewItem(process.Id.ToString());
                    item.SubItems.Add(processName);
                    item.SubItems.Add(memoryInfo);
                    item.Tag = process.Id;
                    listViewProcesses.Items.Add(item);

                    Console.WriteLine($"进程ID: {process.Id}, 名字: {processName}, 内存: {memoryInfo}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"失败: {ex.Message}");
                }
            }

            listViewProcesses.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshProcessList();
        }
    }
}
