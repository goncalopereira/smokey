using System.Collections.Generic;
using web.Call;

namespace web.Resource
{
    public class ResourceRepository : IResourceRepository
    {
        public IResource Get(string id)
        {
            return new Resource(new Setup(new List<ICall>()));
        }
    }
}