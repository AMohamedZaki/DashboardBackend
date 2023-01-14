
using System.Reflection;
using Dashboard.Core.Interfaces;
using Dashboard.Infrastructure;
using Dashboard.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Dashboard.Infrastructure.Repository.Interfaces;
using Dashboard.Infrastructure.Repository;
using Dashboard.Infrastructure.Serives;
using Dashboard.Infrastructure.Serives.interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddControllersWithViews().AddNewtonsoftJson();
builder.Services.AddRazorPages();

//Wael 22092022
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddTransient(typeof(IRepository<>), typeof(RepositoryBaseGeneric<>));
builder.Services.AddTransient(typeof(ICityRepository), typeof(CityRepository));
builder.Services.AddTransient(typeof(IGovernorateRepository), typeof(GovernorateRepository));
builder.Services.AddTransient(typeof(IDistrictRepository), typeof(DistrictRepository));
builder.Services.AddTransient(typeof(IAccountRepository), typeof(AccountRepository));
builder.Services.AddTransient(typeof(IAccountService), typeof(AccountService));

builder.Services.AddMediatR(Assembly.GetAssembly(typeof(Program)));

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IEmailSender, EmailSender>();

builder.Services.AddControllersWithViews().AddNewtonsoftJson();
builder.Services.AddRazorPages();

builder.Services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                                    .AllowAnyMethod()
                                                                     .AllowAnyHeader()));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dashboard", Version = "v1" });
    c.EnableAnnotations();
});

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
//builder.Logging.AddAzureWebAppDiagnostics(); add this if deploying to Azure

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseRouting();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseSwagger();

app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

app.UseCors("AllowAll");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
