using System.Threading.Tasks;

namespace ASPNET.Fundamentals.Autofac.Repositories
{
    public interface ICharacterRepository
    {
        Task<string> GetCharacterName();
    }
}
