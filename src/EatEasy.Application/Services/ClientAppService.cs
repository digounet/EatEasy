using AutoMapper;
using EatEasy.Application.Interface;
using EatEasy.Application.ViewModels;
using EatEasy.Domain.Commands.ClientCommands;
using EatEasy.Domain.Core.Mediator;
using EatEasy.Domain.Interfaces;
using FluentValidation.Results;

namespace EatEasy.Application.Services
{
    public class ClientAppService : IClientAppService
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;
        private readonly IMediatorHandler _mediator;

        public ClientAppService(IMapper mapper, IClientRepository clientRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
            _mediator = mediator;
        }

        public async Task<ValidationResult> RegisterAsync(RegisterClientViewModel clientViewModel, CancellationToken cancellationToken)
        {
            var registerCommand = _mapper.Map<RegisterClientCommand>(clientViewModel);
            return await _mediator.SendCommandAsync(registerCommand, cancellationToken);
        }

        public async Task<ClientViewModel> LoginAsync(LoginViewModel loginViewModel, CancellationToken cancellationToken)
        {
            return _mapper.Map<ClientViewModel>(await _clientRepository.LoginAsync(loginViewModel.Cpf, loginViewModel.Password, cancellationToken));
        }
    }
}
