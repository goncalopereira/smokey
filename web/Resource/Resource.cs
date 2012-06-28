using web.Call;

namespace web.Resource
{
    public class Resource : IResource
    {
        private ISetup MySetup { get; set; }

        public Resource(ISetup setup)
        {
            MySetup = setup;
        }

        public void Execute()
        {
            MySetup.Execute();
        }
    }
}