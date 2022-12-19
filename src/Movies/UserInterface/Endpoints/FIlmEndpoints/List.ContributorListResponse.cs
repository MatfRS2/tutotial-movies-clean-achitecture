namespace Movies.Web.Endpoints.FilmEndpoints;

public class FilmListResponse
{
  public List<FilmRecord> Films { get; set; } = new();
}
