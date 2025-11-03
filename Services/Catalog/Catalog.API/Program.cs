
using Catalog.API.Extensions;
using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Sorting;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories;

namespace Catalog.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add core services
            builder.Services.AddControllers();

            // Modular registration
            builder.Services.AddApiVersioningConfig()
                .AddSwaggerConfig()
                .AddAplicationServices();

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
