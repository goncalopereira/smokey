using System.Collections.Generic;
using web.Call;

namespace web.Resource
{
    public interface IResource
    {
        IList<CallResponse> Execute();
    }
}