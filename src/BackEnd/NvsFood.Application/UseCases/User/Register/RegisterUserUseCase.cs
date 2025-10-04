using AutoMapper;
using NvsFood.Application.Services.Criptography;
using NvsFood.Communications.Responses;
using NvsFood.Domain.Interfaces;
using NvsFood.Domain.Repositories.User;
using NvsFood.Exceptions.ExceptionBase;
using NvsFood.Infrastructure.Requests;
using NvsFood.Infrastructure.Responses;

namespace NvsFood.Application.UseCases.User.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IUserReadOnlyRepository _userReadOnlyRepository;
    private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
    private readonly IMapper _mapper;
    private readonly PasswordEncripter _passwordEncripter;
    private readonly IUnitOfWork _unitOfWork;


    public RegisterUserUseCase(IUserReadOnlyRepository userReadOnlyRepository, 
        IUserWriteOnlyRepository userWriteOnlyRepository, 
        IMapper mapper, 
        PasswordEncripter passwordEncripter, 
        IUnitOfWork unitOfWork
       )
    {
        _userReadOnlyRepository = userReadOnlyRepository;
        _userWriteOnlyRepository = userWriteOnlyRepository;
        _mapper = mapper;
        _passwordEncripter = passwordEncripter;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
    {
        //Validar - ok
        Validate(request);

        // Mapping - ok
        var user = _mapper.Map<Domain.Entities.User>(request);
        
        // Criptografar a senha - ok
        user.Password = _passwordEncripter.Encrypt(request.Password);

        // Criar - ok
        await _userWriteOnlyRepository.Add(user);
        
        // Salvar - ok
        await _unitOfWork.Commit();

        // Retornar - ok
        return new ResponseRegisterUserJson
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