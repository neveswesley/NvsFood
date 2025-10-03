using AutoMapper;
using NvsFood.Domain.Entities;
using NvsFood.Infrastructure.Requests;

namespace NvsFood.Application.Services.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToDomain();
    }

    public void RequestToDomain()
    {
        CreateMap<RequestRegisterUserJson, User>().ForMember(dest=>dest.Password, opt=>opt.Ignore());
    }
}