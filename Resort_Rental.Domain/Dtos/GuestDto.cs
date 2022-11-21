using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Domain.Dtos
{
    public class GuestDto : BaseDto<long>
    {
        public string? Fullname { get; set; }
        public string? CitizenId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Phone { get; set; }
        public string? Picture { get; set; }
        public int Status { get; set; }
    }
}
