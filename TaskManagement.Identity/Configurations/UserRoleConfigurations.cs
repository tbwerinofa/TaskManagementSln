using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskManagement.Identity.Configurations;
public class UserRoleConfigurations : IEntityTypeConfiguration<IdentityUserRole<string>>
{

    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {

        //builder.HasData(
        //new IdentityUserRole<string>
        //{
        //    UserId = "ecf58867-b3de-4f8b-a98e-acb65753e43b",
        //    RoleId = "4abc9484-923f-47e6-b7aa-cc3c08d57a35"
        //},
        //new IdentityUserRole<string>
        //{
        //    UserId = "ecf58867-b3de-4f8b-a98e-acb65753e43b",
        //    RoleId = "4b8f4447-22ec-48aa-966a-f16cbd89d2ad"
        //}
    //);
    }
}
