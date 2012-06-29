using System.Collections.Generic;

namespace web.Resource
{
    public interface IResourceRepository
    {
        IResource Get(string id);
        IList<IResource> GetAll();
    }
}