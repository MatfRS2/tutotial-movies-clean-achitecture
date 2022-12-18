using Ardalis.Specification;
using Movies.Domain.PripremaContext.FilmAgregate;

namespace Movies.Domain.ToDoContext.ContributorAggregate.Specifications;

public class ZanrByIdSpec : Specification<Zanr>, ISingleResultSpecification
{
  public ZanrByIdSpec(int zanrId)
  {
    Query
        .Where(tuple => tuple.Id == zanrId);
  }
}
