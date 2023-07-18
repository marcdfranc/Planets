using Api.Extensions;
using Api.Middleware;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(o =>
{
    o.SerializerSettings.Converters.Add(new StringEnumConverter
    {
        CamelCaseText = true
    });
});

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddSwaggerServices();
// builder.Services.AddIdentityServices(builder.Configuration);
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseMiddleware<ApiKeyMiddleware>();

// app.UseAuthorization();

app.MapControllers();

app.MapFallbackToController("Index", "Fallback");


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<DataContext>();
        await context.Database.MigrateAsync();

        // var userManager = services.GetRequiredService<UserManager<AppUser>>(); TO DO register users for back-end

        await Seed.SeedData(context);
    }
    catch (Exception e)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(e, "An error occured during migration.");
    }
}

app.Run();
