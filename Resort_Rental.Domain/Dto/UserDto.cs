using ResortRental.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Domain.Dto
{
    public class UserDTO : BaseDto<long>
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public int Authority { get; set; }
    }
}
