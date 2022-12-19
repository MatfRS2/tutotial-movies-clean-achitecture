using Movies.Domain.ToDoContext.ProjectAggregate;
using Movies.SharedKernel.DomainEvents;

namespace Movies.Domain.ToDoContext.DomainEvents;

public class ContributorAddedToItemEvent : DomainEventBase
{
  public int ContributorId { get; set; }
  public ToDoItem Item { get; set; }

  public ContributorAddedToItemEvent(ToDoItem item, int contributorId)
  {
    Item = item;
    ContributorId = contributorId;
  }
}
