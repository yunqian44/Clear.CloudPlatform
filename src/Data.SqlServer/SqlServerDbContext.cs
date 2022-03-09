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
        //modelBuilder.ApplyConfiguration(new CommentConfiguration());
        //modelBuilder.ApplyConfiguration(new CommentReplyConfiguration());
        //modelBuilder.ApplyConfiguration(new PostConfiguration());
        //modelBuilder.ApplyConfiguration(new PostCategoryConfiguration());
        //modelBuilder.ApplyConfiguration(new PostExtensionConfiguration());
        //modelBuilder.ApplyConfiguration(new LocalAccountConfiguration());
        //modelBuilder.ApplyConfiguration(new PingbackConfiguration());
        //modelBuilder.ApplyConfiguration(new BlogThemeConfiguration());
        //modelBuilder.ApplyConfiguration(new BlogAssetConfiguration());
        //modelBuilder.ApplyConfiguration(new BlogConfigurationConfiguration());
        //modelBuilder.ApplyConfiguration(new PageConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
