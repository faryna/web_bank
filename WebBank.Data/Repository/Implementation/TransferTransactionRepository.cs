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
    public class TransferTransactionRepository : Repository<TransferTransaction>, ITransferTransactionRepository
    {
        public TransferTransactionRepository(DbContext context)
            : base(context)
        { }

        #region Interface Members

        public async Task<IQueryable<TransferTransaction>> GetByClientId(int id)
        {
            return DbSet
                .Where(x=>x.ClientId == id);
        }

        #endregion
    }
}
