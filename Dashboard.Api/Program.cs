
using System.Reflection;
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
using Dashboard.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;
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

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 4;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
    }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.AddControllersWithViews().AddNewtonsoftJson();
builder.Services.AddRazorPages();

//Wael 22092022
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddHealthChecks();
builder.Services.AddTransient(typeof(IRepository<>), typeof(RepositoryBaseGeneric<>));
builder.Services.AddTransient(typeof(IUserAccountService), typeof(UserAccountService));

builder.Services.AddTransient(typeof(IRegionRepository), typeof(RegionRepository));
builder.Services.AddTransient(typeof(ICityRepository), typeof(CityRepository));
builder.Services.AddTransient(typeof(IDistrictRepository), typeof(DistrictRepository));

builder.Services.AddSingleton<IJwtHandler, JwtHandler>();


builder.Services.AddMediatR(Assembly.GetAssembly(typeof(Program)));
builder.Services.AddAutoMapper(typeof(Program).Assembly);
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

// Handle Jwt Token 
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
        ValidAudience = jwtSettings.GetSection("validAudience").Value,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("securityKey").Value))
    };
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query["access_token"];
            context.Token = accessToken;
            return Task.CompletedTask;
        }
    };
});


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

app.UseSwaggerUI(c => {

    c.SwaggerEndpoint("/Menu/swagger/v1/swagger.json", "Dashboard V1");
    c.RoutePrefix = "";
    //c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dashboard V1");
});


app.UseCors("AllowAll");

// For Check Health App
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/health");
});


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();