using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppExamples.Pages.Ch09
{
    public class E10Model : PageModel
    {
        [BindProperty]
        public Class1 MyClass1 { get; set; } = new Class1();

        public void OnGet()
        {
        }

        public void OnPost()
        {
            var a = MyClass1.UserName;
            var b = MyClass1.UserPassword;
            var c = MyClass1.OtherInfo;
            ViewData["result"] = $"姓名：{a}，密码：{b}，其他信息：{c}";
        }
    }
    public class Class1
    {
        public string UserName { get; set; } = "";

        public string UserPassword { get; set; } = "";

        public string OtherInfo { get; set; } = "";

    }
}
