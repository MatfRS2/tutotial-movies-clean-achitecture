using Ardalis.Specification;
using Movies.Domain.PripremaContext.FilmAggregate;

namespace Movies.Domain.PripremaContext.FilmAggregate.Specifications;

public class SkupiFilmoviSpec : Specification<Film>
{
  public SkupiFilmoviSpec()
  {
    Query.Where(item => item.Ulozeno > 5);
  }
}
