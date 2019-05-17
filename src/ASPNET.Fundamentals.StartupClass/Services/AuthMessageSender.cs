using System;
using System.Threading.Tasks;

namespace ASPNET.Fundamentals.StartupClass.Services
{
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public Task SendEmail()
        {
            throw new NotImplementedException();
        }

        public Task SendSMS()
        {
            throw new NotImplementedException();
        }
    }
}
