using ProcessSIM.Domain.Entities;

namespace ProcessSIM.ServiceLayer.ViewModels.ResourceTypes
{
    public class ResourceTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ResourceTypeViewModel(ResourceType resType)
        {
            Id = resType.ResourceTypeId;
            Name = resType.ResourceTypeName;
        }
    }
}