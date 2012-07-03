using System.Collections.Generic;

namespace web.Resource
{
    public interface IResource
    {
        IList<CallResponse.CallResponse> Execute();
        string Url { get; }
        string ExecuteUrl { get; }
        string Name { get; }
    }
}