using System.Reflection;
using Movies.Domain.PretplataContext.KorisnikAgregate;
using Movies.Domain.PretplataContext.PaketAgregate;
using Movies.Domain.PripremaContext.FilmAgregate;
using Movies.Domain.PripremaContext.PaketAgregate;
using Movies.SharedKernel.DomainEvents;
using Movies.SharedKernel.DomainObjects;
using Movies.SharedKernel.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Movies.Infrastructure.Data;

public class AppDbContext : DbContext
{
  private readonly IDomainEventDispatcher? _dispatcher;

  public AppDbContext(DbContextOptions<AppDbContext> options,
    IDomainEventDispatcher? dispatcher)
      : base(options)
  {
    _dispatcher = dispatcher;
  }

  public DbSet<Korisnik> Korisnici => Set<Korisnik>();
  public DbSet<PretplataStatus> PretplataStatusi => Set<PretplataStatus>();
  public DbSet<PretplataKorisnikPaket> Pretplate => Set<PretplataKorisnikPaket>();
  public DbSet<Movies.Domain.PretplataContext.PaketAgregate.Paket> PaketiIzPretplate => 
    Set<Domain.PretplataContext.PaketAgregate.Paket>();

  public DbSet<Zanr> Zanrovi => Set<Zanr>();
  public DbSet<Film> Filmovi => Set<Film>();
  public DbSet<FilmPaket> FilmoviPaketi => Set<FilmPaket>();
  public DbSet<Movies.Domain.PripremaContext.PaketAgregate.Paket> PaketiIzPripreme =>
    Set<Movies.Domain.PripremaContext.PaketAgregate.Paket>();


  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    // ignore events if no dispatcher provided
    if (_dispatcher == null) return result;

    // dispatch events only if save was successful
    var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
        .Select(e => e.Entity)
        .Where(e => e.DomainEvents.Any())
        .ToArray();

    await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

    return result;
  }

  public override int SaveChanges()
  {
    return SaveChangesAsync().GetAwaiter().GetResult();
  }
}
