using System.Xml.Linq;
using Ardalis.GuardClauses;
using Movies.Domain.PripremaContext.DomainEvents;
using Movies.Domain.PripremaContext.FilmAgregate;
using Movies.Domain.PripremaContext.PaketAgregate.Specifications;
using Movies.SharedKernel;
using Movies.SharedKernel.DomainObjects;

namespace Movies.Domain.PretplataContext.PaketAgregate;

public class Paket : EntityBase, IAggregateRoot
{
  public string Naziv { get; set; }

  public string Opis { get; set; }

  public DateTime DatumFormiranja { get; set; }

  private List<Pretplata> _pretplate = new List<Pretplata>();
  public IEnumerable<Pretplata> Pretplate => _pretplate.AsReadOnly();

  public Paket(string naziv, string opis, DateTime datumFormiranja)
  {
    Naziv = Guard.Against.NullOrEmpty(naziv, nameof(naziv));
    Opis = Guard.Against.NullOrEmpty(opis, nameof(opis));
    DatumFormiranja = Guard.Against.Null(datumFormiranja, nameof(datumFormiranja));
  }

  public void DodajPretplatu(Pretplata novaPretplata)
  {
    Guard.Against.Null(novaPretplata, nameof(novaPretplata));
    if (_pretplate.Contains(novaPretplata))
      return;
    _pretplate.Add(novaPretplata);
    var filmDodatUPaketEvent = new FilmDodatUPaketEvent(this.Id, novaPretplata.Id);
    base.RegisterDomainEvent(filmDodatUPaketEvent);
  }

  public void UkloniPretplatu(int pretplataIdZaUklanjanje)
  {
    if (!_pretplate.Select(x => x.Id).Contains(pretplataIdZaUklanjanje))
      return;
    _pretplate.RemoveAll(x => x.Id == pretplataIdZaUklanjanje);
    var filmUklonjenIzPaketaEvent = new FilmUklonjenIzPaketaEvent(this.Id, pretplataIdZaUklanjanje);
    base.RegisterDomainEvent(filmUklonjenIzPaketaEvent);
  }

}

