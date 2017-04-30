using System.ComponentModel.DataAnnotations;
using WebBank.Data.Entities.Base;
using WebBank.Data.Entities.Base.Interfaces;

namespace WebBank.Data.Entities
{
    public class TransferTransaction : Transaction
    { 
        public int Receiver { get; set; }
    }
}
