using EatEasy.Application.Interface;
using EatEasy.Application.ViewModels;
using EatEasy.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace EatEasy.Services.API.Controllers
{
    [Authorize]
    public class OrderController : ApiController
    {

        private readonly IOrderAppService _orderAppService;
        private readonly IUserAppService _userAppService;

        public OrderController(IOrderAppService orderAppService, IUserAppService userAppService)
        {
            _orderAppService = orderAppService;
            _userAppService = userAppService;
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
        public async Task<IActionResult> Post([FromBody] OrderRegisterViewModel orderViewModel,
            CancellationToken cancellationToken)
        {
            return !ModelState.IsValid
                ? CustomResponse(ModelState)
                : CustomResponse(await _orderAppService.RegisterAsync(orderViewModel, cancellationToken));
        }

        [SwaggerOperation(
            Summary = "Listagem de pedidos",
            Description = "Lista pedidos por cliente. O id do cliente é opcional, e caso " +
                          "não seja passado irá retornar todos os pedidos se o usuário " +
                          "logado for admin ou vendedor, ou os pedidos do usuário logado " +
                          "se for um cliente.",
            OperationId = "GET",
            Tags = new[] { "Pedido" })]
        [Authorize]
        [HttpGet("order-management")]
        public async Task<IEnumerable<OrderViewModel>> Get(Guid? clientId, CancellationToken cancellationToken)
        {
            var loggedUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var loggedUserRole = await _userAppService.GetRoleByIdAsync(loggedUserId, cancellationToken);

            return await _orderAppService.GetAllAsync(loggedUserRole, loggedUserId, clientId, cancellationToken);
        }

        [SwaggerOperation(
            Summary = "Pesquisa de pedido",
            Description = "Pesquisa pedido por ID",
            OperationId = "GET",
            Tags = new[] { "Pedido" })]
        [AllowAnonymous]
        [HttpGet("order-management/{id:guid}")]
        public async Task<OrderViewModel> Get(Guid id, CancellationToken cancellationToken)
        {
            return await _orderAppService.GetByIdAsync(id, cancellationToken);
        }

        [SwaggerOperation(
            Summary = "Preparar pedido",
            Description = "Atualiza o status do pedido para preparando.",
            OperationId = "POST",
            Tags = new[] { "Pedido" })]
        [Authorize(Roles = UserRoles.ADMIN + "," + UserRoles.SELLER)]
        [HttpPost("order-management/{orderId:guid}/prepare")]
        public async Task<IActionResult> Prepare(Guid orderId, CancellationToken cancellationToken)
        {
            return CustomResponse(
                await _orderAppService.UpdateStatus(orderId, OrderStatus.Preparing, cancellationToken));
        }

        [SwaggerOperation(
            Summary = "Pedido pronto",
            Description = "Atualiza o status do pedido para completo. Usado pelo pessoal do cozinha para informar que " +
                          "o pedido está pronto para ser retirado.",
            OperationId = "POST",
            Tags = new[] { "Pedido" })]
        [Authorize(Roles = UserRoles.ADMIN + "," + UserRoles.SELLER)]
        [HttpPost("order-management/{orderId:guid}/complete")]
        public async Task<IActionResult> Complete(Guid orderId, CancellationToken cancellationToken)
        {
            return CustomResponse(
                await _orderAppService.UpdateStatus(orderId, OrderStatus.Completed, cancellationToken));
        }

        [SwaggerOperation(
            Summary = "Finalizar pedido",
            Description = "Atualiza o status do pedido para finalizado. Este status indica que o pedido foi entregue ao cliente.",
            OperationId = "POST",
            Tags = new[] { "Pedido" })]
        [Authorize(Roles = UserRoles.ADMIN + "," + UserRoles.SELLER)]
        [HttpPost("order-management/{orderId:guid}/done")]
        public async Task<IActionResult> Finalize(Guid orderId, CancellationToken cancellationToken)
        {
            return CustomResponse(
                await _orderAppService.UpdateStatus(orderId, OrderStatus.Done, cancellationToken));
        }
    }

}
