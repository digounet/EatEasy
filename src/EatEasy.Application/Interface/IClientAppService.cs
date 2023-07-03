using EatEasy.Application.ViewModels;
using FluentValidation.Results;

namespace EatEasy.Application.Interface
{
    public interface IClientAppService
    {
        Task<ValidationResult> RegisterAsync(RegisterClientViewModel clientViewModel, CancellationToken cancellationToken);
        Task<ClientViewModel> LoginAsync(LoginViewModel loginViewModel, CancellationToken cancellationToken);
    }
}
