using TaskManagement.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Identity.DbContext;
public class TaskManagementIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public TaskManagementIdentityDbContext(DbContextOptions<TaskManagementIdentityDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(TaskManagementIdentityDbContext).Assembly);
    }
}
