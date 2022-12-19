using System.ComponentModel.DataAnnotations;

namespace Movies.Web.Endpoints.PaketEndpoints;

public class UpdatePaketRequest
{
  public const string Route = "/Paket";
  [Required]
  public int Id { get; set; }
  [Required]
  public string? Name { get; set; }
}
