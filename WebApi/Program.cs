using System.Reflection;
using Business;
using Data.Context;
using Business.Common.Mappings;
using Business.Interfaces;
using Data;
using Microsoft.EntityFrameworkCore;
using WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    cfg.AddProfile(new AssemblyMappingProfile(typeof(IDataDbContext).Assembly));
});

builder.Services.AddDbContext<DataDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("SQLite");
    options.UseSqlite(connectionString);
});

var optionsBuilder = new DbContextOptionsBuilder<DataDbContext>();
optionsBuilder.UseSqlite("Filename=Sibers.db");
var options = optionsBuilder.Options;

using (var context = new DataDbContext(options))
{
    context.Database.EnsureCreated();
}

builder.Services.AddBusiness();
builder.Services.AddDatabaseContext(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCustomExceptionHandler();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();