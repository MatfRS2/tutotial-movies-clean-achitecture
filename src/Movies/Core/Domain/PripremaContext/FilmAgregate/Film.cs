using System.Xml.Linq;
using Ardalis.GuardClauses;
using Movies.SharedKernel;
using Movies.SharedKernel.DomainObjects;

namespace Movies.Domain.PripremaContext.FilmAgregate;

public class Film : EntityBase, IAggregateRoot
{
  public string Naslov { get; private set; }

  public DateTime DatumPocetkaPrikazivanja { get; private set; }

  public decimal Ulozeno { get; private set; }

  public Zanr Zanr { get; private set; }

  public Film(string naslov, DateTime datumPocetkaPrikazivanja, decimal ulozeno, string zanrNaziv)
  {
    Naslov = Guard.Against.NullOrEmpty(naslov, nameof(naslov));
    DatumPocetkaPrikazivanja = Guard.Against.Null(datumPocetkaPrikazivanja, nameof(datumPocetkaPrikazivanja));
    Ulozeno = ulozeno;
    Zanr = new Zanr(zanrNaziv);
  }



}
