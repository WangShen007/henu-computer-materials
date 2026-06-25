using Microsoft.EntityFrameworkCore;
using ClientWinFormsExamples.ch05.Models;

namespace ClientWinFormsExamples.ch05
{
    public partial class E0502 : Form
    {
        public E0502()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Init();
        }

        private async void Init()
        {
            label1.Text = string.Empty;

            await Task.Run(() =>
            {
                using var c = new MyDb1Context();
                AddTip("【使用 ExecuteDelete方法 清除数据库表】\n");
                int n1 = c.JBXX.ExecuteDelete();
                int n2 = c.KCBM.ExecuteDelete();
                int n3 = c.KCCJ.ExecuteDelete();
                AddTip($"已删除JBXX表中的{n1}条记录，KCBM表中的{n2}条记录，KCCJ表中的{n3}条记录\n\n");

                AddTip("【使用 LINQ 添加初始数据】\n");
                List<JBXX> jbxx = new()
                    {
                        new JBXX { XueHao = "20230001", XingMing = "张三一", XingBie = "男", ChuShengRiQi = DateTime.Parse("2005-01-25") },
                        new JBXX { XueHao = "20230002", XingMing = "张三二", XingBie = "男", ChuShengRiQi = DateTime.Parse("2005-09-01") },
                        new JBXX { XueHao = "20230003", XingMing = "李四", XingBie = "男", ChuShengRiQi = DateTime.Parse("2006-02-25") },
                        new JBXX { XueHao = "20230004", XingMing = "王五鱼", XingBie = "女", ChuShengRiQi = DateTime.Parse("2006-10-25") }
                    };
                c.JBXX.AddRange(jbxx);
                AddTip($"学生基本信息表（JBXX）：添加{jbxx.Count}条，");

                List<KCBM> kcbm = new()
                    {
                        new KCBM { Id = "001", KCMingCheng = "C++程序设计", KCLeiBie = "专业基础课" },
                        new KCBM { Id = "002", KCMingCheng = "C#程序设计", KCLeiBie = "专业选修课" },
                        new KCBM { Id = "003", KCMingCheng = "Java程序设计", KCLeiBie = "专业选修课" },
                        new KCBM { Id = "004", KCMingCheng = "Python程序设计", KCLeiBie = "专业选修课" }
                    };
                c.KCBM.AddRange(kcbm);
                AddTip($"课程编码对照表（KCBM）：添加{kcbm.Count}条，");

                List<KCCJ> cj = new()
                    {
                        new KCCJ { XueHao = "20230001", KCId = "001", XueNianXueQi = "2023-2024-1", ChengJi = 95 },
                        new KCCJ { XueHao = "20230002", KCId = "001", XueNianXueQi = "2023-2024-1", ChengJi = 90 },
                        new KCCJ { XueHao = "20230003", KCId = "001", XueNianXueQi = "2023-2024-1", ChengJi = 80 },
                        new KCCJ { XueHao = "20230004", KCId = "001", XueNianXueQi = "2023-2024-1", ChengJi = 91 },
                        new KCCJ { XueHao = "20230001", KCId = "002", XueNianXueQi = "2023-2024-2", ChengJi = 80 },
                        new KCCJ { XueHao = "20230002", KCId = "002", XueNianXueQi = "2023-2024-2", ChengJi = 85 },
                        new KCCJ { XueHao = "20230003", KCId = "002", XueNianXueQi = "2023-2024-2", ChengJi = 90 },
                        new KCCJ { XueHao = "20230004", KCId = "002", XueNianXueQi = "2023-2024-2", ChengJi = 92 }
                    };
                c.KCCJ.AddRange(cj);
                AddTip($"课程修读成绩表（KCCJ）：添加{cj.Count}条。\n\n");

                try
                {
                    int n = c.SaveChanges();
                    AddTip($"更新数据库成功，共更新{n}条记录。");
                }
                catch (Exception ex)
                {
                    AddTip($"更新失败：{ex.Message}");

                }
            });
        }
        private void AddTip(string text)
        {
            this.Invoke(() => label1.Text += text);
        }
    }
}
