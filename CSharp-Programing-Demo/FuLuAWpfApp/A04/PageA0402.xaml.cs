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

namespace FuLuAWpfApp.A04
{
    /// <summary>
    /// PageA0402.xaml 的交互逻辑
    /// </summary>
    public partial class PageA0402 : Page
    {
        public PageA0402()
        {
            InitializeComponent();

            //（6）
            Loaded += delegate
            {
                listBox1.Items.Add(string.Format(
                    "{0,-10}{1,-10}{2,-20}{3,5}",
                    "课程名", "开设学期", "书名", "定价"));
                var course1 = new CourseInfo
                {
                    CourseName = "数据结构",
                    CourseSemester = CourseTime.秋季,
                    BookName = "《数据结构》",
                    Price = 40
                };
                listBox1.Items.Add(course1.Print());
                var course2 = new CourseInfo("操作系统", "《操作系统》", CourseTime.秋季, 45);
                listBox1.Items.Add(course2.Print());
                var course3 = new CourseInfo("软件工程", "《软件工程》", CourseTime.春季, 38);
                listBox1.Items.Add(course3.Print());
            };
        }
    }

    //（1）
    enum CourseTime { 春季, 秋季 }

    //（2）
    class CourseInfo
    {
        /// <summary>
        /// 课程名
        /// </summary>
        public string CourseName { get; set; }

        /// <summary>
        /// 开课学期
        /// </summary>
        public CourseTime CourseSemester;

        /// <summary>
        /// 书名
        /// </summary>
        public string BookName { get; set; }

        /// <summary>
        /// 定价
        /// </summary>
        public double Price { get; set; }

        //（3）
        public static int Counter = 0;

        //（4）
        public CourseInfo()
        {
            Counter++;
            CourseName = BookName = "<null>";
            CourseSemester = CourseTime.春季;
            Price = 0;
        }
        public CourseInfo(string couseName, string bookName, CourseTime courseSemester, int price)
        {
            Counter++;
            CourseName = couseName;
            BookName = bookName;
            CourseSemester = courseSemester;
            Price = price;
        }

        //（5）
        public string Print()
        {
            return $"{CourseName,-10}{CourseSemester,-10}{BookName,-10}{Price,10}";
            //或者：
            //return string.Format("{0,-10}{1,-10}{2,-10}{3,10}", CourseName, CourseSemester, BookName, Price);
        }
    }
}
