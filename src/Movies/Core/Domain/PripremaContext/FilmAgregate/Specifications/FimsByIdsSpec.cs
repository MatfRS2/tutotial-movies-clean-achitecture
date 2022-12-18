using Ardalis.Specification;
using Movies.Domain.PripremaContext.FilmAgregate;

namespace Movies.Domain.ToDoContext.ContributorAggregate.Specifications;

public class FilmsByIdsSpec : Specification<Film>
{
  public FilmsByIdsSpec(IEnumerable<int> ids)
  {
    Query
        .Where(tuple => ids.Contains(tuple.Id) );
  }
}
