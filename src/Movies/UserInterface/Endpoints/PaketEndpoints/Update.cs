using Ardalis.ApiEndpoints;
using Movies.Domain.PripremaContext.PaketAggregate;
using Movies.SharedKernel.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Movies.Web.Endpoints.PaketEndpoints;

public class Update : EndpointBaseAsync
    .WithRequest<UpdatePaketRequest>
    .WithActionResult<UpdatePaketResponse>
{
  private readonly IRepository<Paket> _repository;

  public Update(IRepository<Paket> repository)
  {
    _repository = repository;
  }

  [HttpPut(UpdatePaketRequest.Route)]
  [SwaggerOperation(
      Summary = "Updates a Paket",
      Description = "Updates a Paket with a longer description",
      OperationId = "Pakets.Update",
      Tags = new[] { "PaketEndpoints" })
  ]
  public override async Task<ActionResult<UpdatePaketResponse>> HandleAsync(
    UpdatePaketRequest request,
      CancellationToken cancellationToken = new ())
  {
    if (request.Name == null)
    {
      return BadRequest();
    }

    var existingPaket = await _repository.GetByIdAsync(request.Id, cancellationToken);
    if (existingPaket == null)
    {
      return NotFound();
    }

    existingPaket.IzmeniNaziv(request.Name);

    await _repository.UpdateAsync(existingPaket, cancellationToken);

    var response = new UpdatePaketResponse(
        paket: new PaketRecord(existingPaket.Id, existingPaket.Naziv, existingPaket.Opis,
          existingPaket.DatumFormiranja)
    );

    return Ok(response);
  }
}
