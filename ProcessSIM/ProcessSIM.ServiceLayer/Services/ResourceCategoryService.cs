using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessSIM.Domain.Entities;
using ProcessSIM.Infrastructure.Repositories;
using ProcessSIM.ServiceLayer.Models;
using ProcessSIM.ServiceLayer.ViewModels.ResourceCategories;

namespace ProcessSIM.ServiceLayer.Services
{
    public class ResourceCategoryService : IResourceCategoryService
    {
        private IResourceCategoryRepository _resourceCategoryRepository;

        public ResourceCategoryService(IResourceCategoryRepository resourceCategoryRepository)
        {
            _resourceCategoryRepository = resourceCategoryRepository;
        }

        public async Task<List<ResourceCategoryViewModel>> GetAllResourceCategories()
        {
            var resCategories = await _resourceCategoryRepository.GetAllResourceCategories();

            return resCategories.Select(x => new ResourceCategoryViewModel(x)).ToList();
        }

        public async Task<RequestResult<ResourceCategoryViewModel>> AddResourceCategory(
            CreateResourceCategoryViewModel categoryViewModel)
        {
            var existingCategory = await _resourceCategoryRepository.FindResourceCategoryByName(categoryViewModel.Name);
            if (existingCategory != null)
                return RequestResult<ResourceCategoryViewModel>.Failed("Категория с таким именем уже существует");

            var resCategory = new ResourceCategory
            {
                ResourceCategoryName = categoryViewModel.Name
            };

            await _resourceCategoryRepository.AddResourceCategory(resCategory);
            
            resCategory.ResourceTypes = new List<ResourceType>();

            return RequestResult<ResourceCategoryViewModel>.Success(new ResourceCategoryViewModel(resCategory));
        }

        public async Task<RequestResult<ResourceCategoryViewModel>> UpdateResourceCategory(int catId,
            UpdateResourceCategoryViewModel categoryViewModel)
        {
            var resCategory = await _resourceCategoryRepository.FindResourceCategory(catId, true);

            if (resCategory == null)
                return RequestResult<ResourceCategoryViewModel>.Failed("Категория не найдена");
            
            var existingCategory = await _resourceCategoryRepository.FindResourceCategoryByName(categoryViewModel.Name);
            if (existingCategory != null && existingCategory.ResourceCategoryId != resCategory.ResourceCategoryId)
                return RequestResult<ResourceCategoryViewModel>.Failed("Категория с таким именем уже существует");

            resCategory.ResourceCategoryName = categoryViewModel.Name;

            await _resourceCategoryRepository.UpdateResourceCategory(resCategory);

            return RequestResult<ResourceCategoryViewModel>.Success(new ResourceCategoryViewModel(resCategory));
        }

        public async Task<RequestResult> DeleteResourceCategory(int catId)
        {
            var resCategory = await _resourceCategoryRepository.FindResourceCategory(catId, true);

            if (resCategory.ResourceTypes.Any())
                return RequestResult.Failed("Нельзя удалить категорию, т.к. существуют относящиеся к ней типы ресурсов");
            if (resCategory.Resources.Any())
                return RequestResult.Failed("Нельзя удалить категорию, т.к. существуют относящиеся к ней ресурсы");

            await _resourceCategoryRepository.DeleteResourceCategory(catId);

            return RequestResult.Success();
        }
    }
}