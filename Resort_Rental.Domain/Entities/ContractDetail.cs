using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Domain.Entities
{
    [Table("ContractDetail")]
    public class ContractDetail : BaseEntity<long>
    {
        [Column(Order = 8)]
        public int Role { get; set; }
        [Column(Order = 9)]
        public virtual Contract Contract { get; set; } = new();
        [Column(Order = 10)]
        public virtual AppUser AppUser { get; set; } = new();
    }
}
