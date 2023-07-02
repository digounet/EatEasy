using EatEasy.Application.Interface;
using EatEasy.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EatEasy.Services.API.Controllers
{
    public class ClientController : ApiController
    {
        private readonly IClientAppService _clientAppService;

        public ClientController(IClientAppService clientAppService)
        {
            _clientAppService = clientAppService;
        }

        [HttpPost("client-management/register")]
        public async Task<IActionResult> Register([FromBody] RegisterClientViewModel clientViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _clientAppService.RegisterAsync(clientViewModel));
        }

        [HttpPost("client-management/login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginViewModel, CancellationToken cancellationToken)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _clientAppService.LoginAsync(loginViewModel, cancellationToken));
        }
    }
}
