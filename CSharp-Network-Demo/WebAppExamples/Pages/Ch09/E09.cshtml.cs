using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppExamples.Pages.Ch09
{
    public class E09Model : PageModel
    {
        public void OnGet()
        {
        }
        public void OnPost()
        {
            var userName = Request.Form["txtUserName"];
            var age = Request.Form["txtAge"];
            //得到姓名和年龄后，就可以进行其他处理了，此处仅简单地将其在页面中显示出来
            var result = $"传输方式：{Request.Method}，提交结果：姓名={userName}，年龄={age}";
            ViewData["result"] = result;
        }
    }
}
