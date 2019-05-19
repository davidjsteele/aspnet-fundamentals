using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASPNET.Fundamentals.StaticFiles.Models;
using Microsoft.AspNetCore.Authorization;
using System.IO;

namespace ASPNET.Fundamentals.StaticFiles.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult AuthorizedImage()
        {
            var file = Path.Combine(Directory.GetCurrentDirectory(),
                                    "MyStaticFiles", "images", "microsoft.png");

            return PhysicalFile(file, "image/svg+xml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
