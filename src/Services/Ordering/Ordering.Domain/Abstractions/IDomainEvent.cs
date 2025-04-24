using MediatR;

namespace Ordering.Domain.Abstractions
{
    public record IDomainEvent : INotification
    {
        Guid EventId => Guid.NewGuid();
        public DateTime OccurredOn => DateTime.UtcNow;
        public string EventType => GetType().AssemblyQualifiedName;

    }
}
