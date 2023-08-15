using HrManagement.Application.Contracts.Persistence;
using HrManagement.Domain;
using Moq;

namespace HrManagement.Application.UnitTest.Mocks
{
    public static class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
        {
            var mockLeaveTypes = new List<LeaveType>() {
                new LeaveType.Builder().Id(1).DefaultDay(10).Name("Test Vacation").Create(),
                new LeaveType.Builder().Id(2).DefaultDay(12).Name("Test Sick").Create(),
                new LeaveType.Builder().Id(3).DefaultDay(14).Name("Test CronaVirus").Create()
            };

            var mockRepository = new Mock<ILeaveTypeRepository>();
            mockRepository.Setup(p => p.GetAll()).ReturnsAsync(mockLeaveTypes);
            mockRepository.Setup(p => p.GetById(2)).ReturnsAsync(mockLeaveTypes.FirstOrDefault(p => p.Id == 2));

            mockRepository.Setup(p => p.Add(It.IsAny<LeaveType>())).ReturnsAsync((LeaveType leaveType) =>
            {
                mockLeaveTypes.Add(leaveType);
                return leaveType;
            });

            return mockRepository;

        }
    }
}
