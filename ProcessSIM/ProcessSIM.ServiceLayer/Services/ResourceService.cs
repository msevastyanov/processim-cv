using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessSIM.Domain.Entities;
using ProcessSIM.Infrastructure.Repositories;
using ProcessSIM.ServiceLayer.Models;
using ProcessSIM.ServiceLayer.ViewModels.ResourceCategories;
using ProcessSIM.ServiceLayer.ViewModels.Resources;
using ProcessSIM.ServiceLayer.ViewModels.ResourceTypes;

namespace ProcessSIM.ServiceLayer.Services
{
    public class ResourceService : IResourceService
    {
        private IResourceRepository _resourceRepository;
        private IResourceTypeRepository _resourceTypeRepository;
        private IResourceParameterValueRepository _resourceParameterValueRepository;

        public ResourceService(IResourceRepository resourceRepository, IResourceTypeRepository resourceTypeRepository,
            IResourceParameterValueRepository resourceParameterValueRepository)
        {
            _resourceRepository = resourceRepository;
            _resourceTypeRepository = resourceTypeRepository;
            _resourceParameterValueRepository = resourceParameterValueRepository;
        }

        public async Task<List<ResourceViewModel>> GetResourcesByType(int typeId)
        {
            var resources = await _resourceRepository.GetResourcesByType(typeId);

            return resources.Select(x => new ResourceViewModel(x)).ToList();
        }

        public async Task<List<ResourceViewModel>> GetAllResources()
        {
            var resources = await _resourceRepository.GetAllResources();

            return resources.Select(x => new ResourceViewModel(x)).ToList();
        }

        public async Task<RequestResult<ResourceViewModel>> AddResource(int typeId,
            CreateResourceViewModel resourceViewModel)
        {
            var resType = await _resourceTypeRepository.FindResourceType(typeId, true);
            
            if (resType == null)
                return RequestResult<ResourceViewModel>.Failed("Тип ресурса не найден");
            
            var existingResource = await _resourceRepository.FindResourceByName(resourceViewModel.Name);
            if (existingResource != null)
                return RequestResult<ResourceViewModel>.Failed("Ресурс с таким именем уже существует");

            var resParameterValues = resType.ResourceParameters.Select(resParam => new ResourceParameterValue
                {ParameterValue = "", ResourceParameter = resParam}).ToList();

            await _resourceParameterValueRepository.AddResourceParameterValues(resParameterValues);

            var resource = new Resource
            {
                ResourceName = resourceViewModel.Name,
                Price = resourceViewModel.Price,
                ResourceType = resType,
                ResourceParameterValues = resParameterValues
            };

            await _resourceRepository.AddResource(resource);

            return RequestResult<ResourceViewModel>.Success(new ResourceViewModel(resource));
        }

        public async Task<RequestResult<ResourceViewModel>> UpdateResource(int resourceId,
            UpdateResourceViewModel resourceViewModel)
        {
            var resource = await _resourceRepository.FindResource(resourceId, false);

            if (resource == null)
                return RequestResult<ResourceViewModel>.Failed("Ресурс не найден");
            
            var existingResource = await _resourceRepository.FindResourceByName(resourceViewModel.Name);
            if (existingResource != null && existingResource.ResourceId != resource.ResourceId)
                return RequestResult<ResourceViewModel>.Failed("Ресурс с таким именем уже существует");
            
            resource.ResourceName = resourceViewModel.Name;
            resource.Price = resourceViewModel.Price;

            await _resourceRepository.UpdateResource(resource);

            return RequestResult<ResourceViewModel>.Success(new ResourceViewModel(resource));
        }

        public async Task<RequestResult> DeleteResource(int resourceId)
        {
            var resource = await _resourceRepository.FindResource(resourceId, false);
            if (resource == null)
                return RequestResult.Failed("Ресурс не найден");

            await _resourceParameterValueRepository.DeleteResourceParameterValuesByResource(resourceId);
            await _resourceRepository.DeleteResource(resourceId);

            return RequestResult.Success();
        }
    }
}