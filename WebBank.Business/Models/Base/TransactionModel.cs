using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBank.Business.Models.Base
{
    public abstract class TransactionModel : IModel
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public ClientModel Client { get; set; }

        public double Amount { get; set; }

        public DateTime Date { get; set; }
    }
}
