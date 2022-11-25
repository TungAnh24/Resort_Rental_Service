using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Resort_Rental.Domain.Entities;
using Resort_Rental.Domain.Mapper;
using Resort_Rental.Repository.RepositoryBase;
using Resort_Rental.Service.GuestService;
using Resort_Rental.Service.RoomService;
using Resort_Rental.Service.UserService;
using ResortRental.Domain.Entities;
using ResortRental.Repository.DataContext;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var connectionStr = config.GetConnectionString("default");


// Add services to the container.

builder.Services.AddControllers();
// Learn more about confiInvalidOperationException: Unable to resolve service for type 'Microsoft.EntityFrameworkCore.DbSet`1[ResortRental.Domain.Entity.Room]' while attempting to activate 'Resort_Rental.Repository.RepositoryBase.BaseRepository`2[ResortRental.Domain.Entity.Room,System.Int64]'.guring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddIdentity<AppUser, AppRole>()
       .AddEntityFrameworkStores<ApplicationDbContext>()
       .AddDefaultTokenProviders();

//Register Jwt Authentication Service:
builder.Services.AddAuthentication()
       .AddJwtBearer(op => {
           op.SaveToken = true;
           op.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuer           = false,
               ValidateAudience         = false,
               IssuerSigningKey         = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"])),
               ValidateIssuerSigningKey = true
           };
       });

builder.Services.AddSwaggerGen(options => {
    
    OpenApiSecurityScheme securityDefinition = new OpenApiSecurityScheme()
    {
        Name         = "Bearer",
        BearerFormat = "JWT",
        Scheme       = "bearer",
        Description  = "Specify the authorization token.",
        In           = ParameterLocation.Header,
        Type         = SecuritySchemeType.Http,
    };
    options.AddSecurityDefinition("jwt_auth", securityDefinition);

// Make sure swagger UI requires a Bearer token specified
    OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme()
    {
        Reference = new OpenApiReference()
        {
            Id   = "jwt_auth",
            Type = ReferenceType.SecurityScheme
        }
    };
    OpenApiSecurityRequirement securityRequirements = new OpenApiSecurityRequirement()
    {
        {securityScheme, new string[] { }},
    };
    options.AddSecurityRequirement(securityRequirements);
    
    //options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddDbContext<ApplicationDbContext>(option => {
    option.UseMySql(connectionStr, ServerVersion.AutoDetect(connectionStr));
    option.EnableSensitiveDataLogging();
});


builder.Services.AddHttpContextAccessor();

// Register AutoMapper
/*builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());*/
builder.Services.AddAutoMapper(typeof(RoomProfiles).Assembly);
builder.Services.AddAutoMapper(typeof(UserProfiles).Assembly);
builder.Services.AddAutoMapper(typeof(GuestProfile).Assembly);
/*builder.Services.AddAutoMapperProfile<RoomProfiles>();*/

#region Register Dependency Injection

builder.Services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGuestService, GuestService>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();