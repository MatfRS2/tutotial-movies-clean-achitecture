using Ardalis.Result;

namespace Movies.Domain.ToDoContext.Interfaces;

public interface IDeleteContributorService
{
  public Task<Result> DeleteContributor(int contributorId);
}
