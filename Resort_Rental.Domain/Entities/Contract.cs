using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Domain.Entities
{
    [Table("Contract")]
    public class Contract : BaseEntity<long>
    {
        [Column(TypeName = "varchar(50)", Order = 5)]
        public string ContractNumber { get; set; } = string.Empty;
        [Column(Order = 6)]
        public double Price { get; set; }
        [Column(TypeName = "varchar(255)", Order = 7)]
        public string FileLocation { get; set; } = string.Empty;
        [Column(Order = 8)]
        public int Status { get; set; }
        [Column(Order = 9)]
        public virtual Room Room { get; set; } = new();
        [Column(Order = 10)]
        public virtual AppUser User { get; set; } = new(); 
    }
}
