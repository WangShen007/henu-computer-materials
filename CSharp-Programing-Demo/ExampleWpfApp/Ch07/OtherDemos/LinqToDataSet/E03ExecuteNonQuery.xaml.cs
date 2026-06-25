using System.Data.SqlClient;
using System.Linq;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch07.LinqToDataSet
{
    public partial class E03ExecuteNonQuery : Page
    {
        public E03ExecuteNonQuery()
        {
            InitializeComponent();
            //原始记录
            ShowResult(DataGrid1);
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.MyDb1ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    //插入记录
                    cmd.CommandText = "insert into cj(XueHao,KCBianMa,XueNianXueQi,XiuDuLeiBie,ChengJi)"+
                        " values('20180001', '003', '2018-2019-1', '初修', 65)";
                    int n1 = cmd.ExecuteNonQuery();
                    ShowResult(DataGrid2);

                    //更新记录
                    cmd.CommandText = "update cj set ChengJi=73 where KCBianMa='003'";
                    int n2 = cmd.ExecuteNonQuery();
                    ShowResult(DataGrid3);

                    //删除记录
                    cmd.CommandText = "delete from cj where KCBianMa='003'";
                    int n3 = cmd.ExecuteNonQuery();
                    ShowResult(DataGrid4);
                }
            }
        }
        private void ShowResult(DataGrid dataGrid)
        {
            using (var c = new MyDb1DataSet())
            {
                var studentAdapter = new MyDb1DataSetTableAdapters.StudentTableAdapter();
                studentAdapter.Fill(c.Student);
                var kcAdapter = new MyDb1DataSetTableAdapters.KCTableAdapter();
                kcAdapter.Fill(c.KC);
                var cjAdapter = new MyDb1DataSetTableAdapters.CJTableAdapter();
                cjAdapter.Fill(c.CJ);

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
