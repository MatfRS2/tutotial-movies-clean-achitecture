using Ardalis.ApiEndpoints;
using Movies.Domain.PripremaContext.PaketAggregate;
using Movies.SharedKernel.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Movies.Web.Endpoints.PaketEndpoints;

public class List : EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<PaketListResponse>
{
  private readonly IReadRepository<Paket> _repository;

  public List(IReadRepository<Paket> repository)
  {
    _repository = repository;
  }

  [HttpGet("/Paket")]
  [SwaggerOperation(
      Summary = "Gets a list of all Pakets",
      Description = "Gets a list of all Pakets",
      OperationId = "Paket.List",
      Tags = new[] { "PaketEndpoints" })
  ]
  public override async Task<ActionResult<PaketListResponse>> HandleAsync(
    CancellationToken cancellationToken = new())
  {
    var pakets = await _repository.ListAsync(cancellationToken);
    var response = new PaketListResponse
    {
      Pakets = pakets
        .Select(paket => new PaketRecord(paket.Id, paket.Naziv, paket.Opis, paket.DatumFormiranja))
        .ToList()
    };

    return Ok(response);
  }
}
