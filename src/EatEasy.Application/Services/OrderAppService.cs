using EatEasy.Application.Interface;
using EatEasy.Application.ViewModels;
using FluentValidation.Results;
using AutoMapper;
using EatEasy.Domain.Core.Mediator;
using EatEasy.Domain.Interfaces;
using EatEasy.Domain.Commands.OrderCommands;
using EatEasy.Domain.Core.Domain;
using EatEasy.Domain.Enums;

namespace EatEasy.Application.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IMediatorHandler _mediator;

        public OrderAppService(IMapper mapper, IOrderRepository orderRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _mediator = mediator;
        }

        public void Dispose()
        {
            _orderRepository.Dispose();
        }

        public async Task<ValidationResult> RegisterAsync(OrderRegisterViewModel orderViewModel, CancellationToken cancellationToken)
        {
            var registerCommand = _mapper.Map<RegisterOrderCommand>(orderViewModel);
            return await _mediator.SendCommandAsync(registerCommand, cancellationToken);
        }

        public async Task<ValidationResult> UpdateStatus(Guid orderId, OrderStatus newStatus, CancellationToken cancellationToken)
        {
            var updateStatusCommand = new UpdateOrderStatusCommand(orderId, newStatus);
            return await _mediator.SendCommandAsync(updateStatusCommand, cancellationToken);
        }

        public async Task<IEnumerable<OrderViewModel>> GetAllAsync(string loggedUserRole, Guid loggedUserId, Guid? clientId, CancellationToken cancellationToken)
        {
            if (loggedUserRole == UserRoles.CLIENT)
            {
                return _mapper.Map<IEnumerable<OrderViewModel>>(await _orderRepository.GetByClientAsync(loggedUserId, cancellationToken));
            }

            return _mapper.Map<IEnumerable<OrderViewModel>>(await _orderRepository.GetAllAsync(clientId, cancellationToken));

        }

        public async Task<OrderViewModel> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _mapper.Map<OrderViewModel>(await _orderRepository.GetByIdAsync(id, cancellationToken));
        }
    }
}
