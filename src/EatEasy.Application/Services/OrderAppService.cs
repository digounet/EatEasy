using EatEasy.Application.Interface;
using EatEasy.Application.ViewModels;
using FluentValidation.Results;
using AutoMapper;
using EatEasy.Domain.Core.Mediator;
using EatEasy.Domain.Interfaces;
using EatEasy.Domain.Commands.OrderCommands;
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
    }
}
