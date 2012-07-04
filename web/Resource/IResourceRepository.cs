using System.Collections.Generic;

namespace API.Resource
{
    public interface IResourceRepository
    {
        IResource Get(string id);
        IList<IResource> GetAll();
    }
}