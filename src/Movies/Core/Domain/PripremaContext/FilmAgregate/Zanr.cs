using System.Xml.Linq;
using Ardalis.GuardClauses;
using Movies.SharedKernel;
using Movies.SharedKernel.DomainObjects;

namespace Movies.Domain.PripremaContext.FilmAgregate;

public class Zanr : EntityBase
{
  public string Naziv { get; private set; } = "";

  protected internal Zanr(string naziv)
  {
    Naziv = Guard.Against.NullOrEmpty(naziv, nameof(naziv));
  }

}

