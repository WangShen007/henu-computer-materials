using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExampleWpfApp.Ch07.LinqToDataSet
{
    /// <summary>
    /// E05Page.xaml 的交互逻辑
    /// </summary>
    public partial class E05Page : Page
    {
        public E05Page()
        {
            InitializeComponent();
            Loaded += delegate {
                using (var c = new MyDb1DataSet())
                {
                    var studentAdapter = new MyDb1DataSetTableAdapters.StudentTableAdapter();
                    studentAdapter.Fill(c.Student);
                    var kcAdapter = new MyDb1DataSetTableAdapters.KCTableAdapter();
                    kcAdapter.Fill(c.KC);
                    var cjAdapter = new MyDb1DataSetTableAdapters.CJTableAdapter();
                    cjAdapter.Fill(c.CJ);

                    //原始记录
                    var q = from t1 in c.CJ select t1;
                    dataGrid1.ItemsSource = q.ToList();

                    //插入记录
                    c.CJ.AddCJRow("20180001", "001", "2018-2019-1", "重修", 65, "");
                    cjAdapter.Update(c.CJ);
                    ShowResult(c, dataGrid2);

                    //更新记录
                    var q1 = c.CJ.FirstOrDefault((t) => t.KCBianMa == "001" && t.XiuDuLeiBie == "重修");
                    q1.ChengJi = 73;
                    cjAdapter.Update(c.CJ);
                    ShowResult(c, dataGrid3);

                    //删除记录
                    var q2 = c.CJ.FirstOrDefault((t) => t.KCBianMa == "001" && t.XiuDuLeiBie == "重修");
                    c.CJ.RemoveCJRow(q2);
                    cjAdapter.Update(c.CJ);
                    ShowResult(c, dataGrid4);
                }
            };
        }

        private void ShowResult(MyDb1DataSet c, DataGrid dataGrid)
        {
            var q = from t1 in c.Student
                    from t2 in c.CJ
                    from t3 in c.KC
                    where t2.XueHao == t1.XueHao && t2.KCBianMa == t3.KCBianMa
                    let t = new
                    {
                        学号 = t1.XueHao,
                        姓名 = t1.XingMing,
                        学年学期 = t2.XueNianXueQi,
                        课程编码 = t2.KCBianMa,
                        课程名称 = t3.KCMingCheng,
                        修读类别 = t2.XiuDuLeiBie,
                        成绩 = t2.ChengJi
                    }
                    select t;
            dataGrid.ItemsSource = q.ToList();
        }
    }
}
