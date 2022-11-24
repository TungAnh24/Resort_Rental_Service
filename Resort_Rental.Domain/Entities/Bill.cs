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
        [Column(TypeName = "varchar(10)", Order = 7)]
        public string Period { get; set; } = string.Empty;
        [Column(Order = 8)]
        public double RentalPrice { get; set; }
        [Column(Order = 9)]
        public int Quantity { get; set; }
        [Column(Order = 10)]
        public int Status { get; set; }
        [Column(Order = 11)]
        public virtual Contract Contract { get; set; } = new();
        [Column(Order = 12)]
        public virtual AppUser User { get; set; } = new();
    }
}
