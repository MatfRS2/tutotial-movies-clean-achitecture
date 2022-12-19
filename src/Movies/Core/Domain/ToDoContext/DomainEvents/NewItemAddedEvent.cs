using Movies.Domain.ToDoContext.ProjectAggregate;
using Movies.SharedKernel.DomainEvents;

namespace Movies.Domain.ToDoContext.DomainEvents;

public class NewItemAddedEvent : DomainEventBase
{
  public ToDoItem NewItem { get; set; }
  public Project Project { get; set; }

  public NewItemAddedEvent(Project project,
      ToDoItem newItem)
  {
    Project = project;
    NewItem = newItem;
  }
}
