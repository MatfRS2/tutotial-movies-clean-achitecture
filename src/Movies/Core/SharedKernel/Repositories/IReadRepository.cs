using Ardalis.Specification;
using Movies.SharedKernel.DomainObjects;

namespace Movies.SharedKernel.Repositories;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
