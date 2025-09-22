using Api.Dtos;
using AutoMapper;
using Domain.Models;

namespace Api.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ItemType, ItemTypeDto>();
    }
}