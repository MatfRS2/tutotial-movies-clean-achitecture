using Ardalis.Specification;
using Movies.Domain.PripremaContext.FilmAggregate;

namespace Movies.Domain.PripremaContext.FilmAggregate.Specifications;

public class SkupiFilmoviNaslovSpec : Specification<Film>
{
  public SkupiFilmoviNaslovSpec(string searchString)
  {
    Query
        .Where(item => item.Ulozeno > 5 &&
        item.Naslov.Contains(searchString));
  }
}
