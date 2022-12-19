namespace Movies.Web.Endpoints.PaketEndpoints;

public class UpdatePaketResponse
{
  public UpdatePaketResponse(PaketRecord paket)
  {
    Paket = paket;
  }
  public PaketRecord Paket { get; set; }
}
