using System.Collections.Generic;
using System.Linq;
using ProcessSIM.Domain.Entities;
using ProcessSIM.ServiceLayer.ViewModels.ResourceTypes;

namespace ProcessSIM.ServiceLayer.ViewModels.ResourceCategories
{
    public class ResourceCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ResourceTypeViewModel> ResourceTypes { get; set; }

        public ResourceCategoryViewModel(ResourceCategory category)
        {
            Id = category.ResourceCategoryId;
            Name = category.ResourceCategoryName;
            ResourceTypes = category.ResourceTypes != null
                ? category.ResourceTypes.Select(x => new ResourceTypeViewModel(x)).ToList()
                : new List<ResourceTypeViewModel>();
        }
    }
}