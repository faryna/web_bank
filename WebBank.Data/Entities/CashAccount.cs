using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebBank.Data.Entities.Base.Interfaces;

namespace WebBank.Data.Entities
{
    public class CashAccount : IEntity
    {
        [Key]
        public int Id { get; set; }

        public double Balance { get; set; }
    }
}
