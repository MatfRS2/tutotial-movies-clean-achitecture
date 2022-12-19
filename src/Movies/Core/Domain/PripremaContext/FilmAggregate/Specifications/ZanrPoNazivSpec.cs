using Ardalis.Specification;
using Movies.Domain.PripremaContext.FilmAggregate;

namespace Movies.Domain.PripremaContext.FilmAggregate.Specifications;

public class ZanrPoNazivSpec : Specification<Zanr>, ISingleResultSpecification
{
  public ZanrPoNazivSpec(string zanrNaziv)
  {
    Query
        .Where(tuple => tuple.Naziv == zanrNaziv);
  }
}
