using NvsFood.Communications.Responses;
using NvsFood.Infrastructure.Requests;
using NvsFood.Infrastructure.Responses;

namespace NvsFood.Application.UseCases.User.Register;

public interface IRegisterUserUseCase
{
    public Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request);
}