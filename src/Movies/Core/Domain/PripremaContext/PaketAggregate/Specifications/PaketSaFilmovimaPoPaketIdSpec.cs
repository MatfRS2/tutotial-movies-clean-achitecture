using Ardalis.Specification;

namespace Movies.Domain.PripremaContext.PaketAggregate.Specifications;

public class PaketSaFilmovimaPoPaketIdSpec : Specification<Paket>, ISingleResultSpecification
{
  public PaketSaFilmovimaPoPaketIdSpec(int paketId)
  {
    Query
        .Where(paket => paket.Id == paketId)
        .Include(paket => paket.Filmovi);
  }
}
