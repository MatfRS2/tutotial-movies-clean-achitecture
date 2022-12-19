
using Movies.SharedKernel.DomainObjects;

namespace Movies.SharedKernel.DomainEvents;

public interface IDomainEventDispatcher
{
  Task DispatchAndClearEvents(IEnumerable<EntityBase> entitiesWithEvents);
}
