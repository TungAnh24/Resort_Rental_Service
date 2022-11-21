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
        public double ServicePrice { get; set; }
        public int FirstCounter { get; set; }
        public int LastCounter { get; set; }
        public int Quantity { get; set; }
        public double Subtotal { get; set; }
        public virtual Bill? Bill { get; set; }
        public virtual Service? Service { get; set; }
    }
}
