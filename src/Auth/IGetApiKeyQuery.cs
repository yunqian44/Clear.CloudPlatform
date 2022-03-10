using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clear.CloudPlatform.Auth;

public interface IGetApiKeyQuery
{
    Task<ApiKey> Execute(string providedApiKey);
}
