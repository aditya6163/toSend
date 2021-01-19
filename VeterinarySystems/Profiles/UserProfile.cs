using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySystems.Dtos;
using VeterinarySystems.Dtos.UserDto;
using VeterinarySystems.Model;

namespace VeterinarySystems.Profiles
{
    public class UserProfile : Profile
    {
        
        public UserProfile()
        {   
            // Source -> Target
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserUpdateDto>();

        }

    }
}
