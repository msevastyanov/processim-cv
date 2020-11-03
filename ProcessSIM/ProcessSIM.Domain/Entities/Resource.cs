using System.Collections.Generic;

namespace ProcessSIM.Domain.Entities
{
    public class Resource
    {
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public decimal Price { get; set; }
        public List<ResourceParameterValue> ResourceParameterValues { get; set; }
        public ResourceType ResourceType { get; set; }
        public ResourceCategory ResourceCategory { get; set; }
    }
}