using System.Threading.Tasks;

namespace ASPNET.Fundamentals.DI.Autofac.Repositories
{
    public interface ICharacterRepository
    {
        Task<string> GetCharacterName();
    }
}
