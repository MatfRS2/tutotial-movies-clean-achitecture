using Ardalis.Specification;

namespace Movies.Domain.PripremaContext.PaketAgregate.Specifications;

public class PaketiSaFilmovimaPoFilmIdSpec : Specification<Paket>, ISingleResultSpecification
{
  public PaketiSaFilmovimaPoFilmIdSpec(int filmId)
  {
    Query
        .Where(paket => paket.Filmovi.Where(item => item.FilmId == filmId).Any())
        .Include(paket => paket.Filmovi);
  }
}
