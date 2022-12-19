using Ardalis.Specification;
using Movies.Domain.PripremaContext.FilmAggregate;

namespace Movies.Domain.PripremaContext.FilmAggregate.Specifications;

public class FilmoviPoIdovimaSpec : Specification<Film>, ISingleResultSpecification
{
  public FilmoviPoIdovimaSpec(IEnumerable<int> ids)
  {
    Query
        .Where(tuple => ids.Contains(tuple.Id) );
  }
}
