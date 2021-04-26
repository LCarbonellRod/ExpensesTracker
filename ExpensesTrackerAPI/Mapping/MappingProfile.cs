﻿using AutoMapper;
using ExpensesTrackerAPI.Resources;
using ExpensesTrackerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTrackerAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Gasto, GastoResource>();
            CreateMap<Cuota, CuotaResource>();

            // Resource to Domain
            CreateMap<GastoResource, Gasto>();
            CreateMap<CuotaResource, Cuota>();

            CreateMap<SaveGastoResource, Gasto>();
        }
    }
}
