using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using ClientWinFormsExamples.ch05.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientWinFormsExamples.ch05
{
    public partial class E0503 : Form
    {
        public E0503()
        {
            InitializeComponent();
            this.Load += E0503_Load;
        }

        private void E0503_Load(object? sender, EventArgs e)
        {
            using var c = new MyDb1Context();

            //from
            var q1 = from t in c.JBXX select t;
            dataGridView1.DataSource = q1.ToList();
            var q2 = from t in c.KCBM select t;
            dataGridView2.DataSource = q2.ToList();
            var q3 = from t in c.KCCJ select t;
            dataGridView3.DataSource = q3.ToList();
            var q4 = from t1 in c.JBXX
                     from t2 in c.KCCJ
                     from t3 in c.KCBM
                     where t1.XueHao == t2.XueHao && t2.KCId == t3.Id
                     let t = new
                     {
                         学号 = t1.XueHao,
                         姓名 = t1.XingMing,
                         学年学期 = t2.XueNianXueQi,
                         课程编码 = t2.KCId,
                         课程名称 = t3.KCMingCheng,
                         修读类别 = t3.KCLeiBie,
                         成绩 = t2.ChengJi
                     }
                     select t;
            dataGridView4.DataSource = q4.ToList();

            //where
            var q5 = from t in c.JBXX
                     where t.XingMing.StartsWith("李") && t.XingBie == "男"
                     select t;
            dataGridView_where.DataSource = q5.ToList();

            //orderby
            var q6 = from t1 in c.JBXX
                     from t2 in c.KCCJ
                     where t1.XueHao == t2.XueHao && t2.ChengJi > 85
                     orderby t2.XueHao ascending, t2.ChengJi descending
                     select new
                     {
                         学号 = t2.XueHao,
                         姓名 = t1.XingMing,
                         成绩 = t2.ChengJi
                     };
            dataGridView_orderby.DataSource = q6.ToList();

            //group
            var q7 = from t1 in c.KCCJ
                     from t2 in c.JBXX
                     from t3 in c.KCBM
                     where t1.XueHao == t2.XueHao && t1.KCId == t3.Id
                     let t = new
                     {
                         学号 = t1.XueHao,
                         姓名 = t2.XingMing,
                         性别 = t2.XingBie,
                         课程编码 = t1.KCId,
                         课程名称 = t3.KCMingCheng,
                         成绩 = t1.ChengJi
                     }
                     group t by t2.XingBie;
            foreach (var v in q7)
            {
                if (v.Key == "男")
                {
                    label4.Text = $"性别：{v.Key}";
                    dataGridView5.DataSource = v.ToList();
                }
                else
                {
                    label5.Text = $"性别：{v.Key}";
                    dataGridView6.DataSource = v.ToList();
                }
            }

            //select
            var q8 = from t in c.KCCJ select t.ChengJi;
            labelSelect.Text = $"平均成绩：{q8.Average():f2}，最高成绩：{q8.Max()}";
            var q9 = from t1 in c.JBXX
                     from t2 in c.KCCJ
                     where t1.XueHao == t2.XueHao
                     let t = new { 学号 = t1.XueHao, 姓名 = t1.XingMing, 成绩 = t2.ChengJi }
                     select t;
            dataGridViewSelect.DataSource = q9.ToList();
        }
    }
}
