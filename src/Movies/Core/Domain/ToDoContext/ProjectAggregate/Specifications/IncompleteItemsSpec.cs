using Ardalis.Specification;

namespace Movies.Domain.ToDoContext.ProjectAggregate.Specifications;

public class IncompleteItemsSpec : Specification<ToDoItem>, ISingleResultSpecification
{
  public IncompleteItemsSpec()
  {
    Query.Where(item => !item.IsDone);
  }
}
