using System.ComponentModel.DataAnnotations.Schema;
using infrastructure.Data;
using infrastructure.Mapper;
using infrastructure.Services;
using Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ServiceProfile));
builder.Services.AddDbContext<DataContext>(config=>config.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<OrderService>();

builder.Services.AddSwaggerGenNewtonsoftSupport();
builder.Services
    .AddControllersWithViews()
    .AddNewtonsoftJson(options => 
        options.SerializerSettings.Converters.Add(new StringEnumConverter()));
    
var app = builder.Build();
try
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<DataContext>();
        await context.Database.MigrateAsync();
        
        DefaultProductSeed.ProductSeed(context);
        
       
        
        
        app.Logger.LogInformation("Finished Seeding Default Data");
        app.Logger.LogInformation("Application Starting");
    }
}

catch (Exception ex)
{
    app.Logger.LogError($"An Error occurred while seeding the db:  {ex.Message}");
}

// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;
//     var context = services.GetRequiredService<DataContext>();
    
    
// }
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
      
