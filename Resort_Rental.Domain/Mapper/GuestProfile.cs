﻿using AutoMapper;
using Resort_Rental.Domain.Dtos;
using Resort_Rental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resort_Rental.Domain.Mapper
{
    public class GuestProfile : Profile
    {
        public GuestProfile()
        {
            CreateMap<Guest, GuestDto>();
            CreateMap<GuestDto, Guest>();
        }
    }
}
