using AutoMapper;
using Entitites.Dtos;
using Entitites.Models;

namespace StoreApp.Infrastructer.Mapper
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<ProductDtForInsertion, Product>();
            CreateMap<ProductDtoForUpdate, Product>().ReverseMap();
            
            
        }


    }
}