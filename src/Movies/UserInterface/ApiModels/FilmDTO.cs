using System.ComponentModel.DataAnnotations;
using Movies.Domain.PripremaContext.FilmAggregate;

namespace Movies.Web.ApiModels;

// ApiModel DTOs are used by ApiController classes and are typically kept in a side-by-side folder
public class FilmDTO
{
  public int Id { get; set; }

  [Required]
  public string? Naslov { get; set; }
  public DateTime? DatumPocekaPrikazivanja { get; set; }
  public decimal Ulozeno { get; private set; }

  public static FilmDTO FromFilm(Film item)
  {
    return new FilmDTO()
    {
      Id = item.Id,
      Naslov = item.Naslov,
      DatumPocekaPrikazivanja = item.DatumPocetkaPrikazivanja,
      Ulozeno = item.Ulozeno
    };
  }
}
