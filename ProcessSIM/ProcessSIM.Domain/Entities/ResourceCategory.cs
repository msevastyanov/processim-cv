using System.Collections.Generic;

namespace ProcessSIM.Domain.Entities
{
    public class ResourceCategory
    {
        public int ResourceCategoryId { get; set; }
        public string ResourceCategoryName { get; set; }
        public List<ResourceType> ResourceTypes { get; set; }
        public List<Resource> Resources { get; set; }
    }
}