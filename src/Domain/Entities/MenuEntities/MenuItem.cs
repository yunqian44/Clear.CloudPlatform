using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clear.CloudPlatform.Data.Entities;

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
    public List<SubMenuItem>? SubMenus { get; set; } = new List<SubMenuItem>();


    public MenuItem()
    {
        SubMenus = new();
        Icon = "icon-file-text2";
    }

    public MenuItem(MenuEntity entity)
    {
        if (entity is null) return;

        Id = entity.Id;
        Title = entity.Title.Trim();
        DisplayOrder = entity.DisplayOrder;
        Icon = entity.Icon?.Trim();
        Url = entity.Url?.Trim();
        IsOpenInNewTab = entity.IsOpenInNewTab;
        SubMenus = entity.SubMenus.Select(sm => new SubMenuItem
        {
            Id = sm.Id,
            Title = sm.Title,
            Url = sm.Url,
            IsOpenInNewTab = sm.IsOpenInNewTab
        }).ToList();
    }

}
