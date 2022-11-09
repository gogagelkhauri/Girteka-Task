

using Ardalis.Specification.EntityFrameworkCore;
using Core.Interfaces;

namespace Infrastructure.Data;
public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T> where T : class, IAggregateRoot
{
    public EfRepository(EntityFrameworkDbContext dbContext) : base(dbContext)
    {
    }
}

