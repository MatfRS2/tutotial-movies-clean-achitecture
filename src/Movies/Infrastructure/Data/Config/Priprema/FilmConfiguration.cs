using Movies.Domain.PripremaContext.FilmAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Movies.Infrastructure.Data.Config.Priprema;

public class FIlmConfiguration : IEntityTypeConfiguration<Film>
{
  public void Configure(EntityTypeBuilder<Film> builder)
  {
    builder.HasKey(f => f.Id);
    builder.Property(f => f.Id)
            .HasColumnName("Id")
            .IsRequired();
    builder.Property(f => f.Naslov)
          .HasMaxLength(250)
          .IsRequired();
    builder.Property(f => f.DatumPocetkaPrikazivanja)
           .HasColumnType("date");
    builder.Property(f => f.Ulozeno)
           .HasColumnType("money");

    builder.HasOne(f => f.Zanr);
  }
}
