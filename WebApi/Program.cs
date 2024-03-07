using System.Reflection;
using Business;
using Data.Context;
using Business.Common.Mappings;
using Data;
using Data.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Identity;
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

builder.Services.AddIdentity<Employee, IdentityRole>()
    .AddEntityFrameworkStores<DataDbContext>()
    .AddDefaultTokenProviders();

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
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger(c =>
{
    c.RouteTemplate = "api/swagger/{documentname}/swagger.json";
});


app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "SibersApi");
    c.RoutePrefix = "api/swagger";
});

app.UseCustomExceptionHandler();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();