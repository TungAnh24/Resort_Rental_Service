﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResortRental.Domain.Entity
{
    [Table("ContractDetail")]
    public class ContractDetail : BaseEntity<long>
    {
        public int Role { get; set; }
        public virtual Contract? Contract { get; set; }
        public virtual Guest? Guest { get; set; }
    }
}
