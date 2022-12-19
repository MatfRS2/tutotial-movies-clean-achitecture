using Movies.Domain.PripremaContext.FilmAggregate;
using Movies.SharedKernel.Repositories;
using FastEndpoints;

namespace Movies.Web.Endpoints.FilmEndpoints;

public class List : EndpointWithoutRequest<FilmListResponse>
{
  private readonly IRepository<Film> _repository;

  public List(IRepository<Film> repository)
  {
    _repository = repository;
  }

  public override void Configure()
  {
    Get("/Film");
    AllowAnonymous();
    Options(x => x
      .WithTags("FilmEndpoints"));
  }
  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var films = await _repository.ListAsync(cancellationToken);
    var response = new FilmListResponse()
    {
      Films = films
        .Select(paket => new FilmRecord(paket.Id, paket.Naslov, paket.DatumPocetkaPrikazivanja, paket.Ulozeno))
        .ToList()
    };

    await SendAsync(response);
  }
}
