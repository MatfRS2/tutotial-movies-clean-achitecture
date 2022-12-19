using Ardalis.Specification;

namespace Movies.Domain.ToDoContext.ProjectAggregate.Specifications;

public class IncompleteItemsSearchSpec : Specification<ToDoItem>, ISingleResultSpecification
{
  public IncompleteItemsSearchSpec(string searchString)
  {
    Query
        .Where(item => !item.IsDone &&
        (item.Title.Contains(searchString) ||
        item.Description.Contains(searchString)));
  }
}
