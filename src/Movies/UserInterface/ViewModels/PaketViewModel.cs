using System.Collections.Generic;

namespace Movies.Web.ViewModels;

public class PaketViewModel
{
  public int Id { get; set; }
  public string? Naziv { get; set; }
  public string? Opis { get; set; }
  public DateTime? DatumFormiranja { get; set; }

  public List<FilmViewModel> Filmovi = new();
}
