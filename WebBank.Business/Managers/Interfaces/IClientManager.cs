using WebBank.Business.Managers.Base.Interfaces;
using WebBank.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBank.Business.Models;

namespace WebBank.Business.Managers.Interfaces
{
    public interface IClientManager : ICrudManager<ClientModel>
    {
        Task<ClientModel> GetByEmail(string email);
    }
}
