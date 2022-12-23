using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Domain.Entities
{
    [Table("Service")]
    public class Service : BaseEntity<long>
    {
        [Column(TypeName = "varchar(100)", Order = 8)]
        public string ServiceName { get; set; } = string.Empty;
        [Column(Order = 9)]
        public double Price { get; set; }
        [Column(Order = 10)]
        public string Unit { get; set; } = string.Empty;
    }
}
