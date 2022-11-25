using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Domain
{
    public abstract class BaseDto<T> where T : struct
    {
        public T Id { get; set; }
       /* public DateTime CreationTime { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public string? CreatedByUser { get; set; }
        public string? UpdatedByUser { get; set; }*/
    }
}
