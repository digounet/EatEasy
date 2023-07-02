using EatEasy.Domain.Core.Events;
using EatEasy.Domain.Core.Mediator;
using EatEasy.Domain.Core.Messaging;
using MediatR;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace EatEasy.CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;

        public async Task PublishEventAsync<T>(T @event) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                _eventStore?.Save(@event);

            await _mediator.Publish(@event);
        }

        public async Task<ValidationResult> SendCommandAsync<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }
    }
}