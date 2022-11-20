using Microsoft.EntityFrameworkCore;
using Resort_Rental.Domain.Mapper;
using Resort_Rental.Repository.RepositoryBase;
using Resort_Rental.Service.RoomService;
using Resort_Rental.Service.UserService;
using ResortRental.Repository.DataContext;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var connectionStr = config.GetConnectionString("default");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about confiInvalidOperationException: Unable to resolve service for type 'Microsoft.EntityFrameworkCore.DbSet`1[ResortRental.Domain.Entity.Room]' while attempting to activate 'Resort_Rental.Repository.RepositoryBase.BaseRepository`2[ResortRental.Domain.Entity.Room,System.Int64]'.guring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseMySql(connectionStr, ServerVersion.AutoDetect(connectionStr));
});

// Register AutoMapper
/*builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());*/
builder.Services.AddAutoMapper(typeof(RoomProfiles).Assembly);
builder.Services.AddAutoMapper(typeof(UserProfiles).Assembly);
/*builder.Services.AddAutoMapperProfile<RoomProfiles>();*/
#region Register Dependency Injection

builder.Services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IUserService, UserService>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

