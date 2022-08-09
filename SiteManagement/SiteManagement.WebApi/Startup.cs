using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SiteManagement.Business.Abstract;
using SiteManagement.Business.Concrete;
using SiteManagement.Business.Configuration.Mapper;
using SiteManagement.Business.Integration.Abstract;
using SiteManagement.Business.Integration.Concrete;
using SiteManagement.DAL.Abstract;
using SiteManagement.DAL.Concrete.Ef;
using SiteManagement.DAL.DbContexts;

namespace SiteManagement.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SiteManagementDbContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SiteManagement.WebApi", Version = "v1" });
            });

            services.AddScoped<IBlockService, BlockService>();
            services.AddScoped<IDebtService, DebtService>();
            services.AddScoped<IFlatService, FlatService>();
            services.AddScoped<IFlatTypeService, FlatTypeService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<ISiteService, SiteService>();
            services.AddScoped<IPaymentService, PaymentService>();
           
            services.AddScoped<IBlockRepository, EfBlockRepository>();
            services.AddScoped<IDebtRepository, EfDebtRepository>();
            services.AddScoped<IFlatRepository, EfFlatRepository>();
            services.AddScoped<IFlatTypeRepository, EfFlatTypeRepository>();
            services.AddScoped<IMessageRepository, EfMessageRepository>();
            services.AddScoped<IPersonRepository, EfPersonRepository>();
            services.AddScoped<ISiteRepository, EfSiteRepository>();

            services.AddHttpClient();

            services.AddAutoMapper(config =>
            {
                config.AddProfile(new MapperProfile());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SiteManagement.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
