using System.Threading.Tasks;

namespace ASPNET.Fundamentals.StartupClass.Services
{
    public interface IEmailSender
    {
        Task SendEmail();
    }
}
