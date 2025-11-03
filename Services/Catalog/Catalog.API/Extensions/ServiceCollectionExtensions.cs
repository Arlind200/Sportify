using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Sorting;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories;

namespace Catalog.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            // AutoMapper
            services.AddAutoMapper(typeof(ProductMappingProfile).Assembly);

            // MediatR
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(typeof(GetAllBrandsQuery).Assembly));

            // Catalog and repositories
            services.AddScoped<ICatalogContext, CatalogContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ITypeRepository, ITypeRepository>();
            services.AddScoped<IBrandRepository, ProductRepository>();

            // sorting Strategies and Factory
            services.AddScoped<ISortStrategy, PriceAscSortStrategy>();
            services.AddScoped<ISortStrategy, PriceDescSortStrategy>();
            services.AddScoped<ISortStrategy, NameSortStrategy>();
            services.AddScoped<ISortStrategyFactory, SortStrategyFactoring>();


            return services;
        }

        public static IServiceCollection AddApiVersioningConfig(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new Asp.Versioning.ApiVersion(1, 0);
            });

            return services;
        }

        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo 
                { 
                    Title = "Catalog.API", 
                    Version = "v1" 
                }); 
            });


            return services;
        }
    }
}
