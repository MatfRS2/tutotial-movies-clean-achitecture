using Movies.Domain.PripremaContext.PaketAgregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Movies.Infrastructure.Data.Config.Priprema;

public class PaketIzPripremeConfiguration : IEntityTypeConfiguration<Paket>
{
  public void Configure(EntityTypeBuilder<Paket> builder)
  {
    builder.HasKey(p => p.Id);
    builder.Property(z => z.Id)
            .HasColumnName("Id")
            .IsRequired();
    builder.Property(p => p.Naziv)
          .HasMaxLength(250)
          .IsRequired();
    builder.Property(p => p.Opis)
          .HasMaxLength(1000)
          .IsRequired();
    builder.Property(p => p.DatumFormiranja)
           .HasColumnType("date");
  }
}
