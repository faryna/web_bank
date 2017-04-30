using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebBank.Data.Entities.Base.Interfaces;

namespace WebBank.Data.Entities.Base
{
    public abstract class Transaction : IEntity
    {
        [Key]
        public int Id { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public double Amount { get; set; }

        public DateTime Date { get; set; }
    }
}
