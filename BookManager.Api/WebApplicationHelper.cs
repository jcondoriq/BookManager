using BookManager.Cross.Entities.Interfaces;
using BookManager.Cross.ExceptionHandlers;
using BookManager.IoC;
using BookManager.Repositories.EFCore.DataContexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace BookManager.Api
{
    public static class WebApplicationHelper
    {
        public static WebApplication CreateWebApplication(
            this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                var jwtSecuritySchema = new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "Proporcionar el `Token JWT`.",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(jwtSecuritySchema.Reference.Id,
                    jwtSecuritySchema);
                c.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            jwtSecuritySchema,
                            Array.Empty<string>()
                        }
                    });
            });

            var JWTConfigurationSection = builder.Configuration.GetSection("JWT");
            builder.Services.AddBookManagerServices(
                builder.Configuration, "BookManagerDb", JWTConfigurationSection);

            builder.Services.AddCors(option =>
            {
                option.AddDefaultPolicy(config =>
                {
                    config.AllowAnyMethod();
                    config.AllowAnyOrigin();
                    config.AllowAnyHeader();
                });
            });

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                            .AddJwtBearer(options =>
                            {
                                JWTConfigurationSection.Bind(
                                    options.TokenValidationParameters);

                                options.TokenValidationParameters
                                       .IssuerSigningKey = new SymmetricSecurityKey(
                                           Encoding.UTF8.GetBytes(
                                               JWTConfigurationSection["SecurityKey"]));
                            });

            builder.Services.AddAuthorization();

            return builder.Build();
        }

        public static WebApplication ConfigureWebApplication(
            this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                // Buscar todos los DbContext registrados en AddBookManagerServices
                var dbContexts = scope.ServiceProvider
                                      .GetServices<BookManagerContext>();

                foreach (var db in dbContexts)
                {
                    try
                    {
                        db.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error applying migrations for {db.GetType().Name}: {ex.Message}");
                    }
                }
            }

            _ = app.UseExceptionHandler(builder =>
                    builder.UseWebExceptionHandlerMiddleware(
                        app.Environment,
                        app.Services.GetService<IWebExceptionHandler>()!));

            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
