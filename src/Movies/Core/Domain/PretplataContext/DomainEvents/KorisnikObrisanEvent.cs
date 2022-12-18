using Movies.SharedKernel.DomainEvents;

namespace Movies.Domain.PretplataContext.DomainEvents;

public class KorisnikObrisanEvent : DomainEventBase
{
  public int KorisnikId { get; set; }

  public KorisnikObrisanEvent(int korisnikId)
  {
    KorisnikId = korisnikId;
  }

}
