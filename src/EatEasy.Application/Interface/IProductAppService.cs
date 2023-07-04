using EatEasy.Application.ViewModels;
using FluentValidation.Results;

namespace EatEasy.Application.Interface;

public interface IProductAppService
{
    Task<IEnumerable<ProductViewModel>> GetAllAsync(CancellationToken cancellationToken);
    Task<ProductViewModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<ValidationResult> RegisterAsync(ProductRegisterViewModel productViewModel, CancellationToken cancellationToken);
    Task<ValidationResult> Update(ProductUpdateViewModel productViewModel, CancellationToken cancellationToken);
    Task<ValidationResult> Remove(Guid id, CancellationToken cancellationToken);
}