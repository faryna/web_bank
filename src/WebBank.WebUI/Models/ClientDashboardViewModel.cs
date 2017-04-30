using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBank.Business.Models;
using WebBank.Business.Models.Base;

namespace WebBank.WebUI.Models
{
    public class ClientDashboardViewModel
    {
        public ClientModel Client { get; set; }
        public List<TransactionModel> Transactions { get; set; }
    }
}
