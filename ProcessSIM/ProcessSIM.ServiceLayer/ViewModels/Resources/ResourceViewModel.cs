using System.Collections.Generic;
using System.Linq;
using ProcessSIM.Domain.Entities;
using ProcessSIM.ServiceLayer.ViewModels.ResourceParameterValues;

namespace ProcessSIM.ServiceLayer.ViewModels.Resources
{
    public class ResourceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public List<ResourceParameterValueViewModel> Parameters { get; set; }

        public ResourceViewModel(Resource resource)
        {
            Id = resource.ResourceId;
            Name = resource.ResourceName;
            Price = resource.Price;
            Type = resource.ResourceType?.ResourceTypeName;
            Category = resource.ResourceCategory?.ResourceCategoryName;
            Parameters = resource.ResourceParameterValues?.Select(x => new ResourceParameterValueViewModel(x)).ToList();
        }
    }
}