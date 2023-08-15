using HrManagement.Application.Contracts.Persistence;
using HrManagement.Domain;
using Moq;

namespace HrManagement.Application.UnitTest.Mocks
{
    public static class MockLeaveRequestRepository
    {
        public static Mock<ILeaveRequestRepository> GetMockLeaveRequestRepository()
        {

            var mockLeaveRequests = new List<LeaveRequest>() {
                new LeaveRequest.Builder()
                .StartDate(DateTime.Now)
                .EndDate(DateTime.Now
                .AddDays(1))
                .Approved(true)
                .Create(),
                new LeaveRequest.Builder()
                .StartDate(DateTime.Now.AddDays(2))
                .EndDate(DateTime.Now.AddDays(3))
                .Approved(true)
                .Create(),
                new LeaveRequest.Builder()
                .StartDate(DateTime.Now.AddDays(4))
                .EndDate(DateTime.Now.AddDays(5))
                .Approved(false).Create()
            };

            var mockRepository = new Mock<ILeaveRequestRepository>();
            mockRepository.Setup(p => p.GetAll()).ReturnsAsync(mockLeaveRequests);
            mockRepository.Setup(p => p.GetById(2)).ReturnsAsync(mockLeaveRequests.FirstOrDefault(p => p.Id == 2));

            mockRepository.Setup(p => p.Add(It.IsAny<LeaveRequest>())).ReturnsAsync((LeaveRequest leaverequest) =>
            {
                mockLeaveRequests.Add(leaverequest);
                return leaverequest;
            });

            return mockRepository;
        }

    }
}
