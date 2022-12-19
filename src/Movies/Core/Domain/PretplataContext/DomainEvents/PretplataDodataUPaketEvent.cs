using Movies.SharedKernel.DomainEvents;

namespace Movies.Domain.PretplataContext.DomainEvents;

public class PretplataDodataUPaketEvent : DomainEventBase
{
  public int PaketId { get; set; }
  public int PretplataId { get; set; }

  public PretplataDodataUPaketEvent(int pretplataId, int paketId )
  {
    PretplataId = pretplataId;
    PaketId = paketId;
  }

}
