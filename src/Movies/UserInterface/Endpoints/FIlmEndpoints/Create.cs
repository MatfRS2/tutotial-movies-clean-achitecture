using Movies.Domain.PripremaContext.FilmAggregate;
using Movies.SharedKernel.Repositories;
using FastEndpoints;

namespace Movies.Web.Endpoints.FilmEndpoints;

public class Create : Endpoint<CreateFilmRequest, CreateFilmResponse>
{
  private readonly IRepository<Film> _repository;

  public Create(IRepository<Film> repository)
  {
    _repository = repository;
  }

  public override void Configure()
  {
    Post(CreateFilmRequest.Route);
    AllowAnonymous();
    Options(x => x
      .WithTags("FilmEndpoints"));
  }
  public override async Task HandleAsync(
    CreateFilmRequest request,
    CancellationToken cancellationToken)
  {
    if (request.Naslov == null)
    {
      ThrowError("Name is required");
    }

    var newFilm = new Film(request.Naslov, request.DatumPocetkaPrikazivanja.GetValueOrDefault(),
      request.Ulozeno.GetValueOrDefault(), request.ZanrNaziv??"");
    var createdItem = await _repository.AddAsync(newFilm, cancellationToken);
    var response = new CreateFilmResponse
    (
      id: createdItem.Id,
      naslov: createdItem.Naslov,
      datumPocektPrikazivanja: createdItem.DatumPocetkaPrikazivanja,
      ulozeno: createdItem.Ulozeno
    );

    await SendAsync(response);
  }
}
