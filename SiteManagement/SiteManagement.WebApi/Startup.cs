using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SiteManagement.Business.Abstract;
using SiteManagement.Business.Concrete;
using SiteManagement.Business.Configuration.Auth;
using SiteManagement.Business.Configuration.Cache;
using SiteManagement.Business.Configuration.Mapper;
using SiteManagement.DAL.Abstract;
using SiteManagement.DAL.Concrete.Ef;
using SiteManagement.DAL.DbContexts;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Text;

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

            services.AddControllers(opt=>
            {
                //opt.Filters.Add<PermissionFilter>();
            });

            services.AddScoped<IPaymentService, PaymentService>();

            services.AddScoped<IBlockService, BlockService>();
            services.AddScoped<IDebtService, DebtService>();
            services.AddScoped<IFlatService, FlatService>();
            services.AddScoped<IFlatTypeService, FlatTypeService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISiteService, SiteService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IBlockRepository, EfBlockRepository>();
            services.AddScoped<IDebtRepository, EfDebtRepository>();
            services.AddScoped<IFlatRepository, EfFlatRepository>();
            services.AddScoped<IFlatTypeRepository, EfFlatTypeRepository>();
            services.AddScoped<IMessageRepository, EfMessageRepository>();
            services.AddScoped<IUserRepository, EfUserRepository>();
            services.AddScoped<ISiteRepository, EfSiteRepository>();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Http Request
            services.AddHttpClient();

            //Auto Mapper
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new MapperProfile());
            });

            //Redis
            var redisSettings = Configuration.GetSection("RedisSettings").Get<RedisSettings>();

            services.AddStackExchangeRedisCache(opt =>
            {
                opt.ConfigurationOptions = new ConfigurationOptions()
                {
                    EndPoints =
                    {
                        { redisSettings.EndPoint, redisSettings.Port }
                    },
                    Password = redisSettings.Password,
                    User = redisSettings.UserName

                };
            });
            services.AddMemoryCache();

            //Token Authentication
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOption>();
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))
                    };
                });

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"Meltem - JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
