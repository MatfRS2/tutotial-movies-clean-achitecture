namespace Movies.Web.Endpoints.PaketEndpoints;

public class PretragaFilmovaResponse
{
  public PretragaFilmovaResponse(int paketId, List<FilmRecord> incompleteItems)
  {
    PaketId = paketId;
    IncompleteItems = incompleteItems;
  }
  public int PaketId { get; set; }
  public List<FilmRecord> IncompleteItems { get; set; }
}
