using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResortRental.Domain.Entities
{
    [Table("BillDetail")]
    public class BillDetail : BaseEntity<long>
    {
        [Column(Order = 5)]
        public double ServicePrice { get; set; }
        [Column(Order = 6)]
        public int FirstCounter { get; set; }
        [Column(Order = 7)]
        public int LastCounter { get; set; }
        [Column(Order = 8)]
        public int Quantity { get; set; }
            
        public double Subtotal { get; set; }
        [Column(Order = 9)]
        public virtual Bill Bill { get; set; } = new();
        [Column(Order = 10)]
        public virtual Service Service { get; set; } = new();
    }
}
