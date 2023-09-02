using AutoMapper;
using Hr_management.MVC.Contracts;
using Hr_management.MVC.Contracts.LeaveType;
using Hr_management.MVC.Models.LeaveType;
using Hr_management.MVC.Services.Base;
using Microsoft.CodeAnalysis;

namespace Hr_management.MVC.Services
{
    public class LeaveTypeServices : BaseHttpService, ILeaveTypeService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IClient _httpClient;
        private readonly IMapper _mapper;

        public LeaveTypeServices(ILocalStorageService localStorageService, IClient client, IMapper mapper)
            : base(localStorageService, client)
        {
            _localStorage = localStorageService;
            _httpClient = client;
            _mapper = mapper;
        }

        public async Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM leaveType)
        {
            try
            {
                var response = new Response<int>();
                CreateLeaveTypeDto createLeaveTypeDto = _mapper.Map<CreateLeaveTypeDto>(leaveType);

                var apiResponse = _httpClient.LeaveTypesPOSTAsync(createLeaveTypeDto);
                if (apiResponse.IsCompletedSuccessfully)
                {
                    response.Data = apiResponse.Id;
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                }

                return response;
            }
            catch (ApiException ex) // my exception
            {

                return ConvertApiExceptions<int>(ex);
            }
        }

       

        public async Task<LeaveTypeVM> GetLeaveTypeDetailById(int id)
        {
            var response = new Response<LeaveTypeVM>();
            var leaveType = await _httpClient.LeaveTypesGETAsync(id);
            var leaveTypeVm = _mapper.Map<LeaveTypeVM>(leaveType);
            if (leaveTypeVm is not null)
            {
                response.Success = true;
                response.Data = leaveTypeVm;
            }
            else
            {
                response.Success = false;
            }
            return leaveTypeVm;
        }

        public async Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            var response = new Response<List<LeaveTypeVM>>();
            string cackKey = "leaveTypeList";
            List<LeaveTypeDto> leaveTypes = new List<LeaveTypeDto>();

            if (!_localStorage.Exists(cackKey))
                _localStorage.SetStorageValue(cackKey, await _httpClient.LeaveTypesAllAsync());
            leaveTypes = _localStorage.GetStorageValue<List<LeaveTypeDto>>(cackKey);

            var leaveTypesVM = _mapper.Map<List<LeaveTypeVM>>(leaveTypes);

            if (leaveTypesVM is not null)
            {
                response.Success = true;
                response.Data = leaveTypesVM;
            }
            else
            {
                response.Success = false;
            }

            return leaveTypesVM;
        }

        public async Task<Response<int>> UpdateLeaveType(LeaveTypeVM leaveTypeVm)
        {
            var response = new Response<int>();
            var leaveType = _mapper.Map<LeaveTypeDto>(leaveTypeVm);
            var apiResponse = _httpClient.LeaveTypesPUTAsync(leaveType.Id, leaveType);

            if (apiResponse.IsCompletedSuccessfully)
            {
                response.Data = apiResponse.Id;
                response.Success = true;
            }
            else
            {
                response.Success = false;
            }
            return response;

        }
        public async Task DeleteLeaveType(int id)
        {
            await _httpClient.LeaveTypesDELETEAsync(id);
        }

    }
}
