using Movies.SharedKernel.DomainEvents;

namespace Movies.Domain.ToDoContext.ContributorAggregate.DomainEvents;

public class ContributorDeletedEvent : DomainEventBase
{
  public int ContributorId { get; set; }

  public ContributorDeletedEvent(int contributorId)
  {
    ContributorId = contributorId;
  }
}
