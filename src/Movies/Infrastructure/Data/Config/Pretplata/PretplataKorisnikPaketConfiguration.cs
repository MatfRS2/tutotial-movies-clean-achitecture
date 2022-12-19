using Movies.Domain.PretplataContext.PaketAgregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Movies.Domain.PretplataContext.KorisnikAgregate;

namespace Movies.Infrastructure.Data.Config.Priprema;

public class PretplataKorisnikPaketConfiguration : IEntityTypeConfiguration<PretplataKorisnikPaket>
{
  public void Configure(EntityTypeBuilder<PretplataKorisnikPaket> builder)
  {
    builder.HasKey(x => x.Id);
    builder.Property(x => x.Id)
            .HasColumnName("Id")
            .IsRequired();
    builder.Property(p => p.DatumIsteka)
           .HasColumnType("date");
    builder.Property(p => p.PretplataStatus)
   .HasConversion(
           p => p.Value,
           p => PretplataStatus.FromValue(p));
    builder.Property(p => p.Iznos)
           .HasColumnType("money");

  }
}
