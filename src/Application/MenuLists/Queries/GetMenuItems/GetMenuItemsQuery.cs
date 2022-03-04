using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Clear.CloudPlatform.Application.Common.Interfaces;
using Clear.CloudPlatform.Application.SubMenus.Queries;
using Clear.CloudPlatform.Domain.Entities.MenuEntities;
using MediatR;

namespace Clear.CloudPlatform.Application.MenuLists.Queries.GetMenuItems;

public record GetMenuItemsQuery : IRequest<IReadOnlyList<MenuItemViewModel>>;


public class GetMenuItemsQueryHandler : IRequestHandler<GetMenuItemsQuery, IReadOnlyList<MenuItemViewModel>>
{
    //private readonly IApplicationDbContext _context;
    private readonly IRepository<MenuItemViewModel> _menuRepo;
    private readonly IMapper _mapper;

    public GetMenuItemsQueryHandler(IRepository<MenuItemViewModel> menuRepo, IMapper mapper)
    {
        _menuRepo = menuRepo;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<MenuItemViewModel>> Handle(GetMenuItemsQuery request, CancellationToken cancellationToken)
    {
        var list = await _menuRepo.SelectAsync(p => new MenuItemViewModel
        {
            Id = p.Id,
            DisplayOrder = p.DisplayOrder,
            Icon = p.Icon,
            Title = p.Title,
            Url = p.Url,
            IsOpenInNewTab = p.IsOpenInNewTab,
            SubMenus = p.SubMenus.Select(sm => new SubMenuViewModel
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
