using MediatR;

namespace Movies.SharedKernel.DomainEvents;

public abstract class DomainEventBase : INotification
{
  public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}
