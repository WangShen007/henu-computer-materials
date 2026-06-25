using Microsoft.EntityFrameworkCore;
using ClientWinFormsExamples.ch05.Models;

namespace ClientWinFormsExamples.ch05
{
    public partial class E0505 : Form
    {
        public E0505()
        {
            InitializeComponent();
            button1.Click += Button1_Click;
        }

        private void Button1_Click(object? sender, EventArgs e)
        {
            foreach (var v in panel1.Controls)
            {
                if (v is RadioButton r)
                {
                    //以下示例适用于EF Core 7.0及更高版本
                    var s = r.Checked ? r.Text : "";
                    switch (s)
                    {
                        case "初始化数据":
                            //由于例子只是为了演示SQL用法，所以运行前先做一次初始化，以方便观察执行结果
                            var fm = new E0502();
                            fm.ShowDialog();
                            break;
                        case "查询记录（常规查询）":
                            using (MyDb1Context c = new())
                            {
                                dataGridView1.DataSource = c.JBXX.ToList();
                                label1.Text = $"原始记录：{c.JBXX.Count()}条";
                            }
                            using (MyDb1Context c = new())
                            {
                                var v1 = c.JBXX
                                    .FromSql($"select * from JBXX where XingMing like N'张%'")
                                    .ToList();
                                dataGridView2.DataSource = v1;
                                label2.Text = $"执行结果：满足条件的有{v1.Count}条";
                            }
                            break;
                        case "查询记录（动态查询）":
                            using (MyDb1Context c = new())
                            {
                                dataGridView1.DataSource = c.JBXX.ToList();
                                label1.Text = $"原始记录：{c.JBXX.Count()}条";
                            }
                            using (MyDb1Context c = new())
                            {
                                var v2 = c.JBXX
                                    .FromSqlRaw("select * from JBXX where XingMing = {0}", textBox1.Text)
                                    .ToList();
                                dataGridView2.DataSource = v2;
                                label2.Text = $"执行结果：满足条件的有{v2.Count}条";
                            }
                            break;
                        case "插入记录":
                            using (MyDb1Context c = new())
                            {
                                dataGridView1.DataSource = c.KCCJ.ToList();
                                label1.Text = $"原始记录：{c.KCCJ.Count()}条";
                            }
                            using (MyDb1Context c = new())
                            {
                                int n1 = c.Database.ExecuteSqlRaw(
                                    "insert into KCCJ(XueHao,KCId,XueNianXueQi,ChengJi) values({0},{1},{2},{3})",
                                    "20230001", "003", "2018-2019-1", 65);
                                dataGridView2.DataSource = c.KCCJ.ToList();
                                label2.Text = $"执行结果：{c.KCCJ.Count()}条，其中成功插入了{n1}条";
                            }
                            break;
                        case "删除记录":
                            using (MyDb1Context c = new())
                            {
                                dataGridView1.DataSource = c.KCCJ.ToList();
                                label1.Text = $"原始记录：{c.KCCJ.Count()}条";
                            }
                            using (MyDb1Context c = new())
                            {
                                int n2 = c.Database.ExecuteSqlRaw("delete from KCCJ where KCId={0}", "003");
                                dataGridView2.DataSource = c.KCCJ.ToList();
                                label2.Text = $"执行结果：{c.KCCJ.Count()}条，其中成功删除了{n2}条";
                            }
                            break;
                        case "更新记录":
                            using (MyDb1Context c = new())
                            {
                                dataGridView1.DataSource = c.KCCJ.ToList();
                                label1.Text = $"原始记录：{c.KCCJ.Count()}条";
                            }
                            using (MyDb1Context c = new())
                            {
                                var n3 = c.Database.ExecuteSqlRaw("update KCCJ set ChengJi={0} where KCId={1}", 73, "003");
                                dataGridView2.DataSource = c.KCCJ.ToList();
                                label2.Text = $"执行结果：{c.KCCJ.Count()}条，其中成功修改了{n3}条";
                            }
                            break;
                    }
                }
            }
        }
    }
}
