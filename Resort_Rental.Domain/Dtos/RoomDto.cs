using Resort_Rental.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Domain.Dtos
{
    public class RoomDto : BaseDto<long>
    {
        public string? RoomNumber { get; set; }
        public double Price { get; set; }
        public double Square { get; set; }
        public string? Description { get; set; }
        public int ElectricCounter { get; set; }
        public int WaterCounter { get; set; }
        public int Status { get; set; }
    }
}
