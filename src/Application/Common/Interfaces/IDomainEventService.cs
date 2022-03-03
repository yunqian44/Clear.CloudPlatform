using Clear.CloudPlatform.Domain.Common;

namespace Clear.CloudPlatform.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
