using Movies.SharedKernel.Repositories;
using MediatR;
using Movies.Domain.PripremaContext.DomainEvents;
using Movies.Domain.PripremaContext.PaketAggregate.Specifications;

namespace Movies.Domain.PripremaContext.PaketAggregate;

public class FilmObrisanHandler : INotificationHandler<FilmObrisanEvent>
{
  private readonly IRepository<Paket> _repository;

  public FilmObrisanHandler(IRepository<Paket> repository)
  {
    _repository = repository;
  }

  public async Task Handle(FilmObrisanEvent domainEvent, CancellationToken cancellationToken)
  {
    var paketSpec = new PaketiSaFilmovimaPoFilmIdSpec(domainEvent.FilmId);
    var paketi = await _repository.ListAsync(paketSpec);
    foreach (var paket in paketi)
    {
      var filmIdovi = paket.Filmovi
        .Where(item => item.FilmId == domainEvent.FilmId)
        .Select( item => item.FilmId)
        .ToList();
      foreach (var filmId in filmIdovi)
        paket.UkloniFilmPoId(filmId);
      await _repository.UpdateAsync(paket);
    }
  }
}
