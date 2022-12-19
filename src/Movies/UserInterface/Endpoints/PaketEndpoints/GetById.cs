using Ardalis.ApiEndpoints;
using Movies.Domain.PripremaContext.PaketAggregate;
using Movies.Domain.PripremaContext.PaketAggregate.Specifications;
using Movies.SharedKernel.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Movies.Web.Endpoints.PaketEndpoints;

public class GetById : EndpointBaseAsync
  .WithRequest<GetPaketByIdRequest>
  .WithActionResult<GetPaketByIdResponse>
{
  private readonly IRepository<Paket> _repository;

  public GetById(IRepository<Paket> repository)
  {
    _repository = repository;
  }

  [HttpGet(GetPaketByIdRequest.Route)]
  [SwaggerOperation(
    Summary = "Gets a single Paket",
    Description = "Gets a single Paket by Id",
    OperationId = "Pakets.GetById",
    Tags = new[] { "PaketEndpoints" })
  ]
  public override async Task<ActionResult<GetPaketByIdResponse>> HandleAsync(
    [FromRoute] GetPaketByIdRequest request,
    CancellationToken cancellationToken = new())
  {
    var spec = new PaketSaFilmovimaPoPaketIdSpec(request.PaketId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null)
    {
      return NotFound();
    }

    var response = new GetPaketByIdResponse
    (
      id: entity.Id,
      name: entity.Naziv ,
      items: entity.Filmovi.Select(item => new FilmRecord(item.Id, "proba", new DateTime(1970,1,1), -1))
        .ToList()
    );

    return Ok(response);
  }
}
