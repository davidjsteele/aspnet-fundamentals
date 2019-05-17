using System.Threading.Tasks;

namespace ASPNET.Fundamentals.DI.ServiceLifetimes.Services
{
    public interface IMyDependency
    {
        Task WriteMessage(string message);
    }
}
