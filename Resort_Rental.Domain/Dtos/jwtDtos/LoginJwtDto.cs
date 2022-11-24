using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Domain.Dtos.jwtDtos
{
    public class LoginJwtDto
    {
        [Required(ErrorMessage = "Username không được trống!")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Password không được trống!")]
        public string Password { get; set; } = string.Empty;
    }
}
