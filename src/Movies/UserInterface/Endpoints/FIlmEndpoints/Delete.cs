using FastEndpoints;
using Ardalis.Result;
using Movies.Domain.PripremaContext.Services;
using Ardalis.GuardClauses;

namespace Movies.Web.Endpoints.FilmEndpoints;

public class Delete : Endpoint<ObrisiFilmRequest>
{

  private readonly IObrisiFilmService _obrisiFilmService;

  public Delete(IObrisiFilmService service)
  {
    _obrisiFilmService = Guard.Against.Null( service, nameof(service));
  }

  public override void Configure()
  {
    Delete(ObrisiFilmRequest.Route);
    AllowAnonymous();
    Options(x => x
      .WithTags("FilmEndpoints"));
  }
  public override async Task HandleAsync(
    ObrisiFilmRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _obrisiFilmService.ObrisiFilm(request.FilmId);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync();
      return;
    }

    await SendNoContentAsync();
  }
}
