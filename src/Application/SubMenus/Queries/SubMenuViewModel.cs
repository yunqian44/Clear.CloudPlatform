using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clear.CloudPlatform.Application.Common.Mappings;
using Clear.CloudPlatform.Application.MenuLists.Queries.GetMenuItems;
using Clear.CloudPlatform.Domain.Entities.MenuEntities;

namespace Clear.CloudPlatform.Application.SubMenus.Queries;

public class SubMenuViewModel : IMapFrom<SubMenuItem>
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Url { get; set; }

    public bool IsOpenInNewTab { get; set; }

    public Guid MenuId { get; set; }

    public virtual MenuItemViewModel Menu { get; set; }
}
