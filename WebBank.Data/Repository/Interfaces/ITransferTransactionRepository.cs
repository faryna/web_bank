using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBank.Data.Entities;
using WebBank.Data.Repository.Base.Interfaces;

namespace WebBank.Data.Repository.Interfaces
{
    public interface ITransferTransactionRepository : IRepository<TransferTransaction>
    {
        Task<IQueryable<TransferTransaction>> GetByClientId(int id);
    }
}
