using ASPNET.Fundamentals.StartupClass.Options;
using ASPNET.Fundamentals.StartupClass.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace ASPNET.Fundamentals.StartupClass.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IEmailSender _emailSender;
        private readonly IOptions<AppOptions> _appOptions;

        public string Option { get; private set; }

        public IndexModel(IEmailSender emailSender, IOptions<AppOptions> appOptions)
        {
            _emailSender = emailSender;
            _appOptions = appOptions;
        }

        public void OnGet()
        {
            Option = _appOptions.Value.Option ?? "No option provided.";
        }
    }
}
