using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync())
                return;

            session.Store<Product>(GetPreconfiguredProducts());
            await session.SaveChangesAsync();
        }

        private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>()
        {
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "IPhone X",
                Description = "This phone is the company's biggest change to its",
                ImageFile = "product-1.png",
                Price = 950.00M,
                Category = new List<string>{"Smart Phone"}
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Samsung 10",
                Description = "This phone is the company's biggest change to its",
                ImageFile = "product-2.png",
                Price = 840,
                Category = new List<string>{"Smart Phone"}
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Xaomi Mi 9",
                Description = "This phone is the company's biggest change to its",
                ImageFile = "product-3.png",
                Price = 840,
                Category = new List<string>{"Smart Phone"}
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Name = "HTC U11+ Plus",
                Description = "This phone is the company's biggest change to its",
                ImageFile = "product-4.png",
                Price = 840,
                Category = new List<string>{"Smart Phone"}
            },
        };
    }
}
