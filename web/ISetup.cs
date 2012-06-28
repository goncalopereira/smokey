using System.Collections.Generic;

namespace web
{
    public interface ISetup
    {
        IEnumerable<CallResponse> Execute();
    }
}