using Ardalis.ApiEndpoints;
using Movies.Domain.PripremaContext.PaketAggregate;
using Movies.SharedKernel.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Movies.Web.Endpoints.PaketEndpoints;

public class Delete : EndpointBaseAsync
    .WithRequest<DeletePaketRequest>
    .WithoutResult
{
  private readonly IRepository<Paket> _repository;

  public Delete(IRepository<Paket> repository)
  {
    _repository = repository;
  }

  [HttpDelete(DeletePaketRequest.Route)]
  [SwaggerOperation(
      Summary = "Deletes a Paket",
      Description = "Deletes a Paket",
      OperationId = "Pakets.Delete",
      Tags = new[] { "PaketEndpoints" })
  ]
  public override async Task<ActionResult> HandleAsync(
    [FromRoute] DeletePaketRequest request,
      CancellationToken cancellationToken = new())
  {
    var aggregateToDelete = await _repository.GetByIdAsync(request.PaketId, cancellationToken);
    if (aggregateToDelete == null)
    {
      return NotFound();
    }

    await _repository.DeleteAsync(aggregateToDelete, cancellationToken);

    return NoContent();
  }
}
