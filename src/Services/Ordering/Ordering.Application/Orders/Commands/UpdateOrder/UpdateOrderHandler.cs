namespace Ordering.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderHandler(IApplicationDbContext dbContext)
        : ICommandHandler<UpdateOrderCommand, UpdateOrderResult>
    {
        public async Task<UpdateOrderResult> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            var orderId = OrderId.Of(command.Order.Id);
            var order = await dbContext.Orders
                .FindAsync([orderId], cancellationToken: cancellationToken);

            if (order is null)
            {
                throw new OrderNotFoundException(command.Order.Id);
            }

            UpdateOrderWithNewValues(order, command.Order);

            dbContext.Orders.Update(order);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new UpdateOrderResult(true);
        }

        public void UpdateOrderWithNewValues(Order order, OrderDto orderDto)
        {
            var shippingDto = orderDto.ShippingAddress;
            var billingDto = orderDto.BillingAddress;
            var updateShippingAddress = Address.Of(shippingDto.FirstName, shippingDto.LastName, shippingDto.EmailAddress, shippingDto.AddressLine, shippingDto.Country, shippingDto.State, shippingDto.ZipCode);
            var updateBillingAddress = Address.Of(billingDto.FirstName, billingDto.LastName, billingDto.EmailAddress, billingDto.AddressLine, billingDto.Country, billingDto.State, billingDto.ZipCode);
            var updatePayment = Payment.Of(orderDto.Payment.CardName, orderDto.Payment.CardNumber, orderDto.Payment.Expiration, orderDto.Payment.CVV, orderDto.Payment.PaymentMethod);

            order.Update(
                orderName: OrderName.Of(orderDto.OrderName),
                shippingAddress: updateBillingAddress,
                billingAddress: updateShippingAddress,
                payment: updatePayment,
               status: orderDto.Status
               );
        }
    }
}
