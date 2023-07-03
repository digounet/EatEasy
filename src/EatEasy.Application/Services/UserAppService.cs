using AutoMapper;
using EatEasy.Application.Interface;
using EatEasy.Application.ViewModels;
using EatEasy.Domain.Commands.UserCommands;
using EatEasy.Domain.Core.Domain;
using EatEasy.Domain.Core.Mediator;
using EatEasy.Domain.Interfaces;
using FluentValidation.Results;

namespace EatEasy.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;

        public UserAppService(IMapper mapper, IMediatorHandler mediator, ITokenService tokenService, IUserRepository userRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _tokenService = tokenService;
            _userRepository = userRepository;
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

            var user = _mapper.Map<UserViewModel>(await _userRepository.GetByCpfAsync(loginViewModel.Cpf, cancellationToken));
            return _tokenService.CreateToken(user);

        }
    }
}
