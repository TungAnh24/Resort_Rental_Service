using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResortRental.Domain.Entities
{
    [Table("ContractDetail")]
    public class ContractDetail : BaseEntity<long>
    {
        [Column(Order = 5)]
        public int Role { get; set; }
        [Column(Order = 6)]
        public virtual Contract Contract { get; set; } = new();
        [Column(Order = 7)]
        public virtual Guest Guest { get; set; } = new();
    }
}
