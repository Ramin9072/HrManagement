using HrManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HrManagement.EfCore.Configurations.Entities
{

    // Seed Data
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
                new LeaveType.Builder().Name("Vacation").DefaultDay(10).Id(1).Create(),
                new LeaveType.Builder().Name("Sick").DefaultDay(12).Id(2).Create(),
                new LeaveType.Builder().Name("CronaVirus").DefaultDay(20).Id(3).Create()
                );


        }
    }
}
