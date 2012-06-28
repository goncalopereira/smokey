using System.Collections.Generic;

namespace web.Call
{
    public interface ISetup
    {
        IList<CallResponse> Execute();
    }
}