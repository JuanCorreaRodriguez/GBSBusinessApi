using System.Text;
using GlamBeautyApi.Connections;
using GlamBeautyApi.Entities;
using GlamBeautyApi.Interfaces.Auth;
using GlamBeautyApi.Interfaces.Category;
using GlamBeautyApi.Interfaces.Course;
using GlamBeautyApi.Interfaces.User;
using GlamBeautyApi.Repository;
using GlamBeautyApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling =
        ReferenceLoopHandling.Ignore; // Prevent Objs cycles
});
// Identity
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<PostgreDbContext>();

// Scheme
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
        options.DefaultChallengeScheme =
            options.DefaultForbidScheme =
                options.DefaultScheme =
                    options.DefaultSignInScheme =
                        options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SigninKey"]!)
        )
    };
});

// Repositories - Services
builder.Services.AddScoped<IAppUserRepository, AppUserRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddScoped<IAppUserService, AppAppUserService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "GBS Business Api",
        Description = "Api for GlamBeauty Salon Business",
        TermsOfService = new Uri("https://example.com/terms")
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            []
        }
    });
});

// PostgreSQL
builder.Services.AddDbContext<PostgreDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionPSQL")));
//postgres://CodeliStudio:R0ckw3ll@localhost:5432/GBS //  <- Doesn't work

// MongoDb
//builder.Services.AddSingleton<IMongoDatabase>( o =>
//{
//    var databseSetting = o.GetRequiredService<IOptions<MongoDatabaseSettings>>().Value;
//    var mongoDBClient = new MongoClient(databseSetting.Con)

//    return MongoDB;

//});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseSwagger();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    // Serve swagger in app root only in dev mode
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
        options.DocExpansion(DocExpansion.None);
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

// eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImNvZGVsaUBjb2RlbGlzdHVkaW8uY29tIiwiZ2l2ZW5fbmFtZSI6ImNvZGVsaXN0dWRpbzEiLCJuYmYiOjE3NDQwMDc3MTMsImV4cCI6MTc0NDYxMjUxMywiaWF0IjoxNzQ0MDA3NzEzLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MjEzIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIxMyJ9.NrU299tpKDB_2Q9F1VvkmFN0iKf3MuLK6ay9o8Q857yYyrKFK6FAHxYD1Zl8NPl5QnMJdsLrTTtJTkUquflc7A