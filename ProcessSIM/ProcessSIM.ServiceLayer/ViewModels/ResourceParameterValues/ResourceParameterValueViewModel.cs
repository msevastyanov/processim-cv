using ProcessSIM.Domain.Entities;

namespace ProcessSIM.ServiceLayer.ViewModels.ResourceParameterValues
{
    public class ResourceParameterValueViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Value { get; set; }

        public ResourceParameterValueViewModel(ResourceParameterValue parameter)
        {
            Id = parameter.ResourceParameterValueId;
            Name = parameter.ResourceParameter?.ResourceParameterName;
            Alias = parameter.ResourceParameter?.ResourceParameterAlias;
            Value = parameter.ParameterValue;
        }
    }
}