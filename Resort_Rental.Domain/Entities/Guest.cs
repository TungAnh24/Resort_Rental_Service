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
        [Column(TypeName = "varchar(70)")]
        public string Fullname { get; set; } = string.Empty;
        [Column(TypeName = "varchar(20)")]
        public string CitizenId { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Phone { get; set; } = string.Empty;
        [Column(TypeName = "varchar(255)")]
        public string Picture { get; set; } = string.Empty;
        public int Status { get; set; }
    }
}
