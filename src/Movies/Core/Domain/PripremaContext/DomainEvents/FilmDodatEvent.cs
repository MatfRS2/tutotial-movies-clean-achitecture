using Movies.SharedKernel.DomainEvents;

namespace Movies.Domain.PripremaContext.DomainEvents;

public class FilmDodatEvent : DomainEventBase
{
  public int FilmId { get; set; }

  public FilmDodatEvent(int filmId)
  {
    FilmId = filmId;
  }
}
