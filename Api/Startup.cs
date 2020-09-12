using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MyMoon.Application;
using MyMoon.Infrastructure;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Swashbuckle.AspNetCore.SwaggerGen;
using MyMoon.Api.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IConfiguration _configuration;
        private ILoggerFactory _loggerFactory;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure(_configuration);

            services.AddHttpContextAccessor();
            services.AddHealthChecks();
            services.AddControllers();
            //.AddFluentValidation(options => options.RegisterValidatorsFromAssembly(typeof(MyMoon.Application.DependencyInjection).Assembly));

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidIssuer = _configuration.GetSection("JWTTokenSettings").GetValue<string>("ValidIssuer"),
                        ValidAudience = _configuration.GetSection("JWTTokenSettings").GetValue<string>("ValidAudience"),
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWTTokenSettings").GetValue<string>("Key"))),
                    };
                })
                .AddGoogle("google", opt =>
                {
                    var googleAuth = _configuration.GetSection("Authentication:Google");
                    opt.ClientId = googleAuth["ClientId"];
                    opt.ClientSecret = googleAuth["ClientSecret"];
                    opt.SignInScheme = IdentityConstants.ExternalScheme;
                    opt.Scope.Add("openid");
                    opt.Scope.Add("profile");
                    opt.Scope.Add("email");
                    opt.SaveTokens = true;
                });

            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.HttpOnly = true;
                config.LoginPath = "/api/account/login";
                config.SlidingExpiration = true;
                config.ExpireTimeSpan = TimeSpan.FromHours(1);
            });

            //Policy
            var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

            services.AddAuthorization(opts =>
            {
                opts.DefaultPolicy = policy;
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowAll",
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin();
                                      builder.AllowAnyMethod();
                                      builder.AllowAnyHeader();
                                  });
            });

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "yangogo API",
                    Description = "yangogo",

                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "yangogo",
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = string.Empty,
                    }
                });

                x.DocumentFilter<LowercaseDocumentFilter>();
                x.CustomSchemaIds(s => s.FullName);

                x.OperationFilter<AddRequiredHeaderParameter>();
                x.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Please enter JWT with Bearer into field",
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new List<string>()
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHealthChecks("/health");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowAll");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "API V1");

                // For Model Section
                c.DefaultModelsExpandDepth(-1);
            });
        }
    }
}
