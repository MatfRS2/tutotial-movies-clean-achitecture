
namespace Movies.Web.Endpoints.PaketEndpoints;

public class GetPaketByIdResponse
{
  public GetPaketByIdResponse(int id, string name, List<FilmRecord> items)
  {
    Id = id;
    Name = name;
    Items = items;
  }

  public int Id { get; set; }
  public string Name { get; set; }
  public List<FilmRecord> Items { get; set; } = new();
}
