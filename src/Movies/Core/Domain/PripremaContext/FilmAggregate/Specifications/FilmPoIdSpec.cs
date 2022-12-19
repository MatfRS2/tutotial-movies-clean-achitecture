using Ardalis.Specification;
using Movies.Domain.PripremaContext.FilmAggregate;

namespace Movies.Domain.PripremaContext.FilmAggregate.Specifications;

public class FilmPoIdSpec : Specification<Film>, ISingleResultSpecification
{
  public FilmPoIdSpec(int filmId)
  {
    Query
        .Where(item => item.Id == filmId);
  }
}
