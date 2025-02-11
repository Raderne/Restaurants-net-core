using Api.Hubs;
using Api.Middleware;
using Api.Services;
using Application;
using Application.Interfaces;
using Identites;
using Infrastrucure;
using Infrastrucure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Api;

public static class StartupExtention
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddSignalR();

        builder.Services.AddControllers();

        builder.Services.AddApplicationServices();
        builder.Services.AddIdentitiesServices(builder.Configuration);
        builder.Services.AddInfrastructure(builder.Configuration);

        builder.Services.AddScoped<INotificationService, NotificationService>();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(cfg =>
        {
            cfg.AddSecurityDefinition(
                "BearerAuth",
                new OpenApiSecurityScheme { Type = SecuritySchemeType.Http, Scheme = "Bearer" }
            );

            cfg.AddSecurityRequirement(
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "BearerAuth",
                            },
                        },
                        new string[] { }
                    },
                }
            );
        });

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(
                "CorsPolicy",
                policy =>
                {
                    policy
                        .WithOrigins("https://localhost:7156")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed((host) => true)
                        .AllowCredentials();
                }
            );

            options.AddPolicy(
                "SignalRCorsPolicy",
                policy =>
                {
                    policy
                        .WithOrigins("http://localhost:5173")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed((host) => true)
                        .AllowCredentials();
                }
            );
        });

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseCors("CorsPolicy");
        app.UseCors("SignalRCorsPolicy");

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCustomExceptionHandler();
        app.UseHttpsRedirection();

        app.MapHub<OrderHub>("/orderhub");
        app.MapControllers();
        app.UseAuthorization();

        return app;
    }

    public static async Task ResetDatabase(this WebApplication application)
    {
        using var scope = application.Services.CreateScope();
        try
        {
            var context = scope.ServiceProvider.GetService<RestaurantsDbContext>();
            if (context is not null)
            {
                await context.Database.EnsureDeletedAsync();
                await context.Database.MigrateAsync();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
