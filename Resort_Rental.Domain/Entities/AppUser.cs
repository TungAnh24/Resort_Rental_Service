using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Domain.Entities
{
    /*[Table("User")]*/
    public class AppUser : IdentityUser<long>
    {
        /*[Column(TypeName = "varchar(20)", Order = 5)]
        public string Username { get; set; } = string.Empty;
        [Column(TypeName = "varchar(100)", Order = 6)]
        public string Password { get; set; } = string.Empty;
        [Column(TypeName = "varchar(20)", Order = 7)]
        public string Phone { get; set; } = string.Empty;
        [Column(Order = 8)]
        public int Authority { get; set; }*/
        [Column(Order = 1)]
        public DateTime? CreationTime { get; set; } = DateTime.Now;
        [Column(Order = 2)]
        public DateTime? LastUpdateTime { get; set; }
        [Column(TypeName = "varchar(20)", Order = 3)]
        public string? CreatedByUser { get; set; } = string.Empty;
        [Column(TypeName = "varchar(20)", Order = 4)]
        public string? UpdatedByUser { get; set; } = string.Empty;
        public int IsDelete { get; set; }
        public virtual AppRole? AppRole { get; set; }
    }
}
