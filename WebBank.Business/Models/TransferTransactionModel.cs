using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBank.Business.Models.Base;

namespace WebBank.Business.Models
{
    public class TransferTransactionModel : TransactionModel
    {
        public int Receiver { get; set; }
    }
}
