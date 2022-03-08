using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CosmosDB
{
    public class CosmosdbDbContextRepository<T> : DbContextRepository<T> where T : class
    {
        public CosmosdbDbContextRepository(CosmosdbDbContext dbContext)
            : base(dbContext)
        {
        }

        public override async Task ExecuteSqlRawAsync(string sql)
        {
            await DbContext.Database.ExecuteSqlRawAsync(sql);
        }
    }
}
