using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HrManagement.Identity.Configurations
{
    public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                    //admin
                    new IdentityUserRole<string>
                    {
                        UserId = "71e38b69-d09a-49f1-b6b3-99a751bd6d1c",
                        RoleId = "6a838a36-3abf-4059-bd35-18ce590711b3"
                    },
                    // user1
                    new IdentityUserRole<string>
                    {
                        UserId = "04bef0f7-87b1-403c-93a1-e04a9c1beb0b",
                        RoleId = "d4ae26cc-7cbe-44b7-9112-5947150cedde"
                    }
                );
        }
    }

}
