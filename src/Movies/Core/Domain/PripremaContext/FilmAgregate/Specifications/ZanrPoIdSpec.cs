using Ardalis.Specification;
using Movies.Domain.PripremaContext.FilmAgregate;

namespace Movies.Domain.ToDoContext.ContributorAggregate.Specifications;

public class ZanrPoIdSpec : Specification<Zanr>, ISingleResultSpecification
{
  public ZanrPoIdSpec(int zanrId)
  {
    Query
        .Where(tuple => tuple.Id == zanrId);
  }
}
