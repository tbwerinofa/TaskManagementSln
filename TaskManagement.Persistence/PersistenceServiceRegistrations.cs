using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Persistence.DatabaseContext;
using TaskManagement.Persistence.Repository;

namespace TaskManagement.Persistence;
    public static class PersistenceServiceRegistrations
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<TaskDatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("HrDatabaseConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ITaskStatusEntityRepository, TaskStatusEntityRepository>();
            services.AddScoped<ITaskEntityRepository, TaskEntityRepository>();

            return services;
        }
    }

