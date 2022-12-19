using Movies.Domain.PripremaContext.FilmAggregate;
using Movies.Domain.PripremaContext.PaketAggregate;
using Movies.SharedKernel.DomainEvents;

namespace Movies.Domain.PripremaContext.DomainEvents;

public class FilmUklonjenIzPaketaEvent : DomainEventBase
{
  public int PaketId { get; set; }
  public int FilmId { get; set; }

  public FilmUklonjenIzPaketaEvent(int paketId, int filmId)
  {
    PaketId = paketId;
    FilmId = filmId;
  }

}
