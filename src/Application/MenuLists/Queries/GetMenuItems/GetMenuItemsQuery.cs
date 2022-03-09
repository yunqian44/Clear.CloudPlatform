using AutoMapper;
using Clear.CloudPlatform.Data.Entities;
using Clear.CloudPlatform.Data.Infrastructure;
using Clear.CloudPlatform.Domain.Entities.MenuEntities;
using MediatR;

namespace Clear.CloudPlatform.Application.MenuLists.Queries.GetMenuItems;

public record GetMenuItemsQuery : IRequest<IReadOnlyList<MenuItem>>;


public class GetMenuItemsQueryHandler : IRequestHandler<GetMenuItemsQuery, IReadOnlyList<MenuItem>>
{
    //private readonly IApplicationDbContext _context;
    private readonly IRepository<MenuEntity> _menuRepo;
    private readonly IMapper _mapper;

    public GetMenuItemsQueryHandler(IRepository<MenuEntity> menuRepo)
    {
        _menuRepo = menuRepo;
    }

    public async Task<IReadOnlyList<MenuItem>> Handle(GetMenuItemsQuery request, CancellationToken cancellationToken)
    {
        var list = await _menuRepo.SelectAsync(p => new MenuItem
        {
            Id = p.Id,
            DisplayOrder = p.DisplayOrder,
            Icon = p.Icon,
            Title = p.Title,
            Url = p.Url,
            IsOpenInNewTab = p.IsOpenInNewTab,
            SubMenus = p.SubMenus.Select(sm => new SubMenuItem
            {
                Id = sm.Id,
                Title = sm.Title,
                Url = sm.Url,
                IsOpenInNewTab = sm.IsOpenInNewTab
            }).ToList()
        });

        return list;
    }
}
