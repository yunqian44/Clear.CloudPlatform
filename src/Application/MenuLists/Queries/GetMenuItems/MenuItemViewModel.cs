using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clear.CloudPlatform.Application.Common.Mappings;
using Clear.CloudPlatform.Application.SubMenus.Queries;
using Clear.CloudPlatform.Domain.Entities.MenuEntities;

namespace Clear.CloudPlatform.Application.MenuLists.Queries.GetMenuItems;

public class MenuItemViewModel: IMapFrom<MenuItem>
{
    public MenuItemViewModel()
    {
        SubMenus = new HashSet<SubMenuViewModel>();
    }

    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Url { get; set; }

    public string Icon { get; set; }

    public int DisplayOrder { get; set; }

    public bool IsOpenInNewTab { get; set; }

    public virtual ICollection<SubMenuViewModel> SubMenus { get; set; }
}
