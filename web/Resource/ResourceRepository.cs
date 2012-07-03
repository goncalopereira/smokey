using System.Collections.Generic;
using System.Linq;
using web.Call;
using web.Configuration;

namespace web.Resource
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly IDictionary<string, IResource> _resources;

        public ResourceRepository(IResourceConfig resourceConfig)
        {
            _resources = resourceConfig.Get();
        }

        public IResource Get(string id)
        {
            return _resources.Keys.Contains(id) ? _resources[id] : new Resource(new List<ICall>(), id);
        }

        public IList<IResource> GetAll()
        {
            return _resources.Values.ToList();
        }
    }
}