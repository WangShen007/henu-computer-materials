using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch07.LinqToDataSet
{
    public partial class E02ExecuteReader : Page
    {
        public E02ExecuteReader()
        {
            InitializeComponent();
            Btn1.Click += Btn1_Click;
        }
        private void Btn1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string connStr = Properties.Settings.Default.MyDb1ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    if (r1.IsChecked == true)
                    {
                        cmd.CommandText = "select * from student";
                        var r = cmd.ExecuteReader();
                        var students = new MyDb1DataSet.StudentDataTable();
                        while (r.Read())
                        {
                            students.AddStudentRow(
                                (string)r[0],
                                (string)r[1],
                                (string)r[2],
                                (DateTime)r[3], null);
                        }
                        DataGrid1.ItemsSource = students.ToList();
                    }
                    if (r2.IsChecked == true)
                    {
                        cmd.CommandText = "select * from kc";
                        var r = cmd.ExecuteReader();
                        var kc = new MyDb1DataSet.KCDataTable();
                        while (r.Read())
                        {
                            kc.AddKCRow((string)r[0], (string)r[1], (string)r[2]);
                        }
                        DataGrid1.ItemsSource = kc.ToList();
                    }
                    if (r3.IsChecked == true)
                    {
                        cmd.CommandText = "select * from cj";
                        var r = cmd.ExecuteReader();
                        var cj = new MyDb1DataSet.CJDataTable();
                        while (r.Read())
                        {
                            cj.AddCJRow(
                                (string)r[1],
                                (string)r[2],
                                (string)r[3],
                                (string)r[4],
                                (int)r[5],
                                (string)r[6]);
                        }
                        DataGrid1.ItemsSource = cj.ToList();
                    }
                }
            }
        }
    }
}
