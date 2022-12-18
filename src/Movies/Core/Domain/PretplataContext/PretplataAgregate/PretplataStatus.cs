using System.Xml.Linq;
using Ardalis.GuardClauses;
using Ardalis.SmartEnum;
using Movies.SharedKernel;
using Movies.SharedKernel.DomainObjects;

namespace Movies.Domain.PretplataContext.PretplataAggregate;

public class PretplataStatus : SmartEnum<PretplataStatus>
{
  public static readonly PretplataStatus Aktivirana = new(nameof(Aktivirana), 0);
  public static readonly PretplataStatus Otkazana = new(nameof(Otkazana), 1);

  protected PretplataStatus(string name, int value) : base(name, value) { }
}

