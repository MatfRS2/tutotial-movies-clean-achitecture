using Ardalis.Result;
using Movies.Domain.ToDoContext.ProjectAggregate;

namespace Movies.Domain.ToDoContext.Interfaces;

public interface IToDoItemSearchService
{
  Task<Result<ToDoItem>> GetNextIncompleteItemAsync(int projectId);
  Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(int projectId, string searchString);
}
