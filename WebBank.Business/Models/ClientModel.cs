using WebBank.Business.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBank.Business.Models
{
    public class ClientModel : IModel
    {
        public int Id { get; set; }

        public string Phone { get; set; }
        public string Address { get; set; }
        public string PassportNumber { get; set; }

        public int CashAccountId { get; set; }
        public CashAccountModel CashAccount { get; set; }

        public int UserAccointId { get; set; }
        public UserAccountModel UserAccount { get; set; }
    }
}
