using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clear.CloudPlatform.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clear.CloudPlatform.Data;

public class ToolsBlockDbContext : DbContext
{
    public ToolsBlockDbContext()
    {
    }

    public ToolsBlockDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public virtual DbSet<MenuEntity> Menu { get; set; }
    public virtual DbSet<SubMenuEntity> SubMenu { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MenuConfiguration());
        // base.OnModelCreating(modelBuilder);
        //modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        //modelBuilder.ApplyConfiguration(new TagConfiguration());
        //modelBuilder.ApplyConfiguration(new FriendLinkConfiguration());
        //modelBuilder.ApplyConfiguration(new SubMenuConfiguration());
        //modelBuilder.ApplyConfiguration(new BlogConfigurationConfiguration());

        //modelBuilder
        //    .Entity<PostEntity>()
        //    .HasMany(p => p.Tags)
        //    .WithMany(p => p.Posts)
        //    .UsingEntity<PostTagEntity>(
        //        j => j
        //            .HasOne(pt => pt.Tag)
        //            .WithMany()
        //            .HasForeignKey(pt => pt.TagId),
        //        j => j
        //            .HasOne(pt => pt.Post)
        //            .WithMany()
        //            .HasForeignKey(pt => pt.PostId));
    }
}
