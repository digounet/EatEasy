using EatEasy.Domain.Core.Messaging;
using FluentValidation.Results;

namespace EatEasy.Domain.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEventAsync<T>(T @event) where T : Event;
        Task<ValidationResult> SendCommandAsync<T>(T command, CancellationToken cancellationToken) where T : Command;
    }
}
