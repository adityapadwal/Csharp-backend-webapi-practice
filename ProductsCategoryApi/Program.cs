// importing namespaces
using Microsoft.Build.Experimental;
using Microsoft.EntityFrameworkCore;
using ProductCategoryApi.Repositories;
using ProductsCategoryApi.Data;
using ProductsCategoryApi.Mappings;
using ProductsCategoryApi.Repositories;

// current namespace
namespace ProductsCategoryApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // registering the DbContext and connection string
            builder.Services.AddDbContext<AppDbContext>(
                (options) => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnections")
                )
            );
            
            // registering AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // register repositories
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
