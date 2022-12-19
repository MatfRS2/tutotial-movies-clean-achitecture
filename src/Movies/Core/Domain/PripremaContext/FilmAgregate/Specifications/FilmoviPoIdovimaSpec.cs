using Ardalis.Specification;
using Movies.Domain.PripremaContext.FilmAgregate;

namespace Movies.Domain.ToDoContext.ContributorAggregate.Specifications;

public class FilmoviPoIdovimaSpec : Specification<Film>, ISingleResultSpecification
{
  public FilmoviPoIdovimaSpec(IEnumerable<int> ids)
  {
    Query
        .Where(tuple => ids.Contains(tuple.Id) );
  }
}
