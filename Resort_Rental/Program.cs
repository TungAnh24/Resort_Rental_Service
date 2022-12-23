using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Resort_Rental.Domain.Entities;
using Resort_Rental.Domain.Mapper;
using Resort_Rental.Repository.DataContext;
using Resort_Rental.Repository.RepositoryBase;
using Resort_Rental.Service.ContractService;
using Resort_Rental.Service.GuestService;
using Resort_Rental.Service.RoomService;
using Resort_Rental.Service.UserService;
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
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
       .AddJwtBearer(op =>
       {
           op.SaveToken = true;
           op.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuer = false,
               ValidateAudience = false,
               ValidIssuer = config["Jwt:Issuer"],
               ValidAudience = config["Jwt:Audience"],
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))
           };
       });

builder.Services.AddSwaggerGen(options =>
{

    OpenApiSecurityScheme securityDefinition = new OpenApiSecurityScheme()
    {
        Name = "Bearer",
        BearerFormat = "JWT",
        Scheme = "bearer",
        Description = "Specify the authorization token.",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
    };
    /*options.SwaggerDoc("v1", new OpenApiInfo { Title = "WebUploadFile", Version = "v1" });*/
    options.AddSecurityDefinition("jwt_auth", securityDefinition);

    // Make sure swagger UI requires a Bearer token specified
    OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme()
    {
        Reference = new OpenApiReference()
        {
            Id = "jwt_auth",
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

// Enable CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:8080",
                                              "http://localhost:5136")
                                              .AllowAnyMethod()
                                              .AllowAnyHeader();
                      });
});

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseMySql(connectionStr, ServerVersion.AutoDetect(connectionStr));
    option.EnableSensitiveDataLogging();
});


builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();

// Register AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(RoomProfiles).Assembly);
builder.Services.AddAutoMapper(typeof(UserProfiles).Assembly);
builder.Services.AddAutoMapper(typeof(ContractProfile).Assembly);

#region Register Dependency Injection

builder.Services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGuestService, GuestService>();
builder.Services.AddScoped<IContractService, ContractService>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseStaticFiles();

app.Run();