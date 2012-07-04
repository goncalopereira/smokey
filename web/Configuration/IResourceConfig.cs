using System.Collections.Generic;
using API.Resource;

namespace API.Configuration
{
    public interface IResourceConfig
    {
        IDictionary<string, IResource> Get();
    }
}