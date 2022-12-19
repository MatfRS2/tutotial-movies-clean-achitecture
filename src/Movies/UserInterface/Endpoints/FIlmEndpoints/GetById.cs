using Movies.Domain.PripremaContext.FilmAggregate;
using Movies.SharedKernel.Repositories;
using FastEndpoints;
using Movies.Domain.ToDoContext.ContributorAggregate.Specifications;
using Movies.Domain.PripremaContext.FilmAggregate.Specifications;

namespace Movies.Web.Endpoints.FilmEndpoints;

public class GetById : Endpoint<GetFilmByIdRequest, FilmRecord>
{
  private readonly IRepository<Film> _repository;

  public GetById(IRepository<Film> repository)
  {
    _repository = repository;
  }

  public override void Configure()
  {
    Get(GetFilmByIdRequest.Route);
    AllowAnonymous();
    Options(x => x
      .WithTags("FilmEndpoints"));
  }
  public override async Task HandleAsync(GetFilmByIdRequest request, 
    CancellationToken cancellationToken)
  {
    var spec = new FilmPoIdSpec(request.FilmId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null)
    {
      await SendNotFoundAsync();
      return;
    }

    var response = new FilmRecord(entity.Id, entity.Naslov, entity.DatumPocetkaPrikazivanja, entity.Ulozeno);

    await SendAsync(response);
  }
}
