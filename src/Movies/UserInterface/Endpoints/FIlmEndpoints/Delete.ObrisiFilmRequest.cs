namespace Movies.Web.Endpoints.FilmEndpoints;

public class ObrisiFilmRequest
{
  public const string Route = "/Film/{FilmId:int}";
  public static string BuildRoute(int filmId) => Route.Replace("{FilmId:int}", filmId.ToString());

  public int FilmId { get; set; }
}
