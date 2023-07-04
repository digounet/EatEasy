using AutoMapper;
using EatEasy.Application.Interface;
using EatEasy.Application.ViewModels;
using EatEasy.Domain.Commands.UserCommands;
using EatEasy.Domain.Core.Domain;
using EatEasy.Domain.Core.Mediator;
using EatEasy.Domain.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace EatEasy.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserAppService(IMapper mapper, IMediatorHandler mediator, ITokenService tokenService, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _mediator = mediator;
            _tokenService = tokenService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ValidationResult> RegisterAsync(RegisterUserViewModel clientViewModel, CancellationToken cancellationToken)
        {
            var registerCommand = _mapper.Map<RegisterUserCommand>(clientViewModel);
            return await _mediator.SendCommandAsync(registerCommand, cancellationToken);
        }

        public async Task<TokenViewModel?> LoginAsync(LoginViewModel loginViewModel, CancellationToken cancellationToken)
        {
            var loginCommand = _mapper.Map<LoginUserCommand>(loginViewModel);
            var loginResponse = await _mediator.SendCommandAsync(loginCommand, cancellationToken);

            if (!loginResponse.IsValid) throw new DomainException(loginResponse.Errors[0].ErrorMessage);

            return await _tokenService.CreateToken(loginViewModel.Cpf);

        }

        public IEnumerable<RoleViewModel> GetRoles(CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<RoleViewModel>>(_roleManager.Roles);
        }
    }
}
