using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResortRental.Domain
{
    public abstract class BaseEntity<T> where T : struct
    {
        public T Id { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? CreatedByUser { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? UpdatedByUser { get; set; }
    }
}
