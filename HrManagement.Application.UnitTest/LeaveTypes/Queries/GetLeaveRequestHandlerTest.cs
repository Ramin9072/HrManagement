﻿using AutoMapper;
using HrManagement.Application.Contracts.Persistence;
using HrManagement.Application.DTOs.LeaveRequest.DTO;
using HrManagement.Application.Features.LeaveRequests.Handlers.Queries;
using HrManagement.Application.Features.LeaveRequests.Requests.Queries;
using HrManagement.Application.Profiles;
using HrManagement.Application.UnitTest.Mocks;
using Moq;
using Shouldly;

namespace HrManagement.Application.UnitTest.LeaveTypes.Queries
{
    public class GetLeaveRequestHandlerTest
    {
        IMapper _mapper;
        Mock<ILeaveRequestRepository> _mockLeaveRequestRepo;

        public GetLeaveRequestHandlerTest()
        {
            _mockLeaveRequestRepo = MockLeaveRequestRepository.GetMockLeaveRequestRepository();
            var mapConfig = new MapperConfiguration(p => p.AddProfile<MappingProfile>());
            _mapper = mapConfig.CreateMapper();
        }


        [Fact]
        public async Task GetLeaveRequest_Same_Type_Test()
        {
            var handler = new GetLeaveRequestListRequestHandler(_mockLeaveRequestRepo.Object, _mapper);
            var result = await handler.Handle(new GetLeaveRequestListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<LeaveRequestDto>>();
            result.Count.ShouldBe(1);

        }

    }
}
