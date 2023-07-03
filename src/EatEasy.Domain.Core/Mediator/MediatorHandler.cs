using EatEasy.Domain.Core.Messaging;
using MediatR;
using System.Runtime.CompilerServices;
using FluentValidation.Results;

namespace EatEasy.Domain.Core.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public virtual Task<ValidationResult> SendCommandAsync<T>(T command, CancellationToken cancellationToken) where T : Command
        {
            return _mediator.Send(command, cancellationToken);
        }

        public virtual Task PublishEventAsync<T>(T @event) where T : Event
        {
            return _mediator.Publish(@event);
        }
    }
}
