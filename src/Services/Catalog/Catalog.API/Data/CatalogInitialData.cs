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
                Id = Guid.Parse("ea0d30ac-86dc-4a24-bc47-a0ba544b2b17"),
                Name = "IPhone X",
                Description = "This phone is the company's biggest change to its",
                ImageFile = "product-1.png",
                Price = 950.00M,
                Category = new List<string>{"Smart Phone"}
            },
            new Product()
            {
                Id = Guid.Parse("ec51a385-40ce-4cca-b6d5-0b289512b490"),
                Name = "Samsung 10",
                Description = "This phone is the company's biggest change to its",
                ImageFile = "product-2.png",
                Price = 840,
                Category = new List<string>{"Smart Phone"}
            },
            new Product()
            {
                Id = Guid.Parse("2fe1bfd7-18b5-4f2e-b719-87a8065ac64e"),
                Name = "Xaomi Mi 9",
                Description = "This phone is the company's biggest change to its",
                ImageFile = "product-3.png",
                Price = 840,
                Category = new List<string>{"Smart Phone"}
            },
            new Product()
            {
                 Id = Guid.Parse("fbe88a3d-715a-4bb9-a44b-00cfa3cacc23"),
                Name = "HTC U11+ Plus",
                Description = "This phone is the company's biggest change to its",
                ImageFile = "product-4.png",
                Price = 840,
                Category = new List<string>{"Smart Phone"}
            },
        };
    }
}
