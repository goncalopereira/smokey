using System;
using Nancy;
using Nancy.Conventions;

namespace API
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            Func<NancyContext, string, Nancy.Response> addDirectory = StaticContentConventionBuilder.AddDirectory("/public", @"/public");
            nancyConventions.StaticContentsConventions.Add(addDirectory);
        }
    }
}