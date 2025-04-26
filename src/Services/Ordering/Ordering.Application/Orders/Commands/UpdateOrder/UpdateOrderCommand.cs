﻿namespace Ordering.Application.Orders.Commands.UpdateOrder
{
    public record UpdateOrderCommand(OrderDto Order)
        : ICommand<UpdateOrderResult>;
    
    public record UpdateOrderResult(bool IsSuccess);

    public class UpdateOrderCommandValidator: AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.Order.Id).NotEmpty().WithMessage("Id is rquired");
            RuleFor(x => x.Order.OrderName).NotEmpty().WithMessage("Name is rquired");
            RuleFor(x => x.Order.CustomerId).NotNull().WithMessage("CustomerId is rquired");
        }
    }
}
