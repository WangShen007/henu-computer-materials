using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2210050000_name_lab05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lblError.Visible = false;
            lstResults.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private bool ValidateInput(out string prefix, out int start, out int end)
        {
            prefix = txtPrefix.Text.Trim();
            start = (int)nudStart.Value;
            end = (int)nudEnd.Value;

            lblError.Visible = false;

            // 验证前缀
            var parts = prefix.Split('.');
            if (string.IsNullOrWhiteSpace(prefix) || prefix.EndsWith(".") || parts.Length < 3 || parts.Length > 3)
            {
                ShowError("IP 地址前缀格式错误 (应类似 192.168.1)");
                return false;
            }
            foreach (var part in parts)
            {
                if (!byte.TryParse(part, out _))
                {
                    ShowError($"IP 地址前缀部分 '{part}' 无效");
                    return false;
                }
            }


            if (start > end)
            {
                ShowError("起始值不能大于终止值");
                return false;
            }
            if (start < 0 || start > 255 || end < 0 || end > 255)
            {
                ShowError("起始值和终止值必须在 0-255 之间");
                return false;
            }


            if (!prefix.EndsWith("."))
            {
                prefix += ".";
            }


            return true;
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }

        // --- 核心扫描逻辑 (单个IP) ---
        private string PerformScan(string ipAddress)
        {
            Stopwatch sw = Stopwatch.StartNew();
            string hostName = "(不在线)";
            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(ipAddress);
                hostName = hostEntry.HostName;
                if (hostName == ipAddress)
                {
                    // hostName = "(无主机名记录)";
                }
            }
            catch (SocketException ex)
            {
                hostName = $"(不在线 - {ex.SocketErrorCode})";
            }
            catch (Exception ex)
            {
                hostName = $"(错误: {ex.GetType().Name})";
            }
            finally
            {
                sw.Stop();
            }

            // PadRight 用于对齐
            return $"{ipAddress.PadRight(16)}\t耗时: {sw.ElapsedMilliseconds.ToString().PadLeft(5)} ms\t主机名: {hostName}";
        }

        private void UpdateResults(string result)
        {
            if (lstResults.InvokeRequired)
            {
                lstResults.BeginInvoke(new Action(() => lstResults.Items.Add(result)));
            }
            else
            {
                lstResults.Items.Add(result);
            }
        }

        private void UpdateStatus(string status)
        {
            if (lblStatus.InvokeRequired)
            {
                lblStatus.BeginInvoke(new Action(() => lblStatus.Text = status));
            }
            else
            {
                lblStatus.Text = status;
            }
        }


        // 单线程扫描
        private void btnScanSingle_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out string prefix, out int start, out int end))
            {
                return;
            }

            lstResults.Items.Clear(); 
            UpdateStatus("正在单线程扫描...");
            Application.DoEvents(); 

            Stopwatch totalSw = Stopwatch.StartNew();
            int count = 0;

            for (int i = start; i <= end; i++)
            {
                string currentIp = prefix + i.ToString();
                string result = PerformScan(currentIp);
                UpdateResults(result);
                count++;
                // Application.DoEvents(); // 频繁调用 DoEvents 会影响性能
            }

            totalSw.Stop();
            UpdateStatus($"单线程扫描完成。扫描了 {count} 个地址，总耗时: {totalSw.ElapsedMilliseconds} ms");
        }

        // --- 多线程扫描按钮事件 (使用 async/await 和 Task.Run) ---
        private async void btnScanMulti_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(out string prefix, out int start, out int end))
            {
                return;
            }

            lstResults.Items.Clear();
            UpdateStatus("正在多线程扫描...");
            Application.DoEvents();

            Stopwatch totalSw = Stopwatch.StartNew();
            List<Task> scanTasks = new List<Task>();
            int count = 0;

            btnScanSingle.Enabled = false;
            btnScanMulti.Enabled = false;

            List<string> ipsToScan = new List<string>();
            for (int i = start; i <= end; i++)
            {
                ipsToScan.Add(prefix + i.ToString());
            }
            count = ipsToScan.Count;


            foreach (string ip in ipsToScan)
            {
                Task task = Task.Run(() => {
                    string result = PerformScan(ip);
                    UpdateResults(result);
                });
                scanTasks.Add(task);
            }

            try
            {
                await Task.WhenAll(scanTasks);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"扫描过程中发生意外错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                totalSw.Stop();
                UpdateStatus($"多线程扫描完成。扫描了 {count} 个地址，总耗时: {totalSw.ElapsedMilliseconds} ms");

                btnScanSingle.Enabled = true;
                btnScanMulti.Enabled = true;
            }
        }
    }
}
