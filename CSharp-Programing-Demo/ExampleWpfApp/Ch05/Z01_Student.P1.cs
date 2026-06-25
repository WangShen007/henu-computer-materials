namespace ExampleWpfApp.Ch05
{
    public partial class ZE01_Student
    {
        private string s = string.Empty;
        public string Name { get; set; } = "张三";
        public int Grade { get; set; } = 80;
        public void Append1()
        {
            Name = "张三";
            Grade = 80;
            s += string.Format("{0}的成绩为{1}\n", Name, Grade);
        }
        public string GetResult()
        {
            return s;
        }
    }
}
