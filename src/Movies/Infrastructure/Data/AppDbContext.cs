using System.Reflection;
using Movies.Domain.PretplataContext.KorisnikAggregate;
using Movies.Domain.PretplataContext.PaketAggregate;
using Movies.Domain.PripremaContext.FilmAggregate;
using Movies.Domain.PripremaContext.PaketAggregate;
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
  public DbSet<Movies.Domain.PretplataContext.PaketAggregate.Paket> PaketiIzPretplate => 
    Set<Domain.PretplataContext.PaketAggregate.Paket>();

  public DbSet<Zanr> Zanrovi => Set<Zanr>();
  public DbSet<Film> Filmovi => Set<Film>();
  public DbSet<FilmPaket> FilmoviPaketi => Set<FilmPaket>();
  public DbSet<Movies.Domain.PripremaContext.PaketAggregate.Paket> PaketiIzPripreme =>
    Set<Movies.Domain.PripremaContext.PaketAggregate.Paket>();


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
