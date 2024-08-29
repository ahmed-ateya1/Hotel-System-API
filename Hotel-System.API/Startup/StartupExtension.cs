using Hotel_System.Core;
using Hotel_System.Core.RepositoriyContracts;
using Hotel_System.Core.ServiceContracts;
using Hotel_System.Core.Services;
using Hotel_System.Infrastructure.Data;
using Hotel_System.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hotel_System.API.Startup
{
    public static class StartupExtension
    {
        public static IServiceCollection ServicesConfiguration(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("connstr"));
            });
            services.AddScoped<IVillaRepository , VillaRepository>();
            services.AddScoped<IVillaServices, VillaServices>();

            services.AddAutoMapper(typeof(MappingConfig));
            services.AddControllers().AddNewtonsoftJson();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
