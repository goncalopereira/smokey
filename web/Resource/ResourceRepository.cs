using System.Collections.Generic;
using System.Linq;

namespace web.Resource
{
    public class ResourceRepository : IResourceRepository
    {
        private IDictionary<string, IResource> _resources;

        public ResourceRepository(IDictionary<string,IResource> resources)
        {
            _resources = resources;
        }

        public ResourceRepository() {}


        public IResource Get(string id)
        {
            return GetResources()[id];
        }

        private IDictionary<string, IResource> GetResources()
        {
            return _resources ?? (_resources = ResourceConfig.Get());
        }

        public IList<IResource> GetAll()
        {
            return GetResources().Values.ToList();
        }
    }
}