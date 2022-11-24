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
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("cedar01",
        new OpenApiSecurityScheme()
        {
            Description = "Authorization header, using prefix \"Bearer {token}\"",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseMySql(connectionStr, ServerVersion.AutoDetect(connectionStr));
    option.EnableSensitiveDataLogging();
});
builder.Services.AddIdentity<AppUser, AppRole>()
       .AddEntityFrameworkStores<ApplicationDbContext>()
       .AddDefaultTokenProviders();

//Register Jwt Authentication Service:
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(op => {
    op.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = config["Jwt:Audience"],
        ValidIssuer = config["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))
    };
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

