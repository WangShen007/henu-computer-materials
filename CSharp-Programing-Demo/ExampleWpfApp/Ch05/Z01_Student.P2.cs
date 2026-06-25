namespace ExampleWpfApp.Ch05
{
    public partial class ZE01_Student
    {
        public void Append2()
        {
            Name = "李四";
            Grade = 90;
            s += string.Format("{0}的成绩为{1}", Name, Grade);
        }
    }
}
