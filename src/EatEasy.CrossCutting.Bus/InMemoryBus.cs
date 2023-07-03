using EatEasy.Domain.Core.Mediator;
using EatEasy.Domain.Core.Messaging;
using MediatR;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace EatEasy.CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishEventAsync<T>(T @event) where T : Event
        {
            await _mediator.Publish(@event);
        }

        public async Task<ValidationResult> SendCommandAsync<T>(T command, CancellationToken cancellationToken) where T : Command
        {
            return await _mediator.Send(command, cancellationToken);
        }
    }
}