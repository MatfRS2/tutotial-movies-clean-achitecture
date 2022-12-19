using Ardalis.Specification;
using Movies.SharedKernel.DomainObjects;

namespace Movies.SharedKernel.Repositories;

// from Ardalis.Specification
public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}
