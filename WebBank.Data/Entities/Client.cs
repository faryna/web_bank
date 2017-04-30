using WebBank.Data.Entities.Base.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebBank.Data.Entities.Base;

namespace WebBank.Data.Entities
{
    public class Client : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Phone { get; set; }
        public string Address { get; set; }
        public string PassportNumber { get; set; }

        public int CashAccountId { get; set; }
        public CashAccount CashAccount { get; set; }

        public int UserAccointId { get; set; }
        public UserAccount UserAccount { get; set; }
    }
}
