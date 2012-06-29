using System.Collections.Generic;
using web.Call;

namespace web.Resource
{
    public class Resource : IResource
    {
        public ISetup Calls { get; private set; }

        public Resource(ISetup setup)
        {
            Calls = setup;
        }

        public IList<CallResponse> Execute()
        {
            return Calls.Execute();
        }
    }
}