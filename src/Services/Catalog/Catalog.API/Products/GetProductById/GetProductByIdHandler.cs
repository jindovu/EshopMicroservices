namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdQuery(Guid Id) : IQuery<GetProductIdResult>;

    public record GetProductIdResult(Product Product);

    internal class GetProductByIdQueryHandler
        (IDocumentSession session)
        : IQueryHandler<GetProductByIdQuery, GetProductIdResult>
    {
        public async Task<GetProductIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(query.Id, cancellationToken);
            if (product is null)
            {
                throw new ProductNotFoundException(query.Id);
            }

            return new GetProductIdResult(product);
        }
    }
}
