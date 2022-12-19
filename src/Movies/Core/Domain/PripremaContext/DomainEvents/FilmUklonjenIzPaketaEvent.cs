using Movies.Domain.PripremaContext.FilmAgregate;
using Movies.Domain.PripremaContext.PaketAgregate;
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
