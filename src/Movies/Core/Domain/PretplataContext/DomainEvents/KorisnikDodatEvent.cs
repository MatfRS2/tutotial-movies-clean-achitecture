using Movies.SharedKernel.DomainEvents;

namespace Movies.Domain.PretplataContext.DomainEvents;

public class KorisnikDodatEvent : DomainEventBase
{
  public int KorisnikId { get; set; }

  public KorisnikDodatEvent(int korisnikId)
  {
    KorisnikId = korisnikId;
  }

}
