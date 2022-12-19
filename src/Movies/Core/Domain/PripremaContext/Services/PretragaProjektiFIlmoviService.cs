using Ardalis.Result;
using Movies.Domain.PripremaContext.Services;
using Movies.SharedKernel.Repositories;
using MediatR;
using Movies.Domain.PripremaContext.FilmAggregate;
using Movies.Domain.PripremaContext.PaketAggregate;
using Movies.Domain.PripremaContext.DomainEvents;
using Movies.Domain.PripremaContext.PaketAggregate.Specifications;
using Movies.Domain.PripremaContext.FilmAggregate.Specifications;

namespace Movies.Domain.PripremaContext.Services;

public class PretragaPaketiFilmoviService : IPretragaPaketiFilmoviService
{
  private readonly IRepository<Paket> _repositoryP;
  private readonly IRepository<Film> _repositoryF;

  public PretragaPaketiFilmoviService(IRepository<Paket> repositoryP,
            IRepository<Film> repositoryF)
  {
    _repositoryP = repositoryP;
    _repositoryF = repositoryF;
  }

  public async Task<Result<List<int>>> FilmoviUPaketuSaNaslovomAsync(int paketId, string searchString)
  {
    if (string.IsNullOrEmpty(searchString))
    {
      var errors = new List<ValidationError>
      {
        new() { 
          Identifier = nameof(searchString), 
          ErrorMessage = $"{nameof(searchString)} is required." 
        }
      };
      return Result<List<int>>.Invalid(errors);
    }
    var paketSpec = new PaketSaFilmovimaPoPaketIdSpec(paketId);
    var paket = await _repositoryP.FirstOrDefaultAsync(paketSpec);
    // TODO: Optionally use Ardalis.GuardClauses Guard.Against.NotFound and catch
    if (paket == null)
    {
      return Result<List<int>>.NotFound();
    }
    var skupoSpec = new SkupiFilmoviNaslovSpec(searchString);
    //var items = skupoSpec.Evaluate(paket.Filmovi).ToList();
    var items = paket.Filmovi;
    try
    {
      List<int> rezultat = new List<int>();
      foreach(var fp in items)
        rezultat.Add(fp.FilmId);
      return rezultat;
    }
    catch (Exception ex)
    {
      // TODO: Log details here
      return Result<List<int>>.Error(new[] { ex.Message });
    }
  }

  public async Task<Result<int>> FilmoviPaketuAsync(int paketId)
  {
    var paketSpec = new PaketSaFilmovimaPoPaketIdSpec(paketId);
    var paket = await _repositoryP.FirstOrDefaultAsync(paketSpec);
    if (paket == null)
    {
      return Result<int>.NotFound();
    }
    var skupoSpec = new SkupiFilmoviSpec();
    //var items = skupoSpec.Evaluate(paket.Filmovi).ToList();
    var items = paket.Filmovi;
    if (!items.Any())
    {
      return Result<int>.NotFound();
    }
    return items.First().FilmId;
  }
}
