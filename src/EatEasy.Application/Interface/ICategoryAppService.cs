using EatEasy.Application.ViewModels;
using FluentValidation.Results;

namespace EatEasy.Application.Interface;

public interface ICategoryAppService : IDisposable
{
    Task<IEnumerable<CategoryViewModel>> GetAllAsync(CancellationToken cancellationToken);
    Task<CategoryViewModel> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<ValidationResult> RegisterAsync(CategoryViewModel categoryViewModel, CancellationToken cancellationToken);
    Task<ValidationResult> Update(CategoryViewModel categoryViewModel, CancellationToken cancellationToken);
    Task<ValidationResult> Remove(Guid id, CancellationToken cancellationToken);
}