using Movies.Domain.PripremaContext.FilmAggregate;
using Movies.Domain.PripremaContext.PaketAggregate;
using Movies.SharedKernel.DomainEvents;

namespace Movies.Domain.PripremaContext.DomainEvents;

public class FilmDodatUPaketEvent : DomainEventBase
{
  public int PaketId { get; set; }
  public int FilmId { get; set; }

  public FilmDodatUPaketEvent(int paketId, int filmId)
  {
    PaketId = paketId;
    FilmId = filmId;
  }
}
