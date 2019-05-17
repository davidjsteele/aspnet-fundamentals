using System.Threading.Tasks;

namespace ASPNET.Fundamentals.DependencyInjection.Services
{
    public interface IMyDependency
    {
        Task WriteMessage(string message);
    }
}
