using WebBank.Data.Repository.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace WebBank.Data.Repository.Implementation
{
    public class ApplicationUnitOfWork : IApplicationUnitOfWork
    {
        private IUserAccountRepository _users { get; set; }
        private ICashAccountRepository _cashAccounts { get; set; }
        private IClientRepository _clients { get; set; }
        private ITransferTransactionRepository _trnsTrans { get; set; }

        private DbContext _context;

        public ApplicationUnitOfWork(DbContext context)
        {
            _context = context;
        }

        public ApplicationUnitOfWork(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if(_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }

        public IUserAccountRepository UserAccounts { get { return _users ?? (_users = new UserAccountRepository(_context)); }  }
        public ICashAccountRepository CashAccounts { get { return _cashAccounts ?? (_cashAccounts = new CashAccountRepository(_context)); } }
        public IClientRepository Clients { get { return _clients ?? (_clients = new ClientRepository(_context)); } }
        public ITransferTransactionRepository TransferTransactions { get { return _trnsTrans ?? (_trnsTrans = new TransferTransactionRepository(_context)); } }
    }
}
