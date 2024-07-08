using API.Context;
using API.Models;
using API.Models.Dto.Response;
using API.Services;
using API.Services.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace API.Extension
{
    public static class ExtensionService
    {
        public static IServiceCollection ServiceInjection(this IServiceCollection services, IConfiguration configuration)
        {
            InjectBdd(services, configuration);
            InjectService(services);
            InjectMapper(services);
            Swagger(services);
            return services;
        }

        private static void InjectService(IServiceCollection services)
        {
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IEquipeService, EquipeService>();
            services.AddScoped<IEtapeService, EtapeService>();
        }

        private static void InjectBdd(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Psql") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<CourseContext>(opt =>
                opt.UseNpgsql(
                    connectionString)
            );
        }
        private static void InjectMapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.CreateMap<Admin,API.Models.Dto.Response.AdminDto>();
                mc.CreateMap<Equipe,API.Models.Dto.Response.EquipeDto>();

                mc.CreateMap<API.Models.Dto.Request.AdminDto, Admin>();
                mc.CreateMap<API.Models.Dto.Request.EquipeDto, Equipe>();
                mc.CreateMap<API.Models.Dto.Request.EtapeDto, Etape>();
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        private static void Swagger(IServiceCollection services)
        {

            services.AddSwaggerGen(x =>
            {
                x.MapType<DateTime>(() =>
                {
                    return new OpenApiSchema()
                    {
                        Type = "string",
                        Format = "date-time"
                    };
                });
            });
        }
    }
}
