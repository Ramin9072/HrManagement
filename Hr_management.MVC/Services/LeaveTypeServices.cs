using AutoMapper;
using Hr_management.MVC.Contracts;
using Hr_management.MVC.Contracts.LeaveType;
using Hr_management.MVC.Models;
using Hr_management.MVC.Services.Base;

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

        public async Task<Response<int>> CreateLeaveType(LeaveTypeVM leaveType)
        {
            try
            {
                var response = new Response<int>();
                CreateLeaveTypeDto createLeaveTypeDto =
                    _mapper.Map<CreateLeaveTypeDto>(leaveType);

                var apiResponse = _httpClient.LeaveTypePOSTAsync(createLeaveTypeDto);
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

        public Task DeleteLeaveType(LeaveTypeVM leaveType)
        {
            throw new NotImplementedException();
        }

        public Task<LeaveTypeVM> GetLeaveTypeDetailById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            var response = new Response<List<LeaveTypeVM>>();
            string cackKey = "leaveTypeList";
            List<LeaveTypeDto> leaveTypes = new List<LeaveTypeDto>();

            if (!_localStorage.Exists(cackKey))
                _localStorage.SetStorageValue(cackKey, await _httpClient.LeaveTypeAllAsync());
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

        public Task UpdateLeaveType(LeaveTypeVM leaveType)
        {
            throw new NotImplementedException();
        }
    }
}
