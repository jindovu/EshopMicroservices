using BuildingBlocks.Exceptions;

namespace Ordering.Application.Exceptions
{
    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException(Guid id) : base("Order", id)
        {
        }

        public OrderNotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }
    }
}
