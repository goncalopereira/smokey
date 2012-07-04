using System.Collections.Generic;
using API.Response;

namespace API.Resource
{
    public interface IResource
    {
        IList<CallResponse> Execute();
        string Url { get; }
        string ExecuteUrl { get; }
        string Name { get; }
    }
}