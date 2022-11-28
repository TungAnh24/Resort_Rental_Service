using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Resort_Rental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Domain.Dtos
{
    public class ContractDto : BaseDto<long>
    {
        public string ContractNumber { get; set; } = string.Empty;
        public double Price { get; set; }
        public string FileLocation { get; set; } = string.Empty;
        public long roomId { get; set; }
        public long userId { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
