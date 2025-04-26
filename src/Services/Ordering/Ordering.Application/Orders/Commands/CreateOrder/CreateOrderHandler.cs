namespace Ordering.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderHandler(IApplicationDbContext dbContext)
        : ICommandHandler<CreateOrderCommand, CreateOrderResult>
    {
        public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var order = CreateNewOrder(command.Order);
            dbContext.Orders.Add(order);

            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreateOrderResult(order.Id.Value);
        }

        private Order CreateNewOrder(OrderDto orderDto)
        {
            var shippingDto = orderDto.ShippingAddress;
            var billingDto = orderDto.BillingAddress;
            var shippingAddress = Address.Of(shippingDto.FirstName, shippingDto.LastName, shippingDto.EmailAddress, shippingDto.AddressLine, shippingDto.Country, shippingDto.State, shippingDto.ZipCode);
            var billingAddress = Address.Of(billingDto.FirstName, billingDto.LastName, billingDto.EmailAddress, billingDto.AddressLine, billingDto.Country, billingDto.State, billingDto.ZipCode);

            var newOrder = Order.Create(
                id: OrderId.Of(Guid.NewGuid()),
                customerId: CustomerId.Of(orderDto.CustomerId),
                orderName: OrderName.Of(orderDto.OrderName),
                shippingAddress: shippingAddress,
                billingAddress: billingAddress,
                payment: Payment.Of(orderDto.Payment.CardName, orderDto.Payment.CardNumber, orderDto.Payment.Expiration, orderDto.Payment.CVV, orderDto.Payment.PaymentMethod)
                );

            foreach (var orderItemDto in orderDto.OrderItems)
            {
                newOrder.Add(ProductId.Of(orderItemDto.ProductId), orderItemDto.Quantity, orderItemDto.Price);
            }

            return newOrder;
        }
    }
}
