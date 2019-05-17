using System.Threading.Tasks;

namespace ASPNET.Fundamentals.DI.Autofac.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        public Task<string> GetCharacterName()
        {
            return Task.FromResult("Iron Man");
        }
    }
}
