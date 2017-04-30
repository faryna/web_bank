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
    public class CashAccountRepository : Repository<CashAccount>, ICashAccountRepository
    {
        public CashAccountRepository(DbContext context)
            : base(context)
        { }

        #region Interface Members

        

        #endregion

    }
}
