using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using web.Call;

namespace web.Resource
{
    public class ResourceRepository : IResourceRepository
    {
    
        private static readonly string ConfigJson = string.Format(@"{0}\config.json",
                                                                  Path.GetDirectoryName(
                                                                      AppDomain.CurrentDomain.BaseDirectory));
        public IResource Get(string id)
        {
            return GetResources()[id];
        }

        private IDictionary<string, IResource> GetResources()
        {
            IDictionary<string, IResource> allResources = new Dictionary<string, IResource>();
            using (var reader = File.OpenText(ConfigJson))
            {
                string jsonString = reader.ReadToEnd();

                //until I have time to use the customAttribute here and get it to work....
                List<ResourceDTO> resources = JsonConvert.DeserializeObject<List<ResourceDTO>>(jsonString);
                foreach (var dto in resources)
                {
                    allResources.Add(dto.Name, new Resource(new List<ICall>(dto.Calls), dto.Name));
                }
            }
            return allResources;
        }

        public IList<IResource> GetAll()
        {
            return GetResources().Values.ToList();
        }
    }
}