using Movies.Domain.PripremaContext.FilmAgregate;
using Movies.Domain.PripremaContext.PaketAgregate;
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
