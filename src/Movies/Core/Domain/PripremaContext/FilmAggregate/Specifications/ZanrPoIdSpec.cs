using Ardalis.Specification;
using Movies.Domain.PripremaContext.FilmAggregate;

namespace Movies.Domain.PripremaContext.FilmAggregate.Specifications;

public class ZanrPoIdSpec : Specification<Zanr>, ISingleResultSpecification
{
  public ZanrPoIdSpec(int zanrId)
  {
    Query
        .Where(tuple => tuple.Id == zanrId);
  }
}
