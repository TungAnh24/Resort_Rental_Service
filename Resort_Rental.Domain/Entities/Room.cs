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
        [Column(TypeName = "varchar(50)", Order = 5)]
        public string RoomNumber { get; set; } = string.Empty;
        [Column(Order = 6)]
        public double Price { get; set; }
        [Column(Order = 7)]
        public double Square { get; set; }
        [Column(TypeName = "varchar(255)", Order = 8)]
        public string Description { get; set; } = string.Empty;
        [Column(Order = 9)]
        public int ElectricCounter { get; set; }
        [Column(Order = 10)]
        public int WaterCounter { get; set; }
        [Column(Order = 11)]
        public int Status { get; set; }
    }
}
