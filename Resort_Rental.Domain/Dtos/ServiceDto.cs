using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Domain.Dtos
{
    public class ServiceDto
    {
        public string ServiceName { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Unit { get; set; } = string.Empty;
    }
}
