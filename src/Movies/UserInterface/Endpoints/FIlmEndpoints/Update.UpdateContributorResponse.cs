namespace Movies.Web.Endpoints.FilmEndpoints;

public class UpdateFilmResponse
{
  public UpdateFilmResponse(FilmRecord film)
  {
    Film = film;
  }
  public FilmRecord Film { get; set; }
}
