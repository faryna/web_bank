using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebBank.Data.Entities.Base.Interfaces
{
    public interface IEntity
    {
        [Key]
        int Id { get; set; }
    }
}
