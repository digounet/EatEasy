using EatEasy.Application.Interface;
using EatEasy.Application.Services;
using EatEasy.Application.ViewModels;
using EatEasy.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EatEasy.Services.API.Controllers
{
    [Authorize]
    public class OrderController : ApiController
    {

        private readonly IOrderAppService _orderAppService;

        public OrderController(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }

        [SwaggerOperation(
            Summary = "Cadastro de pedidos",
            Description = "Apenas usuários logados no sistema podem realizar o " +
                          "cadastro do pedido. POstriormente será im´lementado o " +
                          "carrinho de compras, que é uma etapa anterior ao cadastro do pedido.",
            OperationId = "POST",
            Tags = new[] { "Pedido" })]
        [Authorize]
        [HttpPost("order-management")]
        public async Task<IActionResult> Post([FromBody] OrderRegisterViewModel orderViewModel, CancellationToken cancellationToken)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _orderAppService.RegisterAsync(orderViewModel, cancellationToken));
        }

        [SwaggerOperation(
            Summary = "Preparar pedido",
            Description = "Atualiza o status do pedido para preparando.",
            OperationId = "POST",
            Tags = new[] { "Pedido" })]
        [Authorize]
        [HttpPost("order-management/{orderId:guid}/prepare")]
        public async Task<IActionResult> Prepare(Guid orderId, CancellationToken cancellationToken)
        {
            return CustomResponse(await _orderAppService.UpdateStatus(orderId, OrderStatus.Preparing, cancellationToken));
        }
    }
}
