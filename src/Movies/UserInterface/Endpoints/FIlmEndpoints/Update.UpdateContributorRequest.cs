using System.ComponentModel.DataAnnotations;

namespace Movies.Web.Endpoints.FilmEndpoints;

public class UpdateFilmRequest
{
  public const string Route = "/Film";
  [Required]
  public int Id { get; set; }
  [Required]
  public string? Name { get; set; }
}
