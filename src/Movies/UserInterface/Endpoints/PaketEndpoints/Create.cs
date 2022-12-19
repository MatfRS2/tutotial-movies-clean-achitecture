using Ardalis.ApiEndpoints;
using Movies.Domain.PripremaContext.PaketAggregate;
using Movies.SharedKernel.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Cryptography.Xml;

namespace Movies.Web.Endpoints.PaketEndpoints;

public class Create : EndpointBaseAsync
  .WithRequest<CreatePaketRequest>
  .WithActionResult<CreatePaketResponse>
{
  private readonly IRepository<Paket> _repository;

  public Create(IRepository<Paket> repository)
  {
    _repository = repository;
  }

  [HttpPost("/Paket")]
  [SwaggerOperation(
    Summary = "Creates a new Paket",
    Description = "Creates a new Paket",
    OperationId = "Paket.Create",
    Tags = new[] { "PaketEndpoints" })
  ]
  public override async Task<ActionResult<CreatePaketResponse>> HandleAsync(
    CreatePaketRequest request,
    CancellationToken cancellationToken = new())
  {
    if (request.Naziv == null)
    {
      return BadRequest();
    }

    var newPaket = new Paket(request.Naziv, request.Opis??"", request.DatumFormiranja.GetValueOrDefault());
    var createdItem = await _repository.AddAsync(newPaket, cancellationToken);
    var response = new CreatePaketResponse
    (
      id: createdItem.Id,
      naziv: createdItem.Naziv,
      opis: createdItem.Opis,
      datumFormiranja: createdItem.DatumFormiranja
    );

    return Ok(response);
  }
}
