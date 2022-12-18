using Ardalis.Specification;
using Movies.Domain.PripremaContext.FilmAgregate;

namespace Movies.Domain.ToDoContext.ContributorAggregate.Specifications;

public class ZanrByNazivSpec : Specification<Zanr>, ISingleResultSpecification
{
  public ZanrByNazivSpec(string zanrNaziv)
  {
    Query
        .Where(tuple => tuple.Naziv == zanrNaziv);
  }
}
