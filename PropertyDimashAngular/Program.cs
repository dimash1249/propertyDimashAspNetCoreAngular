using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PropertyDimashAngular.Data;
using PropertyDimashAngular.Models;
using PropertyDimashAngular.Services;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);//.AddJsonOptions(opts => {opts.JsonSerializerOptions.PropertyNamingPolicy = null; opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve; opts.JsonSerializerOptions.MaxDepth = 64; });
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IResidentialComplexService, ResidentialComplexService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddIdentityCore<IdentityUser>(options =>
{
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
}).AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
//builder.Configuration<ApplicationSettings>(builder.Configuration.GetSection("ApplicationSettings"));
var key = Encoding.UTF8.GetBytes(builder.Configuration["Applicationsettings:JWT_Secret"].ToString());
builder.Services.AddAuthentication(d =>
{
    d.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    d.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    d.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(d =>
{
    d.RequireHttpsMetadata = false;
    d.SaveToken = false;
    d.TokenValidationParameters = new TokenValidationParameters { ValidateIssuerSigningKey = true, IssuerSigningKey = new SymmetricSecurityKey(key), ValidateIssuer = false, ValidateAudience = false, ClockSkew = TimeSpan.Zero, };
});



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("https://localhost:44443").AllowAnyHeader().AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowSpecificOrigin");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
