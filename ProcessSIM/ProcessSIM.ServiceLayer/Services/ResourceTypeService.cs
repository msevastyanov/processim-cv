using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessSIM.Domain.Entities;
using ProcessSIM.Infrastructure.Repositories;
using ProcessSIM.ServiceLayer.Models;
using ProcessSIM.ServiceLayer.ViewModels.ResourceTypes;

namespace ProcessSIM.ServiceLayer.Services
{
    public class ResourceTypeService : IResourceTypeService
    {
        private IResourceTypeRepository _resourceTypeRepository;
        private IResourceCategoryRepository _resourceCategoryRepository;
        private IResourceParameterRepository _resourceParameterRepository;

        public ResourceTypeService(IResourceTypeRepository resourceTypeRepository,
            IResourceCategoryRepository resourceCategoryRepository,
            IResourceParameterRepository resourceParameterRepository)
        {
            _resourceTypeRepository = resourceTypeRepository;
            _resourceCategoryRepository = resourceCategoryRepository;
            _resourceParameterRepository = resourceParameterRepository;
        }

        public async Task<RequestResult<ResourceTypeViewModel>> GetResourceType(int resTypeId)
        {
            var resType = await _resourceTypeRepository.FindResourceType(resTypeId, false);
            return resType == null
                ? RequestResult<ResourceTypeViewModel>.Failed("Тип не найден")
                : RequestResult<ResourceTypeViewModel>.Success(new ResourceTypeViewModel(resType));
        }

        public async Task<RequestResult<ResourceTypeViewModel>> AddResourceType(int resCatId,
            CreateResourceTypeViewModel typeViewModel)
        {
            var existingType = await _resourceTypeRepository.FindResourceTypeByName(typeViewModel.Name);
            if (existingType != null)
                return RequestResult<ResourceTypeViewModel>.Failed("Тип с таким именем уже существует");

            var resCat = await _resourceCategoryRepository.FindResourceCategory(resCatId, false);

            var resType = new ResourceType
            {
                ResourceTypeName = typeViewModel.Name,
                ResourceCategory = resCat
            };

            await _resourceTypeRepository.AddResourceType(resType);

            return RequestResult<ResourceTypeViewModel>.Success(new ResourceTypeViewModel(resType));
        }

        public async Task<RequestResult<ResourceTypeViewModel>> UpdateResourceType(int typeId,
            UpdateResourceTypeViewModel typeViewModel)
        {
            var resType = await _resourceTypeRepository.FindResourceType(typeId, false);

            if (resType == null)
                return RequestResult<ResourceTypeViewModel>.Failed("Тип ресурса не найден");

            var existingType = await _resourceTypeRepository.FindResourceTypeByName(typeViewModel.Name);
            if (existingType != null && existingType.ResourceTypeId != resType.ResourceTypeId)
                return RequestResult<ResourceTypeViewModel>.Failed("Тип с таким именем уже существует");

            resType.ResourceTypeName = typeViewModel.Name;

            await _resourceTypeRepository.UpdateResourceType(resType);

            return RequestResult<ResourceTypeViewModel>.Success(new ResourceTypeViewModel(resType));
        }

        public async Task<RequestResult> DeleteResourceType(int catId)
        {
            var resType = await _resourceTypeRepository.FindResourceType(catId, true);
            if (resType == null)
                return RequestResult.Failed("Тип ресурса не найден");

            if (resType.Resources.Any())
                return RequestResult.Failed("Нельзя удалить тип, т.к. существуют относящиеся к нему ресурсы");

            await _resourceParameterRepository.DeleteResourceParametersByResourceType(catId);
            await _resourceTypeRepository.DeleteResourceType(catId);

            return RequestResult.Success();
        }
    }
}