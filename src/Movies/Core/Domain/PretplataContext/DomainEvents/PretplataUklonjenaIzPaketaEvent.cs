using Movies.SharedKernel.DomainEvents;

namespace Movies.Domain.PretplataContext.DomainEvents;

public class PretplataUklonjenaIzPaketaEvent : DomainEventBase
{
  public int PaketId { get; set; }
  public int PretplataId { get; set; }

  public PretplataUklonjenaIzPaketaEvent(int pretplataId, int paketId )
  {
    PretplataId = pretplataId;
    PaketId = paketId;
  }

}
