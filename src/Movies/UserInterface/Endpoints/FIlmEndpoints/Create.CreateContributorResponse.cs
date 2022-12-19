namespace Movies.Web.Endpoints.FilmEndpoints;

public class CreateFilmResponse
{
  public CreateFilmResponse(int id, string naslov, DateTime datumPocektPrikazivanja,
    decimal ulozeno)
  {
    Id = id;
    Naslov = naslov;
    DatumPocetkaPrikazivanja = datumPocektPrikazivanja;
    Ulozeno = ulozeno;
  }
  public int Id { get; set; }
  public string Naslov { get; set; }
  public DateTime DatumPocetkaPrikazivanja { get; set; }
  public decimal Ulozeno { get; set; }
}
