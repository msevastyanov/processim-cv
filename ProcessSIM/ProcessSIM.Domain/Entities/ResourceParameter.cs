namespace ProcessSIM.Domain.Entities
{
    public class ResourceParameter
    {
        public int ResourceParameterId { get; set; }
        public string ResourceParameterName { get; set; }
        public string ResourceParameterAlias { get; set; }
        public ResourceType ResourceType { get; set; }
    }
}