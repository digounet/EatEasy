using MediatR;
using Microsoft.Extensions.Logging;

namespace EatEasy.Domain.Events
{
    public class OrderEventHandler : 
        INotificationHandler<OrderRegisteredEvent>,
        INotificationHandler<OrderUpdatedEvent>
    {
        private readonly ILogger<OrderEventHandler> _logger;

        public OrderEventHandler(ILogger<OrderEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(OrderRegisteredEvent notification, CancellationToken cancellationToken)
        {
            // Not implemented yet. But here, is possible send a notification to refresh kitchen monitor/printer
            // to start the order preparation and also send an email to the user to confirm the order
            // At this point the order will be already saved on the DB and the cookie can get order details
            // consuming the GetOrderById method.

            _logger.LogInformation($"New order received: {notification.OrderId}. Sequence: {notification.Sequence}");

            return Task.CompletedTask;
        }

        public Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
        {
            // Not implemented yet. But here, is possible send a notification to to the client and to the
            // restaurant monitor do update the order status

            _logger.LogInformation($"Order updated: {notification.OrderId}. New status: {notification.OrderStatus}");

            return Task.CompletedTask;
        }
    }
}
