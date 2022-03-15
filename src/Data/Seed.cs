using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clear.CloudPlatform.Data.Entities;
using Microsoft.Extensions.Logging;

namespace Clear.CloudPlatform.Data;

public class Seed
{
    public static async Task SeedAsync(ToolsBlockDbContext dbContext, ILogger logger, int retry = 0)
    {
        var retryForAvailability = retry;

        try
        {

            await dbContext.Menu.AddRangeAsync(GetMenus());

          

            //await dbContext.Post.AddAsync(post);

            await dbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            if (retryForAvailability >= 10) throw;

            retryForAvailability++;

            logger.LogError(e.Message);
            await SeedAsync(dbContext, logger, retryForAvailability);
            throw;
        }
    }


    private static IEnumerable<MenuEntity> GetMenus()
    {
        var menus = new List<MenuEntity>();
        menus.Add(new()
        {
            Id = Guid.NewGuid(),
            DisplayOrder = 0,
            IsOpenInNewTab = false,
            Icon = "icon-star-full",
            Title = "Home",
            Url = "/Home/Index"
        });
        menus.Add(new()
        {
            Id = Guid.NewGuid(),
            DisplayOrder = 1,
            IsOpenInNewTab = false,
            Icon = "icon-star-full",
            Title = "Account",
            Url = "/Account/Index"
        });
        menus.Add(new()
        {
            Id = Guid.NewGuid(),
            DisplayOrder = 2,
            IsOpenInNewTab = false,
            Icon = "icon-star-full",
            Title = "Settings",
            Url = "/Settings/Index"
        });
        return menus;
    }
}
