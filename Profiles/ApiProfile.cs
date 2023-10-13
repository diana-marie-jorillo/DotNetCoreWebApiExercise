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

        CreateMap<Accounts, AccountRequestDto>()
            .ForMember(dest =>
                dest.CustomerId,
                opt => opt.MapFrom(src => src.CustomerId))
            .ForMember(dest =>
                dest.AccountNumber,
                opt => opt.MapFrom(src => src.AccountNumber))
            .ForMember(dest =>
                dest.AccountType,
                opt => opt.MapFrom(src => src.AccountType))
            .ForMember(dest =>
                dest.BranchAddress,
                opt => opt.MapFrom(src => src.BranchAddress))
            .ForMember(dest =>
                dest.InitialDeposit,
                opt => opt.MapFrom(src => src.InitialDeposit))
            .ReverseMap();
        
        CreateMap<Accounts,AccountResponseDTO>()
            .ForMember(dest =>
                dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest =>
                dest.CustomerId,
                opt => opt.MapFrom(src => src.CustomerId))
            .ForMember(dest =>
                dest.AccountNumber,
                opt => opt.MapFrom(src => src.AccountNumber))
            .ForMember(dest =>
                dest.AccountType,
                opt => opt.MapFrom(src => src.AccountType))
            .ForMember(dest =>
                dest.BranchAddress,
                opt => opt.MapFrom(src => src.BranchAddress))
            .ForMember(dest =>
                dest.InitialDeposit,
                opt => opt.MapFrom(src => src.InitialDeposit))
            .ReverseMap();
    }
}