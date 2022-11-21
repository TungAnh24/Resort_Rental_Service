using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResortRental.Domain.Entities
{
    [Table("Guest")]
    public class Guest : BaseEntity<long>
    {
        [Column(TypeName = "varchar(70)", Order = 5)]
        public string Fullname { get; set; } = string.Empty;
        [Column(TypeName = "varchar(20)", Order = 6)]
        public string CitizenId { get; set; } = string.Empty;
        [Column(Order = 7)]
        public DateTime DateOfBirth { get; set; }
        [Column(TypeName = "varchar(20)", Order = 8)]
        public string Phone { get; set; } = string.Empty;
        [Column(TypeName = "varchar(255)", Order = 9)]
        public string Picture { get; set; } = string.Empty;
        [Column(Order = 10)]
        public int Status { get; set; }
    }
}
