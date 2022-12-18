using System.Xml.Linq;
using Ardalis.GuardClauses;
using Movies.Domain.PripremaContext.DomainEvents;
using Movies.SharedKernel;
using Movies.SharedKernel.DomainObjects;

namespace Movies.Domain.PripremaContext.FilmAgregate;

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
    var filmDodatUPaketEvent = new FilmDodatUPaketEvent(this, noviFilm);
    base.RegisterDomainEvent(filmDodatUPaketEvent);
  }

  public void ukloniFilm(Film uklanjaSeFilm)
  {
    Guard.Against.Null(uklanjaSeFilm, nameof(uklanjaSeFilm));
    var toDeleteItem = new FilmPaket(uklanjaSeFilm.Id, Id);
    if (!_filmovi.Contains(toDeleteItem))
      return;
    _filmovi.Remove(toDeleteItem);
    var filmUklonjenIzPaketaEvent = new FilmUklonjenIzPaketaEvent(this, uklanjaSeFilm);
    base.RegisterDomainEvent(filmUklonjenIzPaketaEvent);
  }

  public void IzmeniNaziv(string noviNaziv)
  {
    Naziv = Guard.Against.NullOrEmpty(noviNaziv, nameof(noviNaziv));
  }
}

