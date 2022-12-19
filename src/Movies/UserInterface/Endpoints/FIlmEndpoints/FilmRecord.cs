namespace Movies.Web.Endpoints.FilmEndpoints;

public record FilmRecord(int Id, string Naslov, DateTime datumPocetkaPrikazivanja,
  decimal ulozeno);
