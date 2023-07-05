using EatEasy.Application.ViewModels;
using FluentValidation.Results;

namespace EatEasy.Application.Interface
{
    public interface IUserAppService
    {
        Task<ValidationResult> RegisterAsync(RegisterUserViewModel clientViewModel, CancellationToken cancellationToken);
        Task<TokenViewModel?> LoginAsync(LoginViewModel loginViewModel, CancellationToken cancellationToken);
        IEnumerable<RoleViewModel> GetRoles(CancellationToken cancellationToken);
        Task<string> GetRoleByIdAsync(Guid loggedUserId, CancellationToken cancellationToken);
    }
}
