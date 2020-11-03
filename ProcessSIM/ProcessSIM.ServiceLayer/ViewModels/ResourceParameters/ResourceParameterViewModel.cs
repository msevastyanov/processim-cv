using ProcessSIM.Domain.Entities;

namespace ProcessSIM.ServiceLayer.ViewModels.ResourceParameters
{
    public class ResourceParameterViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }

        public ResourceParameterViewModel(ResourceParameter parameter)
        {
            Id = parameter.ResourceParameterId;
            Name = parameter.ResourceParameterName;
            Alias = parameter.ResourceParameterAlias;
        }
    }
}