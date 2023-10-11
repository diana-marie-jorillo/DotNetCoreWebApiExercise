using AutoMapper;

public class ApiProfile : Profile
{
    public ApiProfile()
    {
        CreateMap<Customer, CustomerDto>();
    }
}