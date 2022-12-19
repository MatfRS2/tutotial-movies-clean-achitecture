using Ardalis.ApiEndpoints;
using Movies.Domain.PripremaContext.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Movies.Web.Endpoints.PaketEndpoints;

public class PretragaFilmova : EndpointBaseAsync
  .WithRequest<PretragaFilmovaRequest>
  .WithActionResult<PretragaFilmovaResponse>
{
  private readonly IPretragaPaketiFilmoviService _searchService;

  public PretragaFilmova(IPretragaPaketiFilmoviService searchService)
  {
    _searchService = searchService;
  }

  [HttpGet("/Paket/{PaketId}/PretragaFilmova")]
  [SwaggerOperation(
    Summary = "Gets a list of a paket's incomplete items",
    Description = "Gets a list of a paket's incomplete items",
    OperationId = "Paket.ListIncomplete",
    Tags = new[] { "PaketEndpoints" })
  ]
  public override async Task<ActionResult<PretragaFilmovaResponse>> HandleAsync(
    [FromQuery] PretragaFilmovaRequest request,
    CancellationToken cancellationToken = new())
  {
    if (request.SearchString == null)
    {
      return BadRequest();
    }

    var response = new PretragaFilmovaResponse(0, new List<FilmRecord>());
    var result = await _searchService.FilmoviUPaketuSaNaslovomAsync(request.PaketId, request.SearchString);

    if (result.Status == Ardalis.Result.ResultStatus.Ok)
    {
      response.PaketId = request.PaketId;
      //response.IncompleteItems = new List<FilmRecord>(
      //  result.Value.Select(
      //    item => new FilmRecord(item.Id,
      //      item.Naslov,
      //      item.Description,
      //      item.IsDone)));
    }
    else if (result.Status == Ardalis.Result.ResultStatus.Invalid)
    {
      return BadRequest(result.ValidationErrors);
    }
    else if (result.Status == Ardalis.Result.ResultStatus.NotFound)
    {
      return NotFound();
    }

    return Ok(response);
  }
}
