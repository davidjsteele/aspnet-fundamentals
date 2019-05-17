using System.Threading.Tasks;

namespace ASPNET.Fundamentals.StartupClass.Services
{
    public interface ISmsSender
    {
        Task SendSMS();
    }
}
