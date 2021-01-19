using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySystems.Dtos.AddressDtos;
using VeterinarySystems.Model;

namespace VeterinarySystems.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            //Source -> Target
            CreateMap<Address, AddressReadDto>();  // GET
            CreateMap<AddressCreateDto, Address>(); //POST
            CreateMap<AddressUpdateDto, Address>(); //PUT,PATCH
            CreateMap<Address, AddressUpdateDto>(); //DELETE
        }
    }
}
