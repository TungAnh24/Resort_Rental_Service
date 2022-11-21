using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResortRental.Domain.Entities
{
    [Table("User")]
    public class User : BaseEntity<long>
    {
        [Column(TypeName = "varchar(20)")]
        public string Username { get; set; } = string.Empty;
        [Column(TypeName = "varchar(100)")]
        public string Password { get; set; } = string.Empty;
        [Column(TypeName = "varchar(20)")]
        public string Phone { get; set; } = string.Empty;
        public int Authority { get; set; }
    }
}
