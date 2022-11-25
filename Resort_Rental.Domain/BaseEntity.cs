using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Domain
{
    public abstract class BaseEntity<T> where T : struct
    {
        [Column(Order = 0)]
        public T Id { get; set; }
        [Column(Order = 1)]
        public DateTime? CreationTime { get; set; } = DateTime.Now;
        [Column(Order = 2)]
        public DateTime? LastUpdateTime { get; set; }
        [Column(TypeName = "varchar(20)", Order = 3)]
        public string? CreatedByUser { get; set; } = string.Empty;
        [Column(TypeName = "varchar(20)", Order = 4)]
        public string? UpdatedByUser { get; set; } = string.Empty;
        public int IsDelete { get; set; }
    }
}
