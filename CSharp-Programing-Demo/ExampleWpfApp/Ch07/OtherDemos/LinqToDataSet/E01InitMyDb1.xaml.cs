using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch07.LinqToDataSet
{
    public partial class E01InitMyDb1 : Page
    {
        public E01InitMyDb1()
        {
            InitializeComponent();
            Loaded += delegate
            {
                Init();
            };
        }
        private async void Init()
        {
            await Task.Run(() => {
                AddTip("【使用 SQL命令 清除数据库表】\n");
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.MyDb1ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "delete from Student";
                        int n1 = cmd.ExecuteNonQuery();
                        cmd.CommandText = "delete from KC";
                        int n2 = cmd.ExecuteNonQuery();
                        cmd.CommandText = "delete from CJ";
                        int n3 = cmd.ExecuteNonQuery();
                        AddTip($"已删除Student表中的{n1}记录，KC表中的{n2}记录，CJ表中的{n3}记录\n");
                    }
                }
            });
            await Task.Run(() => {
                AddTip("【使用 DataSet 添加初始数据】\n");
                var students = new MyDb1DataSet.StudentDataTable();
                students.AddStudentRow("20180001", "张三一", "男", DateTime.Parse("1999-01-25"), null);
                students.AddStudentRow("20180002", "张三二", "男", DateTime.Parse("1999-09-01"), null);
                students.AddStudentRow("20180003", "李四", "男", DateTime.Parse("2000-02-25"), null);
                students.AddStudentRow("20180004", "王五", "女", DateTime.Parse("2001-10-15"), null);

                var kc = new MyDb1DataSet.KCDataTable();
                kc.AddKCRow("001", "C++程序设计", "专业基础课");
                kc.AddKCRow("002", "C#程序设计", "专业选修课");
                kc.AddKCRow("003", "Java程序设计", "专业选修课");
                kc.AddKCRow("004", "Python程序设计", "专业选修课");

                var cj = new MyDb1DataSet.CJDataTable();
                cj.AddCJRow("20180001", "001", "2018-2019-1", "初修", 95, "");
                cj.AddCJRow("20180001", "002", "2018-2019-1", "初修", 80, "");
                cj.AddCJRow("20180002", "001", "2018-2019-1", "初修", 90, "");
                cj.AddCJRow("20180002", "002", "2018-2019-1", "初修", 85, "");
                cj.AddCJRow("20180003", "001", "2018-2019-1", "初修", 80, "");
                cj.AddCJRow("20180003", "002", "2018-2019-1", "初修", 90, "");

                var studentAdapter = new MyDb1DataSetTableAdapters.StudentTableAdapter();
                var kcAdapter = new MyDb1DataSetTableAdapters.KCTableAdapter();
                var cjAdapter = new MyDb1DataSetTableAdapters.CJTableAdapter();
                try
                {
                    int x1 = studentAdapter.Update(students);
                    int x2 = kcAdapter.Update(kc);
                    int x3 = cjAdapter.Update(cj);
                    AddTip($"更新成功：Student表{x1}条，KC表{x2}条，CJ表{x3}条\n");
                }
                catch (Exception ex)
                {
                    AddTip($"更新失败：{ex.Message}");
                }
            });
        }
        private void AddTip(string text)
        {
            this.Dispatcher.Invoke(() => textBlock1.Text += text);
        }
    }
}
