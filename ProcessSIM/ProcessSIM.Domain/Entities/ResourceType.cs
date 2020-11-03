using System.Collections.Generic;

namespace ProcessSIM.Domain.Entities
{
    public class ResourceType
    {
        public int ResourceTypeId { get; set; }
        public string ResourceTypeName { get; set; }
        public List<ResourceParameter> ResourceParameters { get; set; }
        public List<Resource> Resources { get; set; }
        public ResourceCategory ResourceCategory { get; set; }
    }
}