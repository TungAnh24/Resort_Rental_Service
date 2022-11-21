using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResortRental.Domain.Entities
{
    [Table("Contract")]
    public class Contract : BaseEntity<long>
    {
        [Column(TypeName = "varchar(50)")]
        public string ContractNumber { get; set; } = string.Empty;
        public double Price { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string FileLocation { get; set; } = string.Empty;
        public int Status { get; set; }
        public virtual Room Room { get; set; } = new(); 
        public virtual User User { get; set; } = new(); 
    }
}
