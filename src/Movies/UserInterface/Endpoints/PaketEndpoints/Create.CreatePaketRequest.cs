using System.ComponentModel.DataAnnotations;

namespace Movies.Web.Endpoints.PaketEndpoints;

public class CreatePaketRequest
{
  public const string Route = "/Paket";

  [Required]
  public string? Naziv { get; set; }
  [Required]
  public string? Opis { get; set; }
  [Required]
  public DateTime? DatumFormiranja { get; set; }
}
