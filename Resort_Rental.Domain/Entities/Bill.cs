using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResortRental.Domain.Entities
{
    [Table("Bill")]
    public class Bill:BaseEntity<long>
    {
        [Column(TypeName = "varchar(20)", Order = 5)]
        public string BillNumber { get; set; } = string.Empty;
        [Column(TypeName = "varchar(255)", Order = 6)]
        public string? Description { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string? Period { get; set; }
        public double RentalPrice { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
        public virtual Contract Contract { get; set; } = new();
        public virtual User? User { get; set; } = new();
    }
}
