using AutoMapper;
using HrManagement.Application.Contracts.Infrastructure.Abstraction;
using HrManagement.Application.Contracts.Persistence;
using HrManagement.Application.DTOs.LeaveType.DTO;
using HrManagement.Application.Features.LeaveTypes.Handlers.Commands;
using HrManagement.Application.Features.LeaveTypes.Requests.Commands;
using HrManagement.Application.Profiles;
using HrManagement.Application.UnitTest.Mocks;
using Moq;
using Shouldly;

namespace HrManagement.Application.UnitTest.LeaveTypes.Command
{
    public class CreateLeaveTypeCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly Mock<ILeaveTypeRepository> _mockLeaveTypeRepo;
        private readonly CreateLeaveTypeDto _leaveType;

        public CreateLeaveTypeCommandHandlerTests()
        {
            _mockLeaveTypeRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();
            var mapConfig = new MapperConfiguration(p => p.AddProfile<MappingProfile>());
            _mapper = mapConfig.CreateMapper();
            _leaveType = new CreateLeaveTypeDto()
            {
                Id = 3,
                DefaultDay = 15,
                Name = "Test Dto"
            };

        }
        [Fact]
        public async Task CreateLeaveType()
        {
            var handler = new CreateLeaveTypeCommandHandler(_mockLeaveTypeRepo.Object, _mapper, _emailSender);
            var result = await handler.Handle(new CreateLeaveTypeCommand()
            {
                LeaveTypeDto = _leaveType
            }, CancellationToken.None);

            result.ShouldBeOfType<int>();
            var leaveTypes =await _mockLeaveTypeRepo.Object.GetAll();
            leaveTypes.Count.ShouldBe(3);
        }
    }
}
