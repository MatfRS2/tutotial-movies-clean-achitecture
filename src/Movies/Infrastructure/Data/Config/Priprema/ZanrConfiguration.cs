using Movies.Domain.PripremaContext.FilmAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Movies.Infrastructure.Data.Config.Priprema;

public class ZanrConfiguration : IEntityTypeConfiguration<Zanr>
{
  public void Configure(EntityTypeBuilder<Zanr> builder)
  {
    builder.HasKey(z => z.Id);
    builder.Property(z => z.Id)
            .HasColumnName("Id")
            .ValueGeneratedNever()
            .IsRequired();
    builder.Property(z => z.Naziv)
          .HasMaxLength(250)
          .IsRequired();
  }
}
