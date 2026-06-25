namespace Wpfz.Ch03
{
    public class C10switch
    {
        public string GetResult(int grade)
        {
            var result = "";
            if (grade < 0 || grade > 100)
            {
                result = "成绩不在0-100范围内";
            }
            else
            {
                switch (grade / 10)
                {
                    case 10:
                    case 9: result = "优秀"; break;
                    case 8:
                    case 7: result = "良好"; break;
                    case 6: result = "及格"; break;
                    default: result = "不及格"; break;
                }
            }
            return result;
        }
    }
}
