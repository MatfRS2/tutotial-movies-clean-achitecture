using Microsoft.AspNetCore.Mvc;

namespace Movies.Web.Endpoints.PaketEndpoints;

public class PretragaFilmovaRequest
{
  [FromRoute]
  public int PaketId { get; set; }
  [FromQuery]
  public string? SearchString { get; set; }
}
