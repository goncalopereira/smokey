using System.Collections.Generic;
using web.Resource;

namespace web.Configuration
{
    public interface IResourceConfig
    {
        IDictionary<string, IResource> Get();
    }
}