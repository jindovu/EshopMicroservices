﻿namespace Basket.API.Basket.CheckoutBasket
{
    public record CheckoutBasketRequest(BasketCheckoutDto BasketCheckoutDto);

    public record CheckoutBasketResponse(bool IsSuccess);

    public class CheckoutBasketEnpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket/checkout", async (CheckoutBasketRequest request, ISender sender) =>
            {
                var command = request.Adapt<CheckoutBasketCommand>();
                var result = await sender.Send(command);

                var response = result.Adapt<CheckoutBasketResponse>();

                return Results.Ok(response);
            })
             .WithName("CheckoutBasket")
            .Produces<CheckoutBasketResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Checkout Basket")
            .WithDescription("Checkout Basket");
        }
    }
}
