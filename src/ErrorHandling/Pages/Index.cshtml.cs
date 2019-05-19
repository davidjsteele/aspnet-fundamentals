using System.IO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNET.Fundamentals.ErrorHandling.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            if (HttpContext.Request.Query.ContainsKey("throw"))
            {
                throw new FileNotFoundException("File not found exception thrown in index.chtml");
            }
        }
    }
}
