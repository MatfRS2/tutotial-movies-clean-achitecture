using Ardalis.Result;
using Movies.Domain.PripremaContext.FilmAggregate;

namespace Movies.Domain.PripremaContext.Services;

public interface IPretragaPaketiFilmoviService
{
  Task<Result<int>> FilmoviPaketuAsync(int paketId);
  Task<Result<List<int>>> FilmoviUPaketuSaNaslovomAsync(int paketId, string searchString);
}
