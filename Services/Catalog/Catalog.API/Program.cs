
using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.CORE.Repositories;
using Catalog.Infrastructure.Data;

namespace Catalog.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Catalog.API", Version = "v1" }); });

            /* Register AutoMapper
             * 
             * Scan the catalog.Application assembly, because that's where ProductMappingProfile is defined
             * and automatically register all AutoMapper mapping profiles found there
             * 
             * This allows us to inject IMapper anywhere in the application and use
             * predefinded mapping between domain entities and DTO
             */
            builder.Services.AddAutoMapper(typeof(ProductMappingProfile).Assembly);

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllBrandsQuery).Assembly));

            builder.Services.AddScoped<ICatalogContext, CatalogContext>();
            builder.Services.AddScoped<IProductRepository, IProductRepository>();
            builder.Services.AddScoped<ITypeRepository, ITypeRepository>();
            builder.Services.AddScoped<IBrandRepository, IBrandRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
