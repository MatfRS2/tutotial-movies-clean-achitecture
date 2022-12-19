namespace Movies.Web.Endpoints.PaketEndpoints;

public class DeletePaketRequest
{
  public const string Route = "/Paket/{PaketId:int}";
  public static string BuildRoute(int paketId) => Route.Replace("{PaketId:int}", paketId.ToString());

  public int PaketId { get; set; }
}
