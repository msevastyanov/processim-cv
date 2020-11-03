using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ProcessSIM.ServiceLayer.ViewModels.Resources
{
    public class CreateResourceViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}