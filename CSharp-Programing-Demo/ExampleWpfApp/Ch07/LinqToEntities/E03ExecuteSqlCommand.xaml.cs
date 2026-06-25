using System.Linq;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch07.LinqToEntities
{
    public partial class E03ExecuteSqlCommand : Page
    {
        public E03ExecuteSqlCommand()
        {
            InitializeComponent();
            using (var c = new MyDb1Entities())
            {
                //原始记录
                ShowResult(dataGrid1);

                //插入记录
                var sql = "insert into cj(XueHao, KCBianMa,XueNianXueQi,XiuDuLeiBie,ChengJi) " +
                    "values({0},{1},{2},{3},{4})";
                var v = c.Database.ExecuteSqlCommand(
                    sql,"20180001", "003", "2018-2019-1", "初修", 65);
                ShowResult(dataGrid2);

                //更新记录
                sql = "update cj set ChengJi={0} where KCBianMa={1}";
                v = c.Database.ExecuteSqlCommand(sql, 73, "003");
                ShowResult(dataGrid3);

                //删除记录
                sql = "delete from cj where KCBianMa={0}";
                v = c.Database.ExecuteSqlCommand(sql, "003");
                ShowResult(dataGrid4);
            }
        }
        private void ShowResult(DataGrid dataGrid)
        {
            using (var c = new MyDb1Entities())
            {
                //从下面的代码可看出，用LINQ实现多表查询既简单又容易理解
                var q = from t1 in c.CJ
                        from t2 in c.Student
                        from t3 in c.KC
                        where t1.XueHao == t2.XueHao && t1.KCBianMa == t3.KCBianMa
                        select new
                        {
                            学号 = t1.XueHao,
                            姓名 = t2.XingMing,
                            课程编码 = t1.KCBianMa,
                            课程名称 = t3.KCMingCheng,
                            学年学期 = t1.XueNianXueQi,
                            修读类别 = t1.XiuDuLeiBie,
                            成绩 = t1.ChengJi
                        };
                dataGrid.ItemsSource = q.ToList();
            }
        }
    }
}
