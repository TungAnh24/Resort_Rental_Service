using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResortRental.Domain.Entity
{
    [Table("Contract")]
    public class Contract : BaseEntity<long>
    {
        [Column(TypeName = "varchar(50)")]
        public string? ContractNumber { get; set; }
        public double Price { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string? FileLocation { get; set; }
        public int Status { get; set; }
        public virtual Room? Room { get; set; }
        public virtual User? User { get; set; }
    }
}
