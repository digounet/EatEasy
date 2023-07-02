using MediatR;

namespace EatEasy.Domain.Events
{
    public class OrderEventHandler : INotificationHandler<OrderRegisteredEvent>
    {
        public Task Handle(OrderRegisteredEvent notification, CancellationToken cancellationToken)
        {
            // NOt implemented yet. But here, is possible send a notification to the kitchen
            // to start the order preparation and also send an email to the user to confirm the order

            return Task.CompletedTask;
        }
    }
}
