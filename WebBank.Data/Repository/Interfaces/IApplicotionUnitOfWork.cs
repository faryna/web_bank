using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace WebBank.Data.Repository.Interfaces
{
    public interface IApplicationUnitOfWork : IDisposable
    {
        IUserAccountRepository UserAccounts { get; }
        ICashAccountRepository CashAccounts { get; }
        IClientRepository Clients { get; }
        ITransferTransactionRepository TransferTransactions { get; }
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task SaveChanges();
    }
}
