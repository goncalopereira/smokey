using System.Collections.Generic;
using web.Call;

namespace web.Resource
{
    public class ResourceRepository : IResourceRepository
    {
        public IResource Get(string id)
        {
            List<ICall> calls = new List<ICall> {new Call.Call("url1", "call1"), new Call.Call("url2", "call2")};

            return new Resource(new Setup(calls));
        }

        public IList<IResource> GetAll()
        {
            List<ICall> calls = new List<ICall> {new Call.Call("url1", "call1"), new Call.Call("url2", "call2")};
            return new List<IResource>() {new Resource(new Setup(calls)), new Resource(new Setup(calls))};
        }
    }
}