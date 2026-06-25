using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppExamples.Pages.Ch09
{
    public class E01WelcomeModel : PageModel
    {
        public void OnGet()
        {
            var route = RouteData.Values.ToArray();
            Console.WriteLine(route.Length);
            var filePath = HttpContext.Request.Path;
            Console.WriteLine(filePath.HasValue ? filePath.Value[0] : null);
        }
    }
}
