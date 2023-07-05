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
    public class CategoryController : ApiController
    {
        private readonly ICategoryAppService _categoryAppService;
        public CategoryController(ICategoryAppService appService)
        {
            _categoryAppService = appService;
        }

        [SwaggerOperation(
            Summary = "Listagem de categorias",
            Description = "Lista todas as categorias",
            OperationId = "GET",
            Tags = new[] { "Categoria" })]
        [AllowAnonymous]
        [HttpGet("category-management")]
        public async Task<IEnumerable<CategoryViewModel>> Get(CancellationToken cancellationToken)
        {
            return await _categoryAppService.GetAllAsync(cancellationToken);
        }

        [SwaggerOperation(
            Summary = "Pesquisa de categorias",
            Description = "Pesquisa categoria por ID",
            OperationId = "GET",
            Tags = new[] { "Categoria" })]
        [AllowAnonymous]
        [HttpGet("category-management/{id:guid}")]
        public async Task<CategoryViewModel> Get(Guid id, CancellationToken cancellationToken)
        {
            return await _categoryAppService.GetByIdAsync(id, cancellationToken);
        }

        [SwaggerOperation(
            Summary = "Cadastro de categorias",
            Description = "Cadastro de categorias",
            OperationId = "POST",
            Tags = new[] { "Categoria"})]
        [Authorize(Roles = UserRoles.ADMIN)]
        [HttpPost("category-management")]
        public async Task<IActionResult> Post([FromBody] CategoryViewModel categoryViewModel, CancellationToken cancellationToken)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _categoryAppService.RegisterAsync(categoryViewModel, cancellationToken));
        }

        [SwaggerOperation(
            Summary = "Edição de categorias",
            Description = "Alterar dados de categorias",
            OperationId = "PUT",
            Tags = new[] { "Categoria" })]
        [Authorize(Roles = UserRoles.ADMIN)]
        [HttpPut("category-management")]
        public async Task<IActionResult> Put([FromBody] CategoryViewModel categoryViewModel, CancellationToken cancellationToken)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _categoryAppService.Update(categoryViewModel, cancellationToken));
        }

        [SwaggerOperation(
            Summary = "Exclusão de categorias",
            Description = "Excluir categorias",
            OperationId = "DELETE",
            Tags = new[] { "Categoria"})]
        [Authorize(Roles = UserRoles.ADMIN)]
        [HttpDelete("category-management/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            return CustomResponse(await _categoryAppService.Remove(id, cancellationToken));
        }
    }
}
