using NvsFood.Exceptions.ExceptionBase;
using NvsFood.Infrastructure.Requests;
using NvsFood.Infrastructure.Responses;

namespace NvsFood.Application.UseCases.User.Register;

public class RegisterUseCase
{
    public ResponseRegisterUserJson Execute(RequestRegisterUserJson request)
    {
        // Validar - ok
        // Mapear
        // Salvar
        // Retornar
        
        Validate(request);
        
        return new ResponseRegisterUserJson()
        {
            Name = request.Name
        };
    }

    private void Validate(RequestRegisterUserJson request)
    {
        var validator = new RegisterUserValidator();
        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
    
}