using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessSIM.Infrastructure.Repositories;
using ProcessSIM.ServiceLayer.Models;
using ProcessSIM.ServiceLayer.ViewModels.ResourceParameterValues;

namespace ProcessSIM.ServiceLayer.Services
{
    public class ResourceParameterValueService : IResourceParameterValueService
    {
        private IResourceParameterValueRepository _resourceParameterValueRepository;

        public ResourceParameterValueService(IResourceParameterValueRepository resourceParameterValueRepository)
        {
            _resourceParameterValueRepository = resourceParameterValueRepository;
        }

        public async Task<List<ResourceParameterValueViewModel>> GetResourceParametersByResource(int resId)
        {
            var resParameters = await _resourceParameterValueRepository.GetResourceParameterValuesByResource(resId);

            return resParameters.Select(x => new ResourceParameterValueViewModel(x)).ToList();
        }

        public async Task<RequestResult<ResourceParameterValueViewModel>>
            GetResourceParameterValue(int paramId, int resourceId)
        {
            var paramValue = await _resourceParameterValueRepository.FindResourceParameterValue(paramId, resourceId);

            return paramValue == null
                ? RequestResult<ResourceParameterValueViewModel>.Failed("Параметр не найден")
                : RequestResult<ResourceParameterValueViewModel>.Success(
                    new ResourceParameterValueViewModel(paramValue));
        }

        public async Task<RequestResult<ResourceParameterValueViewModel>>
            UpdateResourceParameterValue(int paramValueId, UpdateResourceParameterValueViewModel paramValueViewModel)
        {
            var paramValue = await _resourceParameterValueRepository.FindResourceParameterValue(paramValueId);

            if (paramValue == null)
                return RequestResult<ResourceParameterValueViewModel>.Failed("Параметр не найден");

            paramValue.ParameterValue = paramValueViewModel.Value;

            await _resourceParameterValueRepository.UpdateResourceParameterValue(paramValue);

            return RequestResult<ResourceParameterValueViewModel>.Success(
                new ResourceParameterValueViewModel(paramValue));
        }
    }
}