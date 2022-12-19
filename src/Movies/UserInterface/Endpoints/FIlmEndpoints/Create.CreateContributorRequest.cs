using System.ComponentModel.DataAnnotations;

namespace Movies.Web.Endpoints.FilmEndpoints;

public class CreateFilmRequest
{
  public const string Route = "/Film";

  [Required]
  public string? Naslov { get; set; }
  [Required]
  public DateTime? DatumPocetkaPrikazivanja { get; set; }
  [Required]
  public decimal? Ulozeno { get; set; }
  [Required]
  public string? ZanrNaziv { get; set; }


}
