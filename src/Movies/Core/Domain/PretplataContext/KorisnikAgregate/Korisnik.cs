using System.Xml.Linq;
using Ardalis.GuardClauses;
using Movies.SharedKernel;
using Movies.SharedKernel.DomainObjects;

namespace Movies.Domain.PretplataContext.KorisnikAgregate;

public class Korisnik : EntityBase, IAggregateRoot
{
  public string Email { get; private set; }

  public string Ime { get; private set; }

  public string Prezime { get; private set; }

  public decimal Potroseno { get; private set; }

  public Korisnik(string email, string ime, string prezime, decimal potroseno)
  {
    Email = Guard.Against.NullOrEmpty(email, nameof(email));
    Ime = Guard.Against.NullOrEmpty(ime, nameof(ime));
    Prezime = Guard.Against.NullOrEmpty(prezime, nameof(prezime));
    Potroseno = potroseno;
  }
}
