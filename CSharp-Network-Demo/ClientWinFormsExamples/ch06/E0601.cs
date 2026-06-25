using System.Diagnostics;

namespace ClientWinFormsExamples.ch06
{
    public partial class E0601 : Form
    {
        Process[]? myProcess;
        public E0601()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.MultiSelect = false;
            dataGridView1.MouseClick += DataGridView1_MouseClick;
            this.Load += E0601_Load;
        }
        private void DataGridView1_MouseClick(object? sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo h = dataGridView1.HitTest(e.X, e.Y);
            if (h.Type == DataGridViewHitTestType.Cell ||
                      h.Type == DataGridViewHitTestType.RowHeader)
            {
                dataGridView1.Rows[h.RowIndex].Selected = true;
                int processeId = (int)dataGridView1.CurrentRow.Cells[0].Value;
                ShowProcessInfo(Process.GetProcessById(processeId));
            }
        }

        private void E0601_Load(object? sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            myProcess = Process.GetProcesses();
            foreach (Process p in myProcess)
            {
                int newRowIndex = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[newRowIndex];
                row.Cells[0].Value = p.Id;
                row.Cells[1].Value = p.ProcessName;
                row.Cells[2].Value = string.Format("{0:###,##0.00}MB",
                      p.WorkingSet64 / 1024.0f / 1024.0f);
                //有些进程无法获取启动时间和文件名信息，所以要用try/catch
                try
                {
                    row.Cells[3].Value = string.Format("{0}", p.StartTime);
                    if(p.MainModule != null)
                    {
                        row.Cells[4].Value = p.MainModule.FileName;
                    }
                }
                catch
                {
                    row.Cells[3].Value = "";
                    row.Cells[4].Value = "";
                }
            }
        }
        private void ShowProcessInfo(Process p)
        {
            //StringBuilder sb = new StringBuilder();
            listBox1.Items.Add($"进程名称：{p.ProcessName}，  ID：{p.Id}");
            try
            {
                listBox1.Items.Add($"进程优先级：{p.BasePriority} （优先级类别：{p.PriorityClass}）");
                ProcessModule? m = p.MainModule;
                if (m != null)
                {
                    listBox1.Items.Add($"文件名：{m.FileName}");
                    listBox1.Items.Add($"版本：{m.FileVersionInfo.FileVersion}");
                    listBox1.Items.Add($"描述：{m.FileVersionInfo.FileDescription}");
                    listBox1.Items.Add($"语言：{m.FileVersionInfo.Language}");
                    listBox1.Items.Add("------------------------");
                }
                if (p.Modules != null)
                {
                    ProcessModuleCollection pmc = p.Modules;
                    listBox1.Items.Add("调用的模块(.dll)：");
                    for (int i = 1; i < pmc.Count; i++)
                    {
                        listBox1.Items.Add(
                            "模块名：" + pmc[i].ModuleName + "  " +
                            "版本：" + pmc[i].FileVersionInfo.FileVersion + "  " +
                            "描述：" + pmc[i].FileVersionInfo.FileDescription);
                    }
                }
            }
            catch
            {
                listBox1.Items.Add("其他信息：无法获取");
            }
        }
    }
}
