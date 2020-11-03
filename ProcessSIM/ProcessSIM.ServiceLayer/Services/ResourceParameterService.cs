using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessSIM.Domain.Entities;
using ProcessSIM.Infrastructure.Repositories;
using ProcessSIM.ServiceLayer.Models;
using ProcessSIM.ServiceLayer.ViewModels.ResourceParameters;

namespace ProcessSIM.ServiceLayer.Services
{
    public class ResourceParameterService : IResourceParameterService
    {
        private IResourceParameterRepository _resourceParameterRepository;
        private IResourceParameterValueRepository _resourceParameterValueRepository;
        private IResourceTypeRepository _resourceTypeRepository;
            
        public ResourceParameterService(IResourceParameterRepository resourceParameterRepository, IResourceTypeRepository resourceTypeRepository, IResourceParameterValueRepository resourceParameterValueRepository)
        {
            _resourceParameterRepository = resourceParameterRepository;
            _resourceTypeRepository = resourceTypeRepository;
            _resourceParameterValueRepository = resourceParameterValueRepository;
        }

        public async Task<List<ResourceParameterViewModel>> GetResourceParametersByResourceType(int resTypeId)
        {
            var resParameters = await _resourceParameterRepository.GetResourceParametersByType(resTypeId);

            return resParameters.Select(x => new ResourceParameterViewModel(x)).ToList();
        }

        public async Task<RequestResult<ResourceParameterViewModel>> AddResourceParameter(int resTypeId,
            CreateResourceParameterViewModel parameterViewModel)
        {
            var existingParam = await _resourceParameterRepository.GetResourceParametersByType(resTypeId);
            if (existingParam.Count(p => p.ResourceParameterName == parameterViewModel.Name || p.ResourceParameterAlias == parameterViewModel.Alias) > 0)
                return RequestResult<ResourceParameterViewModel>.Failed("У этого типа параметр с таким именем или псевдонимом уже существует");
            
            var resType = await _resourceTypeRepository.FindResourceType(resTypeId, false);
            
            var resParam = new ResourceParameter
            {
                ResourceParameterName = parameterViewModel.Name,
                ResourceParameterAlias = parameterViewModel.Alias,
                ResourceType = resType
            };

            await _resourceParameterRepository.AddResourceParameter(resParam);

            return RequestResult<ResourceParameterViewModel>.Success(new ResourceParameterViewModel(resParam));
        }

        public async Task<RequestResult<ResourceParameterViewModel>> UpdateResourceParameter(int resTypeId, int resParamId,
            UpdateResourceParameterViewModel parameterViewModel)
        {
            var existingParam = await _resourceParameterRepository.GetResourceParametersByType(resTypeId);
            if (existingParam.Count(p =>  p.ResourceParameterAlias == parameterViewModel.Alias && p.ResourceParameterId != resParamId) > 0)
                return RequestResult<ResourceParameterViewModel>.Failed("У этого типа параметр с таким псевдонимом уже существует");
            
            var resParam = await _resourceParameterRepository.FindResourceParameter(resParamId);

            if (resParam == null)
                return RequestResult<ResourceParameterViewModel>.Failed("Параметр не найден");

            resParam.ResourceParameterAlias = parameterViewModel.Alias;

            await _resourceParameterRepository.UpdateResourceParameter(resParam);

            return RequestResult<ResourceParameterViewModel>.Success(new ResourceParameterViewModel(resParam));
        }

        public async Task<RequestResult> DeleteResourceParameter(int paramId)
        {
            var resParam = await _resourceParameterRepository.FindResourceParameter(paramId);
            if (resParam == null)
                return RequestResult.Failed("Параметр типа ресурса не найден");

            var paramValues = await _resourceParameterValueRepository.GetResourceParameterValuesByParameter(paramId);
            if (paramValues.Any())
                return RequestResult.Failed("Нельзя удалить параметр, т.к. существуют ресурсы со значениями этого параметра");
            
            await _resourceParameterRepository.DeleteResourceParameter(paramId);
            
            return RequestResult.Success();
        }
    }
}