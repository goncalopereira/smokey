namespace web
{
    public class Smoke : ISmoke
    {
        private ISetup MySetup { get; set; }

        public Smoke(ISetup setup)
        {
            MySetup = setup;
        }

        public void Execute()
        {
            MySetup.Execute();
        }
    }
}