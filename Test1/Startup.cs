using Data.Context;
using Data.Models;
using Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Test1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=BookShop0001;Trusted_Connection=True;";
            services.AddControllers();
            services.AddDbContext<BookShopContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IRepository<AgeCategory>, AgeCategoryRepository>();
            services.AddScoped<IRepository<Author>, AuthorRepository>();
            services.AddScoped<IRepository<Book>, BooksRepository>();
            services.AddScoped<IRepository<CoverType>, CoverTypesRepository>();
            services.AddScoped<IRepository<Genre>, GenresRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Bookshop", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Bookshop docs V1");
            });

            app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); 
            });
        }
    }
}
