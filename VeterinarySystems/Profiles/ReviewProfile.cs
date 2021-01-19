using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySystems.Dtos.ReviewsDtos;
using VeterinarySystems.Model;

namespace VeterinarySystems.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            // Source -> Target
            CreateMap<Reviews, ReviewReadDto>();   // GetALL GetById
            CreateMap<ReviewCreateDto, Reviews>(); // Post .. CreateReview
            CreateMap<ReviewUpdateDto, Reviews>(); // PUT Patch 
            CreateMap<Reviews, ReviewUpdateDto>();  // Delete
        }
    }
}
