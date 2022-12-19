using Ardalis.Result;
using Movies.SharedKernel.Repositories;
using MediatR;
using Movies.Domain.PripremaContext.Services;
using Movies.Domain.PripremaContext.FilmAgregate;
using Movies.Domain.PripremaContext.DomainEvents;

public class ObrisiFilmService : IObrisiFilmService
{
  private readonly IRepository<Film> _repository;
  private readonly IMediator _mediator;

  public ObrisiFilmService(IRepository<Film> repository, IMediator mediator)
  {
    _repository = repository;
    _mediator = mediator;
  }

  public async Task<Result> ObrisiFilm(int filmId)
  {
    var aggregateToDelete = await _repository.GetByIdAsync(filmId);
    if (aggregateToDelete == null) 
      return Result.NotFound();

    await _repository.DeleteAsync(aggregateToDelete);
    var domainEvent = new FilmObrisanEvent(filmId);
    await _mediator.Publish(domainEvent);
    return Result.Success();
  }
}
