using Movies.Domain.PretplataContext.KorisnikAgregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Movies.Infrastructure.Data.Config.Priprema;

public class KorisnikConfiguration : IEntityTypeConfiguration<Korisnik>
{
  public void Configure(EntityTypeBuilder<Korisnik> builder)
  {
    builder.HasKey(x => x.Id);
    builder.Property(x => x.Id)
            .HasColumnName("Id")
            .IsRequired();
    builder.Property(x => x.Email)
               .HasMaxLength(250)
               .IsRequired();
    builder.Property(x => x.Ime)
          .HasMaxLength(150)
          .IsRequired();
    builder.Property(x => x.Prezime)
          .HasMaxLength(150)
          .IsRequired();
    builder.Property(p => p.Potroseno)
           .HasColumnType("money");
  }
}
