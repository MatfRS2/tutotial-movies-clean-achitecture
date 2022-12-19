using Movies.SharedKernel.DomainEvents;

namespace Movies.Domain.PripremaContext.DomainEvents;

public class FilmObrisanEvent : DomainEventBase
{
  public int FilmId { get; set; }

  public FilmObrisanEvent(int filmId)
  {
    FilmId = filmId;
  }
}
