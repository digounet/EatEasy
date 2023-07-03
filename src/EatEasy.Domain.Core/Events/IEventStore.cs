using EatEasy.Domain.Core.Messaging;

namespace EatEasy.Domain.Core.Events
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
