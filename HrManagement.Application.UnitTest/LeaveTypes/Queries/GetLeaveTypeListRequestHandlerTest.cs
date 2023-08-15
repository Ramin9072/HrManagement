using AutoMapper;
using HrManagement.Application.Contracts.Persistence;
using HrManagement.Application.DTOs.LeaveType.DTO;
using HrManagement.Application.Features.LeaveTypes.Handlers.Queries;
using HrManagement.Application.Features.LeaveTypes.Requests.Queries;
using HrManagement.Application.Profiles;
using HrManagement.Application.UnitTest.Mocks;
using Moq;
using Shouldly;

namespace HrManagement.Application.UnitTest.LeaveTypes.Queries
{
    public class GetLeaveTypeListRequestHandlerTest
    {
        IMapper _mapper;
        Mock<ILeaveTypeRepository> _mockLeaveTypeRepository;

        public GetLeaveTypeListRequestHandlerTest()
        {
            _mockLeaveTypeRepository = MockLeaveTypeRepository.GetLeaveTypeRepository();
            var mapperConfig = new MapperConfiguration(p => p.AddProfile<MappingProfile>());
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetLeaveTypeListRequestHandler(_mockLeaveTypeRepository.Object, _mapper); // using ctor

            var result = await handler.Handle(new GetLeaveTypeListRequest(), CancellationToken.None); // handler repository

            result.ShouldBeOfType<List<LeaveTypeDto>>();
            result.Count.ShouldBe(3);
            result.ShouldSatisfyAllConditions();
        }
    }
}
