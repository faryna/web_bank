using WebBank.Business.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBank.Business.Models
{
    public class CashAccountModel : IModel
    {
        public int Id { get; set; }

        public double Balance { get; set; }
    }
}
