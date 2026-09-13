using AutoMapper;
using BtbClient.Application.DTOs.RawMaterialDtos;
using BtbClient.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BtbClient.Application.Mapping
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<RawMaterial, RawMaterialDto>();

            CreateMap<CreateRawMaterialDto, RawMaterial>();

            CreateMap<UpdateRawMaterialDto, RawMaterial>();
        }

    }
}


// First we have to add 2 package in apllication project then we are add dto here 
// for automapping there is also need 