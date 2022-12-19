using Ardalis.Specification.EntityFrameworkCore;
using Movies.SharedKernel.DomainObjects;
using Movies.SharedKernel.Repositories;

namespace Movies.Infrastructure.Data;

// inherit from Ardalis.Specification type
public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
  public EfRepository(AppDbContext dbContext) : base(dbContext)
  {
  }
}
