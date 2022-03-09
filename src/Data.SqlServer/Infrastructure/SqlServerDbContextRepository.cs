using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clear.CloudPlatform.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Clear.CloudPlatform.Data.SqlServer.Infrastructure;

[ExcludeFromCodeCoverage]
public class SqlServerDbContextRepository<T> : DbContextRepository<T> where T : class
{
    public SqlServerDbContextRepository(SqlServerDbContext dbContext)
        : base(dbContext)
    {
    }

    public override async Task ExecuteSqlRawAsync(string sql)
    {
        await DbContext.Database.ExecuteSqlRawAsync(sql);
    }
}
