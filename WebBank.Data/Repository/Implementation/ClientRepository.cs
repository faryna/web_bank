using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBank.Data.Entities;
using WebBank.Data.Repository.Base.Implementation;
using WebBank.Data.Repository.Interfaces;

namespace WebBank.Data.Repository.Implementation
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(DbContext context)
            : base(context)
        { }

        #region Interface Members

        public async Task<Client> GetByAccountId(int id)
        {
            return await DbSet.SingleOrDefaultAsync(x => x.UserAccointId == id);
        }

        public async Task<Client> GetByEmail(string email)
        {
            return await DbSet
                .Include(x=>x.UserAccount)
                .Include(x=>x.CashAccount)
                .SingleOrDefaultAsync(x => x.UserAccount.Email == email);
        }

        public async Task<Client> GetByIdWithCashAccount(int id)
        {
            return await DbSet
                .Include(x=>x.CashAccount)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        #endregion
    }
}
