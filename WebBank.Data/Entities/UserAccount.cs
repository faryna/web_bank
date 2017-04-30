using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebBank.Data.Entities.Base.Interfaces;
using WebBank.Data.Infrastructure.Enums;

namespace WebBank.Data.Entities
{
    public class UserAccount : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public bool IsAdmin { get; set; }
    }
}
