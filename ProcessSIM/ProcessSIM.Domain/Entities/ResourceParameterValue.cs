namespace ProcessSIM.Domain.Entities
{
    public class ResourceParameterValue
    {
        public int ResourceParameterValueId { get; set; }
        public string ParameterValue { get; set; }
        public ResourceParameter ResourceParameter { get; set; }
        public Resource Resource { get; set; }
    }
}