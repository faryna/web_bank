using WebBank.Business.Managers.Base.Implementation;
using WebBank.Business.Managers.Interfaces;
using WebBank.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBank.Business.Models;
using WebBank.Data.Repository.Interfaces;
using WebBank.Data.Entities;
using AutoMapper;

namespace WebBank.Business.Managers.Implementations
{
    public class ClientManager : CrudManager<ClientModel, Client>, IClientManager
    {
        public ClientManager(IApplicationUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.Clients)
        {
        }

        public async Task<UserAccountModel> GetByAccountId(int id)
        {
            return Mapper.Map<UserAccountModel>(await UnitOfWork.Clients.GetByAccountId(id));
        }

        public async Task<ClientModel> GetByEmail(string email)
        {
            return Mapper.Map<ClientModel>(await UnitOfWork.Clients.GetByEmail(email));
        }
    }
}
