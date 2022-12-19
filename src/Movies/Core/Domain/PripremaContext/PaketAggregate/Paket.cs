using System.Xml.Linq;
using Ardalis.GuardClauses;
using Movies.Domain.PripremaContext.DomainEvents;
using Movies.Domain.PripremaContext.FilmAggregate;
using Movies.Domain.PripremaContext.PaketAggregate.Specifications;
using Movies.SharedKernel;
using Movies.SharedKernel.DomainObjects;

namespace Movies.Domain.PripremaContext.PaketAggregate;

public class Paket : EntityBase, IAggregateRoot
{
  public string Naziv { get; set; }

  public string Opis { get; set; }

  public DateTime DatumFormiranja { get; set; }

  private List<FilmPaket> _filmovi = new List<FilmPaket>();
  public IEnumerable<FilmPaket> Filmovi => _filmovi.AsReadOnly();

  public Paket(string naziv, string opis, DateTime datumFormiranja)
  {
    Naziv = Guard.Against.NullOrEmpty(naziv, nameof(naziv));
    Opis = Guard.Against.NullOrEmpty(opis, nameof(opis));
    DatumFormiranja = Guard.Against.Null(datumFormiranja, nameof(datumFormiranja));
  }

  public void DodajFilm(Film noviFilm)
  {
    Guard.Against.Null(noviFilm, nameof(noviFilm));
    var newItem = new FilmPaket(noviFilm.Id, Id);
    if (_filmovi.Contains(newItem))
      return;
    _filmovi.Add(newItem);
    // nedostaje provera da li je to id od postojeceg filma
    var filmDodatUPaketEvent = new FilmDodatUPaketEvent(this.Id, noviFilm.Id);
    base.RegisterDomainEvent(filmDodatUPaketEvent);
  }

  public void UkloniFilmPoId(int filmIdZaUklanjanje)
  {
    var toDeleteItem = new FilmPaket(filmIdZaUklanjanje, Id);
    if (!_filmovi.Contains(toDeleteItem))
      return;
    _filmovi.Remove(toDeleteItem);
    var filmUklonjenIzPaketaEvent = new FilmUklonjenIzPaketaEvent(this.Id, filmIdZaUklanjanje);
    base.RegisterDomainEvent(filmUklonjenIzPaketaEvent);
  }
  public void IzmeniNaziv(string noviNaziv)
  {
    Naziv = Guard.Against.NullOrEmpty(noviNaziv, nameof(noviNaziv));
  }

  public void IzmeniOpis(string noviOpis)
  {
    Opis = Guard.Against.NullOrEmpty(noviOpis, nameof(noviOpis));
  }
}

