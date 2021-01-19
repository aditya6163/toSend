using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySystems.Dtos.DoctorDto;
using VeterinarySystems.Model;

namespace VeterinarySystems.Profiles
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile() { 
        // Source -> Target
           CreateMap<DoctorDetails, DoctorReadDto>();
            CreateMap<DoctorCreateDto, DoctorDetails>();
            CreateMap<DoctorUpdateDto, DoctorDetails>();
            CreateMap<DoctorDetails, DoctorUpdateDto>();
        }
    }
}
