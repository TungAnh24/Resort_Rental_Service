using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResortRental.Domain.Entities
{
    [Table("Room")]
    public class Room : BaseEntity<long>
    {
        [Column(TypeName = "varchar(50)")]
        public string? RoomNumber { get; set; }
        public double Price { get; set; }
        public double Square { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string? Description { get; set; }
        public int ElectricCounter { get; set; }
        public int WaterCounter { get; set; }
        public int Status { get; set; }
    }
}
