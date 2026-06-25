using System.Data;
using ClientWinFormsExamples.ch05.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientWinFormsExamples.ch05
{
    public partial class E0504 : Form
    {
        public E0504()
        {
            InitializeComponent();
            this.Load += E0504_Load;
        }

        private void E0504_Load(object? sender, EventArgs e)
        {
            //先运行初始化，确保插入、删除成功
            E0502 fm = new E0502();
            fm.ShowDialog();

            //为简单起见，直接执行插入、删除等操作
            using (var c = new MyDb1Context())
            {
                //原始记录
                var q = from t1 in c.KCCJ select t1;
            }
            ShowResult(label1, dataGridView1);

            using (var c = new MyDb1Context())
            {
                //插入记录
                KCCJ cj = new()
                {
                    XueHao = "20230010",
                    KCId = "001",
                    XueNianXueQi = "2023-2024-1",
                    ChengJi = 75,
                };
                c.KCCJ.Add(cj);
                c.SaveChanges();
            }
            ShowResult(label2, dataGridView2);

            using (var c = new MyDb1Context())
            {
                //更新记录
                var q1 = c.KCCJ.FirstOrDefault((t) => t.XueHao == "20230010" && t.KCId == "001");
                if (q1 != null)
                {
                    q1.ChengJi = 70;
                    c.SaveChanges();
                }
            }
            ShowResult(label3, dataGridView3);

            using (var c = new MyDb1Context())
            {
                //删除记录
                var q2 = c.KCCJ.FirstOrDefault((t) => t.KCId == "001" && t.XueHao == "20230010");
                if (q2 != null)
                {
                    c.KCCJ.Remove(q2);
                    c.SaveChanges();
                }
            }
            ShowResult(label4, dataGridView4);
        }
        private static void ShowResult(Label label, DataGridView dataGridView)
        {
            using var c = new MyDb1Context();
            var q = from t1 in c.KCCJ
                    let t = new
                    {
                        学号 = t1.XueHao,
                        学年学期 = t1.XueNianXueQi,
                        课程编码 = t1.KCId,
                        成绩 = t1.ChengJi
                    }
                    select t;
            label.Text += $"（{q.Count()}条）";
            dataGridView.DataSource = q.ToList();
        }
    }
}
