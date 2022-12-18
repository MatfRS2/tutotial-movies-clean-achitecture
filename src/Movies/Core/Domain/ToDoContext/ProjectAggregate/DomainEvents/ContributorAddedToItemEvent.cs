using Movies.Domain.ToDoContext.ContributorAggregate;
using Movies.SharedKernel.DomainEvents;

namespace Movies.Domain.ToDoContext.ProjectAggregate.DomainEvents;

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
