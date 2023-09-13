using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HrManagement.Identity.Configurations
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            // seed data
            builder.HasData(
                    new IdentityRole
                    {
                        Id = "6a838a36-3abf-4059-bd35-18ce590711b3",
                        Name = "Administrator",
                        NormalizedName = "ADMINISTRATOR",
                        ConcurrencyStamp = DateTime.Now.ToString()
                    },
                    new IdentityRole
                    {
                        Id = "d4ae26cc-7cbe-44b7-9112-5947150cedde",
                        Name = "Employee",
                        NormalizedName = "EMPLOYEE",
                        ConcurrencyStamp = DateTime.Now.ToString()
                    }
                );
        }
    }

}
