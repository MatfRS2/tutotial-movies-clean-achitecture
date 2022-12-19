using System.Xml.Linq;
using Ardalis.GuardClauses;
using Movies.SharedKernel;
using Movies.SharedKernel.DomainObjects;

namespace Movies.Domain.PripremaContext.PaketAggregate;

public class FilmPaket : EntityBase
{
  public int FilmId { get; private set; }

  public int PaketId { get; private set; }

  protected internal FilmPaket(int filmId, int paketId)
  {
    FilmId = filmId;
    PaketId = paketId;
  }

}

