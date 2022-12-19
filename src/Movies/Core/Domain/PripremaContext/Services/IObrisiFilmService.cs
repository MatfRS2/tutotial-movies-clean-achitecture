using Ardalis.Result;

namespace Movies.Domain.PripremaContext.Services;

public interface IObrisiFilmService
{
  public Task<Result> ObrisiFilm(int filmId);
}
