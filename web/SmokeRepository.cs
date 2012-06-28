using System.Collections.Generic;

namespace web
{
    public class SmokeRepository : ISmokeRepository
    {
        public ISmoke Get(string id)
        {
            return new Smoke(new Setup(new List<ICall>()));
        }
    }
}