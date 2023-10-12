using AutoMapper;
using Azure;
using Microsoft.AspNetCore.JsonPatch;

public class ApiProfile : Profile
{
    public ApiProfile()
    {
        CreateMap<Customer, CustomerRequestDTO>()
            .ForMember(dest =>
                dest.FirstName,
                opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest =>
                dest.LastName,
                opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest =>
                dest.MiddleName,
                opt => opt.MapFrom(src => src.MiddleName))
            .ForMember(dest =>
                dest.DateOfBirth,
                opt => opt.MapFrom(src => src.DateOfBirth))
            .ForMember(dest =>
                dest.IsFilipino,
                opt => opt.MapFrom(src => src.IsFilipino))
            .ReverseMap();

        CreateMap<Customer, CustomerResponseDto>();

        CreateMap<JsonPatchDocument<Customer>, JsonPatchDocument<CustomerRequestDTO>>().ReverseMap();
        
    }
}