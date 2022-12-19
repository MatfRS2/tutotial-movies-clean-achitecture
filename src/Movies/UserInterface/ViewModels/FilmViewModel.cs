using Movies.Domain.PripremaContext.FilmAggregate;

namespace Movies.Web.ViewModels;

public class FilmViewModel
{
  public int Id { get; set; }

  public string? Naslov { get; set; }

  public DateTime DatumPocetkaPrikazivanja { get; set; }

  public decimal Ulozeno { get; set; }

  public static FilmViewModel FromFilm(Film item)
  {
    return new FilmViewModel()
    {
      Id = item.Id,
      Naslov = item.Naslov,
      DatumPocetkaPrikazivanja = item.DatumPocetkaPrikazivanja,
      Ulozeno = item.Ulozeno
    };
  }
}
