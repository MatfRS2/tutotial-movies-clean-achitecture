using Movies.Domain.PripremaContext.FilmAggregate;
using Movies.Domain.PripremaContext.PaketAggregate;
using Movies.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Movies.Web;

public static class SeedData
{
  public static readonly Paket TestPaket1 = new Paket(
    "Test Paket", "Testni paket", new DateTime(2022, 12, 15));
  public static readonly Film Film1 = new Film(
    "Kad je Hari sreo Sali", new DateTime(1987, 11, 25), 7, "komedija");
  public static readonly Film Film2 = new Film(
    "Matrks", new DateTime(2003, 1, 10), 10, "sci-fi");
  public static readonly Film Film3 = new Film(
    "Matrkis 2", new DateTime(2006, 11, 10), 11, "sci-fi");

  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
    {
      // Look for any TODO items.
      if (dbContext.Filmovi.Any())
      {
        return;   // DB has been seeded
      }

      PopulateTestData(dbContext);


    }
  }
  public static void PopulateTestData(AppDbContext dbContext)
  {
    foreach (var item in dbContext.PaketiIzPripreme)
    {
      dbContext.Remove(item);
    }
    foreach (var item in dbContext.Filmovi)
    {
      dbContext.Remove(item);
    }
    foreach (var item in dbContext.Zanrovi)
    {
      dbContext.Remove(item);
    }

    dbContext.SaveChanges();

    TestPaket1.DodajFilm(Film1);
    TestPaket1.DodajFilm(Film2);
    TestPaket1.DodajFilm(Film3);
    dbContext.PaketiIzPripreme.Add(TestPaket1);

    dbContext.SaveChanges();
  }
}
