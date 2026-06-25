namespace FuLuAWinForms
{
    public partial class LX14Form : Form
    {
        public LX14Form()
        {
            InitializeComponent();
            btnShowInfo.Click += BtnShowInfo_Click;
        }

        private void BtnShowInfo_Click(object? sender, EventArgs e)
        {
            string id = txtId.Text;
            string name = txtName.Text;
            _ = int.TryParse(txtAge.Text, out int age);

            Student student = new(id, name, age);
            labelInfo.Text = student.GetInfo();
            
        }
    }

    public class Student
    {
        public string Name { get; }
        public int Age { get; }
        public string Id { get; }

        public Student(string id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public string GetInfo()
        {
            return $"姓名：{Name,-10}年龄：{Age,-10}学号：{Id}";
        }
    }
}
