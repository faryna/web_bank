﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBank.Data.Entities;
using WebBank.Data.Repository.Base.Interfaces;

namespace WebBank.Data.Repository.Interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client> GetByAccountId(int id);
        Task<Client> GetByEmail(string email);
        Task<Client> GetByIdWithCashAccount(int id);
    }
}
