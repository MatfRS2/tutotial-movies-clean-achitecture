namespace Movies.Web.Endpoints.PaketEndpoints;

public record FilmRecord(int Id, string Naslov, DateTime datumPocetkaPrikazivanja, 
  decimal ulozeno);
