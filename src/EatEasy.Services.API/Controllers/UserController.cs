using EatEasy.Application.Interface;
using EatEasy.Application.ViewModels;
using EatEasy.Domain.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EatEasy.Services.API.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserAppService _clientAppService;

        public UserController(IUserAppService clientAppService)
        {
            _clientAppService = clientAppService;
        }

        [SwaggerOperation(
            Summary = "Cadastro de usuários",
            Description = "Método para cadastrar usuários",
            OperationId = "POST",
            Tags = new[] { "Usuário" })]
        [HttpPost("user-management/register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserViewModel clientViewModel, CancellationToken cancellationToken)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _clientAppService.RegisterAsync(clientViewModel, cancellationToken));
        }

        [SwaggerOperation(
            Summary = "Login de usuários",
            Description = "Método para que o usuário realize o login",
            OperationId = "POST",
            Tags = new[] { "Usuário" })]
        [HttpPost("user-management/login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginViewModel, CancellationToken cancellationToken)
        {
            try
            {
                return !ModelState.IsValid
                    ? CustomResponse(ModelState)
                    : CustomResponse(await _clientAppService.LoginAsync(loginViewModel, cancellationToken));
            }
            catch (DomainException ex)
            {
                AddError(ex.Message);
                return CustomResponse();
            }
        }

        [SwaggerOperation(
            Summary = "Perfis de usuários",
            Description = "Listagem de perfis de usuários",
            OperationId = "GET",
            Tags = new[] { "Usuário", "Perfil" })]
        [HttpGet("user-management/roles")]
        public IActionResult Roles(CancellationToken cancellationToken)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(_clientAppService.GetRoles(cancellationToken));
        }
    }
}
