using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Clear.CloudPlatform.Data.SqlServer;

[ExcludeFromCodeCoverage]
public class SqlServerDbContext : ToolsBlockDbContext
{
    public SqlServerDbContext()
    {
    }

    public SqlServerDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
