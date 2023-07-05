using EatEasy.Application.Interface;
using EatEasy.Application.ViewModels;
using EatEasy.Domain.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EatEasy.Services.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductController : ApiController
    {
        private readonly IProductAppService _productAppService;
        public ProductController(IProductAppService appService)
        {
            _productAppService = appService;
        }

        [SwaggerOperation(
            Summary = "Listagem de produtos",
            Description = "Lista todas os produtos",
            OperationId = "GET",
            Tags = new[] { "Produto" })]
        [AllowAnonymous]
        [HttpGet("product-management")]
        public async Task<IEnumerable<ProductViewModel>> Get(CancellationToken cancellationToken)
        {
            return await _productAppService.GetAllAsync(cancellationToken);
        }

        [SwaggerOperation(
            Summary = "Produtos por categoria",
            Description = "Lista os produtos por ID da categoria",
            OperationId = "GET",
            Tags = new[] { "Produto" })]
        [AllowAnonymous]
        [HttpGet("product-management/products")]
        public async Task<IActionResult> GetByCategory([FromQuery] Guid categoryId, CancellationToken cancellationToken)
        {
            if (categoryId == Guid.Empty)
            {
                AddError("Informe o ID da categoria");
                return CustomResponse();
            }

            return CustomResponse(await _productAppService.FindByCategoryAsync(categoryId, cancellationToken));
        }

        [SwaggerOperation(
            Summary = "Pesquisa de produtos",
            Description = "Pesquisa produto por ID",
            OperationId = "GET",
            Tags = new[] { "Produto" })]
        [AllowAnonymous]
        [HttpGet("product-management/{id:guid}")]
        public async Task<ProductViewModel> Get(Guid id, CancellationToken cancellationToken)
        {
            return await _productAppService.GetByIdAsync(id, cancellationToken);
        }

        [SwaggerOperation(
            Summary = "Cadastro de produtos",
            Description = "Cadastro de produtos",
            OperationId = "POST",
            Tags = new[] { "Produto"})]
        [Authorize(Roles = UserRoles.ADMIN)]
        [HttpPost("product-management")]
        public async Task<IActionResult> Post([FromBody] ProductRegisterViewModel productViewModel, CancellationToken cancellationToken)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _productAppService.RegisterAsync(productViewModel, cancellationToken));
        }

        [SwaggerOperation(
            Summary = "Edição de produtos",
            Description = "Alterar dados de produtos",
            OperationId = "PUT",
            Tags = new[] { "Produto" })]
        [Authorize(Roles = UserRoles.ADMIN)]
        [HttpPut("product-management")]
        public async Task<IActionResult> Put([FromBody] ProductUpdateViewModel productViewModel, CancellationToken cancellationToken)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _productAppService.Update(productViewModel, cancellationToken));
        }

        [SwaggerOperation(
            Summary = "Exclusão de produtos",
            Description = "Excluir produtos",
            OperationId = "DELETE",
            Tags = new[] { "Produto"})]
        [Authorize(Roles = UserRoles.ADMIN)]
        [HttpDelete("product-management/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            return CustomResponse(await _productAppService.Remove(id, cancellationToken));
        }
    }
}
