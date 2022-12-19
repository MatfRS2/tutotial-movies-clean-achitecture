using Ardalis.GuardClauses;
using Movies.Domain.PretplataContext.KorisnikAggregate;
using Movies.Domain.PripremaContext.PaketAggregate;
using Movies.SharedKernel.DomainObjects;

namespace Movies.Domain.PretplataContext.PaketAggregate;
public class PretplataKorisnikPaket : EntityBase
{
  public PretplataStatus PretplataStatus { get; private set; }

  public decimal Iznos { get; private set; }

  public DateTime DatumIsteka { get; private set; }

  public Korisnik Korisnik { get; private set; }

  public Paket Paket { get; private set; }

  
  protected internal PretplataKorisnikPaket(PretplataStatus status, decimal iznos, DateTime datumIsteka, Korisnik korisnik,
    Paket paket)
  {
    PretplataStatus = Guard.Against.Null(status, nameof(status));
    Iznos = iznos;
    DatumIsteka = datumIsteka;
    Korisnik = Guard.Against.Null(korisnik, nameof(korisnik));
    Paket = Guard.Against.Null(paket, nameof(paket));
  }
}
