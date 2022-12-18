using System.Xml.Linq;
using Ardalis.GuardClauses;
using Movies.Domain.PretplataContext.KorisnikAggregate;
using Movies.Domain.PripremaContext.FilmAgregate;
using Movies.SharedKernel;
using Movies.SharedKernel.DomainObjects;

namespace Movies.Domain.PretplataContext.PretplataAggregate;
public class Pretplata : EntityBase, IAggregateRoot
{
  public int PretplataId { get; set; }

  public PretplataStatus Status { get; set; }

  public decimal Iznos { get; set; }

  public DateTime DatumIsteka { get; set; }

  public int KorisnikId { get; set; }
  public Korisnik Korisnik { get; set; }

  public int PaketId { get; set; }
  public Paket Paket { get; set; }

  // TODO
  public Pretplata(int pretplataId, PretplataStatus status, decimal iznos, DateTime datumIsteka, int korisnikId, Korisnik korisnik, int paketId, Paket paket)
  {
    PretplataId = pretplataId;
    Status = status ?? throw new ArgumentNullException(nameof(status));
    Iznos = iznos;
    DatumIsteka = datumIsteka;
    KorisnikId = korisnikId;
    Korisnik = korisnik ?? throw new ArgumentNullException(nameof(korisnik));
    PaketId = paketId;
    Paket = paket ?? throw new ArgumentNullException(nameof(paket));
  }
}
