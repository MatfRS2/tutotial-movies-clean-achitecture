using Ardalis.Specification;
using Movies.Domain.PripremaContext.FilmAggregate;

namespace Movies.Domain.PripremaContext.PaketAggregate.Specifications;

public class FilmoviUPaketuPoPaketIdSpec : Specification<Paket>, ISingleResultSpecification
{
  public FilmoviUPaketuPoPaketIdSpec(int paketId)
  {
    Query
        .Where(paket => paket.Id == paketId)
        .Include(paket => paket.Filmovi)
        .ThenInclude(fp => fp.FilmId);
  }
}
