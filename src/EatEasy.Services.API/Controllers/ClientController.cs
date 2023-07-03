using EatEasy.Application.Interface;
using EatEasy.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EatEasy.Services.API.Controllers
{
    public class ClientController : ApiController
    {
        private readonly IClientAppService _clientAppService;

        public ClientController(IClientAppService clientAppService)
        {
            _clientAppService = clientAppService;
        }

        [SwaggerOperation(
            Summary = "Cadastro de cliente",
            Description = "Método para cadastrar clientes",
            OperationId = "POST",
            Tags = new[] {"Cliente"})]
        [HttpPost("client-management/register")]
        public async Task<IActionResult> Register([FromBody] RegisterClientViewModel clientViewModel, CancellationToken cancellationToken)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _clientAppService.RegisterAsync(clientViewModel, cancellationToken));
        }

        [SwaggerOperation(
            Summary = "Login de cliente",
            Description = "Método para que o cliente realize o login",
            OperationId = "POST",
            Tags = new[] { "Cliente" })]
        [HttpPost("client-management/login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginViewModel, CancellationToken cancellationToken)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _clientAppService.LoginAsync(loginViewModel, cancellationToken));
        }
    }
}
