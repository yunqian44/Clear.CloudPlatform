using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clear.CloudPlatform.Domain.Entities.MenuEntities;

public class MenuItem : AuditableEntity
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Title
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Url
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    /// Icon
    /// </summary>
    public string? Icon { get; set; }

    /// <summary>
    /// DisplayOrder
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// IsOpenInNewTab
    /// </summary>
    public bool IsOpenInNewTab { get; set; }

    /// <summary>
    /// SubMenus
    /// </summary>
    public IList<SubMenuItem>? SubMenus { get; private set; } = new List<SubMenuItem>();

}
