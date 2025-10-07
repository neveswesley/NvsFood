using Microsoft.AspNetCore.Mvc;
using NvsFood.Application.UseCases.User.Register;
using NvsFood.Communications.Responses;
using NvsFood.Infrastructure.Requests;

namespace NvsFood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> Register([FromServices] IRegisterUserUseCase useCase, [FromBody] RequestRegisterUserJson request)
        {
            var result = await useCase.Execute(request);

            return Created(string.Empty, result);
        }
        
    }
}
