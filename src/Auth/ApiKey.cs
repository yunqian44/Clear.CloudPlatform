using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clear.CloudPlatform.Auth;

public class ApiKey
{
    public string Owner { get; set; }
    public string Key { get; set; }
    public DateTime Created { get; }
    public IReadOnlyCollection<string> Roles { get; set; }

    public ApiKey()
    {
        Roles = new[] { "Administrator" };
        Created = DateTime.UtcNow;
    }
}
