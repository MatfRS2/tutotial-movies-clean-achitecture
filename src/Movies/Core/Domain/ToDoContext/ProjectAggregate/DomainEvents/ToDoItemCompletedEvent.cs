using Movies.SharedKernel.DomainEvents;

namespace Movies.Domain.ToDoContext.ProjectAggregate.DomainEvents;

public class ToDoItemCompletedEvent : DomainEventBase
{
  public ToDoItem CompletedItem { get; set; }

  public ToDoItemCompletedEvent(ToDoItem completedItem)
  {
    CompletedItem = completedItem;
  }
}
