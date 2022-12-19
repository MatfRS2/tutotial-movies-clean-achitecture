using Ardalis.Specification;
using Movies.Domain.PripremaContext.FilmAgregate;

namespace Movies.Domain.ToDoContext.ContributorAggregate.Specifications;

public class FilmPoIdSpec : Specification<Film>, ISingleResultSpecification
{
  public FilmPoIdSpec(int filmId)
  {
    Query
        .Where(item => item.Id == filmId);
  }
}
