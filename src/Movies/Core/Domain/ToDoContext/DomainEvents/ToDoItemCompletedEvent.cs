using Movies.Domain.ToDoContext.ProjectAggregate;
using Movies.SharedKernel.DomainEvents;

namespace Movies.Domain.ToDoContext.DomainEvents;

public class ToDoItemCompletedEvent : DomainEventBase
{
  public ToDoItem CompletedItem { get; set; }

  public ToDoItemCompletedEvent(ToDoItem completedItem)
  {
    CompletedItem = completedItem;
  }
}
