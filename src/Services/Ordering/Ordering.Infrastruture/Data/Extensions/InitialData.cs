namespace Ordering.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        public static IEnumerable<Customer> Customers =>
            new List<Customer>()
            {
                Customer.Create(CustomerId.Of(new Guid("344dd904-a008-4e0b-b6d6-2c2b23d25996")),"mehmet", "mehmet@gmail.com"),
                Customer.Create(CustomerId.Of(new Guid("33222ab9-1d1b-48b1-af16-3ad61002d371")), "john", "john@gmail.com")
            };

        public static IEnumerable<Product> Products =>
            new List<Product>()
            {
                Product.Create(ProductId.Of(new Guid("a3f2871f-21a9-4e4a-9189-99b438aeace1")),"IPhone X", 500),
                Product.Create(ProductId.Of(new Guid("95d442f7-6fe0-4836-9fbb-91e0700899e3")), "Samsung 10", 400),
                Product.Create(ProductId.Of(new Guid("3798c190-5bd9-4cae-9b5a-c6bdbabc2814")), "Huawei Plus", 650),
                Product.Create(ProductId.Of(new Guid("67487728-3b1b-4b87-bb96-838650474fa5")), "Xiaomi Mi", 450)
            };

        public static IEnumerable<Order> OrdersWithItems
        {
            get
            {
                var address1 = Address.Of("mehmet", "ozkaya", "mehmet@gmail.com", "Bahcelievler No:4", "Turket", "Istanbul", "38050");
                var address2 = Address.Of("john", "doe", "john@gmail.com", "Broadway No:4", "England", "Nottingham", "08050");

                var payment1 = Payment.Of("mehmet", "555555555554444", "12/28", "355", 1);
                var payment2 = Payment.Of("john", "8888888884444", "06/03", "222", 2);

                var order1 = Order.Create(
                    OrderId.Of(Guid.NewGuid()),
                    CustomerId.Of(new Guid("344dd904-a008-4e0b-b6d6-2c2b23d25996")),
                    OrderName.Of("ORD_1"),
                    shippingAddress: address1,
                    billingAddress: address1,
                    payment: payment1);

                order1.Add(ProductId.Of(new Guid("a3f2871f-21a9-4e4a-9189-99b438aeace1")), 2, 500);
                order1.Add(ProductId.Of(new Guid("95d442f7-6fe0-4836-9fbb-91e0700899e3")), 1, 400);

                var order2 = Order.Create(
                    OrderId.Of(Guid.NewGuid()),
                    CustomerId.Of(new Guid("33222ab9-1d1b-48b1-af16-3ad61002d371")),
                    OrderName.Of("ORD_2"),
                    shippingAddress: address2,
                    billingAddress: address2,
                    payment: payment2);

                order2.Add(ProductId.Of(new Guid("3798c190-5bd9-4cae-9b5a-c6bdbabc2814")), 2, 560);
                order2.Add(ProductId.Of(new Guid("67487728-3b1b-4b87-bb96-838650474fa5")), 1, 450);

                return new List<Order> { order1, order2 };
            }
        }
    }
}
