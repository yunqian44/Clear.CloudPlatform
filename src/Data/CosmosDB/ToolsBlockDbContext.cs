using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CosmosDB
{
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
            base.OnModelCreating(modelBuilder);
        }
    }
}
