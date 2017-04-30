using WebBank.Data.Entities;
using WebBank.Data.Repository.Base.Implementation;
using WebBank.Data.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebBank.Data.Infrastructure.Helpers;

namespace WebBank.Data.Repository.Implementation
{
    public class UserAccountRepository : Repository<UserAccount>, IUserAccountRepository
    {
        public UserAccountRepository(DbContext context)
            : base(context)
        { }

        public async Task<UserAccount> GetByEmailAndPassword(string email, string password)
        {
            return await DbSet.Where(x => x.Email == email && PasswordHasher.VerifyMd5Hash(password, x.Password)).FirstOrDefaultAsync();
        }


        public async Task<UserAccount> GetByEmail(string email)
        {
            return await DbSet.Where(x => x.Email == email).FirstOrDefaultAsync();
        }
    }
}
