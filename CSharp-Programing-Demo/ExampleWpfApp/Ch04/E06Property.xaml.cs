using System;
using System.Windows;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch04
{
    public partial class E06Property : Page
    {
        public E06Property()
        {
            InitializeComponent();
            InitDemo();
        }
        private E06Student student;
        private void InitDemo()
        {
            Loaded += delegate {
                errorTip.Text = string.Empty;
                student = new E06Student
                {
                    Id = "001",
                    Name = "张三",
                    BirthDate = DateTime.Parse("1995-03-01"),
                    Grade = 80
                };
            };
            btnOK.Click += delegate
            {
                string s = $"学号：{student.Id}\n" +
                           $"姓名：{student.Name}\n" +
                           $"出生日期：{student.BirthDate}\n" +
                           $"成绩：{student.Grade}\n";
                MessageBox.Show(s);
            };
            textBoxGrade.TextChanged += delegate
            {
                btnOK.IsEnabled = false;
                try
                {
                    student.Grade = int.Parse(textBoxGrade.Text);
                    btnOK.IsEnabled = true;
                    errorTip.Text = string.Empty;
                }
                catch (Exception ex)
                {
                    errorTip.Text = ex.Message;
                }
            };
        }
    }
    class E06Student
    {
        #region 方式1：如果没有条件判断，直接用简写即可
        public string Id { get; set; }
        public DateTime BirthDate { get; set; }
        public string Name { get; set; }

        //解释：Name属性和下面的代码是等价的
        //private string _Name;
        //public string Name
        //{
        //    get { return _Name; }
        //    set { _Name = value; }
        //}
        #endregion

        #region 方式2：如果有条件判断，不要用简写
        private int grade;
        public int Grade
        {
            get => grade;  //或者get{return grade;}
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception("成绩必须在0～100之间");
                }
                else
                {
                    grade = value;
                }
            }
        }
        #endregion
    }
}
