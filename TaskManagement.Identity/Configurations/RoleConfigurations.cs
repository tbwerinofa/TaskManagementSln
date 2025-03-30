using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskManagement.Identity.Configurations;
public class RoleConfigurations: IEntityTypeConfiguration<IdentityRole>
{

    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {

            builder.HasData(
            new IdentityRole
            {
                Id = "4b8f4447-22ec-48aa-966a-f16cbd89d2ad",
                Name = "Employee",
                NormalizedName = "EMPLOYEE"
            },
            new IdentityRole
            {
                Id = "4abc9484-923f-47e6-b7aa-cc3c08d57a35",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            }
        );
    }
}
