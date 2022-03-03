using Clear.CloudPlatform.Application.Common.Interfaces;

namespace Clear.CloudPlatform.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
