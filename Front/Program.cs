using Business;
using Business.Common.Mappings;
using Data;
using Data.Context;
using Data.Interfaces;
using Data.Models;
using Front.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Front.Middleware;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddServerSideBlazor().AddCircuitOptions(options => options.DetailedErrors = true);
}
else
{
    builder.Services.AddServerSideBlazor();
}

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBusiness();
builder.Services.AddDatabaseContext(builder.Configuration);
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    cfg.AddProfile(new AssemblyMappingProfile(typeof(IDataDbContext).Assembly));
    cfg.AddProfile(new AssemblyMappingProfile(typeof(AssemblyMappingProfile).Assembly));
});

builder.Services.AddDbContext<DataDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("SQLite");
    options.UseSqlite(connectionString);
});
builder.Services.AddIdentity<Employee, IdentityRole>()
    .AddEntityFrameworkStores<DataDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Параметры пароля
    options.Password.RequireDigit = false; // Не требует цифры
    options.Password.RequiredLength = 4; // Минимальная длина 4 символа
    options.Password.RequireNonAlphanumeric = false; // Не требует не-алфавитно-цифровый символ
    options.Password.RequireUppercase = false; // Не требует символ верхнего регистра
    options.Password.RequireLowercase = false; // Не требует символ нижнего регистра
});

builder.Services.AddControllers();
builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7027/api/")
    });
builder.Services.AddHttpClient();
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

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
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
app.UseDefaultFiles();

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
