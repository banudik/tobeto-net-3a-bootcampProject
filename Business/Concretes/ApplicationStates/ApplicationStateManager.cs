using AutoMapper;
using Business.Abstracts.Applications;
using Business.Abstracts.ApplicationStates;
using Business.Requests.Applications;
using Business.Requests.ApplicationStates;
using Business.Responses.Applications;
using Business.Responses.ApplicationStates;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes.ApplicationStates;

public class ApplicationStateManager:IApplicationStateService
{
    
        private readonly IApplicationStateRepository _applicationStateRepository;
        private readonly IMapper _mapper;

        public ApplicationStateManager(IApplicationStateRepository applicationRepository, IMapper mapper)
        {
            _applicationStateRepository = applicationRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<CreatedApplicationStateResponse>> AddAsync(CreateApplicationStateRequest request)
        {
            ApplicationState applicationState = _mapper.Map<ApplicationState>(request);
            await _applicationStateRepository.AddAsync(applicationState);
            CreatedApplicationStateResponse response = _mapper.Map<CreatedApplicationStateResponse>(applicationState);
            return new SuccessDataResult<CreatedApplicationStateResponse>(response, "Added Successfully");
        }

        public async Task<IDataResult<DeletedApplicationStateResponse>> DeleteAsync(DeleteApplicationStateRequest request)
        {
            ApplicationState applicationState = _mapper.Map<ApplicationState>(request);
            await _applicationStateRepository.DeleteAsync(applicationState);
        DeletedApplicationStateResponse response = _mapper.Map<DeletedApplicationStateResponse>(applicationState);
            return new SuccessDataResult<DeletedApplicationStateResponse>(response, "Deleted Successfully");
        }

        public async Task<IDataResult<List<GetAllApplicationStateResponse>>> GetAllAsync()
        {
            var list = await _applicationStateRepository.GetAllAsync();
            List<GetAllApplicationStateResponse> response = _mapper.Map<List<GetAllApplicationStateResponse>>(list);
            return new SuccessDataResult<List<GetAllApplicationStateResponse>>(response, "Listed Successfully");
        }

        public async Task<IDataResult<GetByIdApplicationStateResponse>> GetByIdAsync(int id)
        {
            var item = await _applicationStateRepository.GetAsync(x => x.Id == id);

        GetByIdApplicationStateResponse response = _mapper.Map<GetByIdApplicationStateResponse>(item);

            if (item != null)
            {
                return new SuccessDataResult<GetByIdApplicationStateResponse>(response, "Found Succesfully.");
            }
            return new ErrorDataResult<GetByIdApplicationStateResponse>("ApplicationState could not be found.");
        }

        public async Task<IDataResult<UpdatedApplicationStateResponse>> UpdateAsync(UpdateApplicationStateRequest request)
        {
            var item = await _applicationStateRepository.GetAsync(p => p.Id == request.Id);
            if (request.Id == 0 || item == null)
            {
                return new ErrorDataResult<UpdatedApplicationStateResponse>("ApplicationState could not be found.");
            }

            _mapper.Map(request, item);
            await _applicationStateRepository.UpdateAsync(item);

        UpdatedApplicationStateResponse response = _mapper.Map<UpdatedApplicationStateResponse>(item);
            return new SuccessDataResult<UpdatedApplicationStateResponse>(response, "ApplicationState succesfully updated!");
        }

}
