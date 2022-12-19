using Movies.Domain.PripremaContext.FilmAggregate;
using Movies.SharedKernel.Repositories;
using FastEndpoints;

namespace Movies.Web.Endpoints.FilmEndpoints;

public class Update : Endpoint<UpdateFilmRequest, UpdateFilmResponse>
{
  private readonly IRepository<Film> _repository;

  public Update(IRepository<Film> repository)
  {
    _repository = repository;
  }

  public override void Configure()
  {
    Put(CreateFilmRequest.Route);
    AllowAnonymous();
    Options(x => x
      .WithTags("FilmEndpoints"));
  }
  public override async Task HandleAsync(
    UpdateFilmRequest request,
    CancellationToken cancellationToken)
  {
    if (request.Name == null)
    {
      ThrowError("Name is required");
    }

    var existingFilm = await _repository.GetByIdAsync(request.Id, cancellationToken);
    if (existingFilm == null)
    {
      await SendNotFoundAsync();
      return;
    }

    existingFilm.IzmeniNaslov(request.Name);

    await _repository.UpdateAsync(existingFilm, cancellationToken);

    var response = new UpdateFilmResponse(
        film: new FilmRecord(existingFilm.Id, existingFilm.Naslov, 
        existingFilm.DatumPocetkaPrikazivanja, existingFilm.Ulozeno)
    );

    await SendAsync(response);
  }
}
