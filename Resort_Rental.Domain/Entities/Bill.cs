using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Domain.Entities
{
    [Table("Bill")]
    public class Bill:BaseEntity<long>
    {
        [Column(TypeName = "varchar(20)", Order = 8)]
        public string BillNumber { get; set; } = string.Empty;
        [Column(TypeName = "varchar(255)", Order = 9)]
        public string? Description { get; set; }
        [Column(TypeName = "varchar(10)", Order = 10)]
        public string Period { get; set; } = string.Empty;
        [Column(Order = 11)]
        public double RentalPrice { get; set; }
        [Column(Order = 12)]
        public int Quantity { get; set; }
        [Column(Order = 13)]
        public int Status { get; set; }
        [Column(Order = 14)]
        public virtual Contract Contract { get; set; } = new();
    }
}
