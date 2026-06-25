namespace ClientWinFormsExamples.ch04
{
    public partial class E0405Property : Form
    {
        public E0405Property()
        {
            InitializeComponent();
            var student = new E0405Student
            {
                Id = "001",
                Name = "张三",
                BirthDate = DateTime.Parse("1995-03-01"),
                Grade = 80
            };
            string s = $"学号：{student.Id}\n" +
                       $"姓名：{student.Name}\n" +
                       $"出生日期：{student.BirthDate}\n" +
                       $"成绩：{student.Grade}\n";
            label1.Text = s;
        }
    }
    class E0405Student
    {
        public string? Id { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Name { get; set; }
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
    }
}
