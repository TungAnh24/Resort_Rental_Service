﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResortRental.Domain.Entity
{
    [Table("Guest")]
    public class Guest : BaseEntity<long>
    {
        [Column(TypeName = "varchar(70)")]
        public string? Fullname { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? CitizenId { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Phone { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string? Picture { get; set; }
        public int Status { get; set; }
    }
}
