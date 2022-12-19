using Ardalis.Specification;
using Movies.Domain.PripremaContext.FilmAgregate;

namespace Movies.Domain.ToDoContext.ContributorAggregate.Specifications;

public class ZanrPoNazivSpec : Specification<Zanr>, ISingleResultSpecification
{
  public ZanrPoNazivSpec(string zanrNaziv)
  {
    Query
        .Where(tuple => tuple.Naziv == zanrNaziv);
  }
}
