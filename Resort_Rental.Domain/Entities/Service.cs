using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResortRental.Domain.Entities
{
    [Table("Service")]
    public class Service : BaseEntity<long>
    {
        [Column(TypeName = "varchar(100)")]
        public string? ServiceName { get; set; }
        public double Price { get; set; }
        public string? Unit { get; set; }
    }
}
