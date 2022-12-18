using Movies.Domain.PripremaContext.FilmAgregate;
using Movies.SharedKernel.DomainEvents;

namespace Movies.Domain.PripremaContext.DomainEvents;

public class FilmDodatUPaketEvent : DomainEventBase
{
  public Paket Paket { get; set; }
  public Film Film { get; set; }

  public FilmDodatUPaketEvent(Paket paket, Film film)
  {
    Paket = paket;
    Film = film;
  }
}
