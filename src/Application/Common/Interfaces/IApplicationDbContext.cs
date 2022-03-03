using Clear.CloudPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clear.CloudPlatform.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
