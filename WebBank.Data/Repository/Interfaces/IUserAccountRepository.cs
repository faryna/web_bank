using WebBank.Data.Entities;
using WebBank.Data.Repository.Base.Interfaces;
using System.Threading.Tasks;

namespace WebBank.Data.Repository.Interfaces
{
    public interface IUserAccountRepository : IRepository<UserAccount>
    {
        Task<UserAccount> GetByEmailAndPassword(string email, string password);
        Task<UserAccount> GetByEmail(string email);
    }
}
