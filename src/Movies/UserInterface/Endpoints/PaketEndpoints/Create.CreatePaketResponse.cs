namespace Movies.Web.Endpoints.PaketEndpoints;

public class CreatePaketResponse
{
  public CreatePaketResponse(int id, string naziv, string opis, DateTime datumFormiranja)
  {
    Id = id;
    Naziv = naziv;
    Opis = opis;
    DatumFormiranja = datumFormiranja;
  }
  public int Id { get; set; }
  public string? Naziv { get; set; }
  public string? Opis { get; set; }
  public DateTime? DatumFormiranja { get; set; }
}
