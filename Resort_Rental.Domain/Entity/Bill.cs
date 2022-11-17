using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResortRental.Domain.Entity
{
    [Table("Bill")]
    public class Bill:BaseEntity<long>
    {
        [Column(TypeName = "varchar(20)")]
        public string? BillNumber { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string? Description { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string? Period { get; set; }
        public double RentalPrice { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
        public virtual Contract? Contract { get; set; }
        public virtual User? User { get; set; }
    }
}
